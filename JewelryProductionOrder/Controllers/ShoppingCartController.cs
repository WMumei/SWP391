using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	[Authorize(Roles = SD.Role_Customer)]
	public class ShoppingCartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public ShoppingCartVM ShoppingCartVM { get; set; }
		private readonly UserManager<User> _userManager;

		// Implenment Round-Robin only in the controller (not as good as in DB)
		private static int currentSalesStaffIndex = 0;
		public ShoppingCartController(IUnitOfWork unitOfWork, UserManager<User> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			ShoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
				includeProperties: "BaseDesign").ToList(),
				ProductionRequest = new()
			};

			return View(ShoppingCartVM);
		}

		public IActionResult Plus(int cartId)
		{
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			cartFromDb.Quantity += 1;
			_unitOfWork.ShoppingCart.Update(cartFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Minus(int cartId)
		{
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			if (cartFromDb.Quantity <= 1)
			{
				_unitOfWork.ShoppingCart.Remove(cartFromDb);
			}
			else
			{
				cartFromDb.Quantity -= 1;
				_unitOfWork.ShoppingCart.Update(cartFromDb);
			}

			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(int cartId)
		{
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			TempData["success"] = "Jewelry is removed!";
			_unitOfWork.ShoppingCart.Remove(cartFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Summary()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			var cartList = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId, includeProperties: "BaseDesign").ToList();

			if (cartList.Count <= 0)
			{
				TempData["error"] = "Your shopping cart is empty. Please add one or more items first.";
				return RedirectToAction(nameof(Index));
			}

			ShoppingCartVM = new()
			{
				ShoppingCartList = cartList,
				ProductionRequest = new()
				{
					CreatedAt = DateTime.Now
				}
			};

			User customer = _unitOfWork.User.Get(u => u.Id == userId);
			ShoppingCartVM.ProductionRequest.Customer = customer;
			// Default values are from the user's profile
			ShoppingCartVM.ProductionRequest.ContactName = customer?.Name;
			ShoppingCartVM.ProductionRequest.PhoneNumber = customer?.PhoneNumber;
			ShoppingCartVM.ProductionRequest.Address = customer?.Address;
			ShoppingCartVM.ProductionRequest.Email = customer?.Email;

			return View(ShoppingCartVM);
		}

		[HttpPost]
		[ActionName("Summary")]
		public async Task<IActionResult> SummaryPOST()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
				includeProperties: "BaseDesign").ToList();

			if (ShoppingCartVM.ShoppingCartList.Count() <= 0)
			{
				TempData["error"] = "Your shopping cart is empty. Please add one or more items first.";
				return RedirectToAction(nameof(Index));
			}

			// Validate ProductionRequest fields
			if (string.IsNullOrEmpty(ShoppingCartVM.ProductionRequest.Address) ||
				string.IsNullOrEmpty(ShoppingCartVM.ProductionRequest.ContactName) ||
				string.IsNullOrEmpty(ShoppingCartVM.ProductionRequest.Email) ||
				string.IsNullOrEmpty(ShoppingCartVM.ProductionRequest.PhoneNumber) 
				)
			{
				TempData["error"] = "Please fill in all required fields: Address, Contact Name, and Email.";
				return RedirectToAction(nameof(Summary));
			}

			ShoppingCartVM.ProductionRequest.CustomerId = userId;
			ShoppingCartVM.ProductionRequest.Status = SD.StatusProcessing;
			ShoppingCartVM.ProductionRequest.CreatedAt = DateTime.Now;

			User applicationUser = _unitOfWork.User.Get(u => u.Id == userId);

			var salesStaffIds = await GetSalesStaffIdsAsync();
			var assignedStaffId = salesStaffIds[currentSalesStaffIndex];
			ShoppingCartVM.ProductionRequest.SalesStaffId = assignedStaffId;
			_unitOfWork.ProductionRequest.Add(ShoppingCartVM.ProductionRequest);
			_unitOfWork.Save();
			int quantity = 0;
			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				ProductionRequestDetail requestDetail = new()
				{
					BaseDesignId = cart.BaseDesignId,
					ProductionRequestId = ShoppingCartVM.ProductionRequest.Id,
					Quantity = cart.Quantity
				};
				quantity += cart.Quantity;
				for (int i = 0; i < cart.Quantity; i++)
				{
					Jewelry jewelry = new Jewelry()
					{
						Name = cart.BaseDesign.Name,
						BaseDesignId = cart.BaseDesignId,
						ProductionRequestId = ShoppingCartVM.ProductionRequest.Id,
						CreatedAt = DateTime.Now,
						CustomerId = userId,
						SalesStaffId = assignedStaffId,
						Status = SD.StatusProcessing
					};
					_unitOfWork.Jewelry.Add(jewelry);
				}
				_unitOfWork.ProductionRequestDetail.Add(requestDetail);
				_unitOfWork.Save();
			}
			ShoppingCartVM.ProductionRequest.Quantity = quantity;
			_unitOfWork.ProductionRequest.Update(ShoppingCartVM.ProductionRequest);
			_unitOfWork.Save();
			return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.ProductionRequest.Id });
		}

		public IActionResult OrderConfirmation(int id)
		{

			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id);
			if (productionRequest is null)
			{
				TempData["error"] = "Error while confirming order";
				return RedirectToAction("Index", "Home");
			}

			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart
				.GetAll(u => u.UserId == productionRequest.CustomerId).ToList();

			_unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
			_unitOfWork.Save();

			return View(id);
		}

		private async Task<List<string>> GetSalesStaffIdsAsync()
		{
			var usersInRole = await _userManager.GetUsersInRoleAsync(SD.Role_Sales);
			return usersInRole.Select(u => u.Id).ToList();
		}
	}
}
