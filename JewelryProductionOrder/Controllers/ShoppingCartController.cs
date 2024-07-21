using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories.IRepository;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	[Authorize]
	public class ShoppingCartController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public ShoppingCartVM ShoppingCartVM { get; set; }
		public ShoppingCartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		//      public IActionResult Checkout()
		//      {
		//	var claimsIdentity = (ClaimsIdentity)User.Identity;
		//	var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
		//	// TODO: handle filling production req
		//	ShoppingCartVM order = new()
		//	{
		//		ShoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
		//		includeProperties: "BaseDesign").ToList(),
		//		ProductionRequest = new()
		//	};


		//	return View(order);
		//}

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
			_unitOfWork.ShoppingCart.Remove(cartFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Summary()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			ShoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
				includeProperties: "BaseDesign").ToList(),
				ProductionRequest = new()
				{
					CreatedAt = DateTime.Now
				}
			};

			User customer = _unitOfWork.User.Get(u => u.Id == userId);
			ShoppingCartVM.ProductionRequest.Customer = customer;
			// Default values for shipping
			ShoppingCartVM.ProductionRequest.ContactName = customer.Name;
			ShoppingCartVM.ProductionRequest.PhoneNumber = customer.PhoneNumber;
			ShoppingCartVM.ProductionRequest.Address = customer.Address;
			ShoppingCartVM.ProductionRequest.Email = customer.Email;

			return View(ShoppingCartVM);
		}

		[HttpPost]
		[ActionName("Summary")]
		public IActionResult SummaryPOST()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
				includeProperties: "BaseDesign").ToList();

			ShoppingCartVM.ProductionRequest.CustomerId = userId;
			ShoppingCartVM.ProductionRequest.Status = SD.StatusProcessing;
			ShoppingCartVM.ProductionRequest.CreatedAt = DateTime.Now;

			User applicationUser = _unitOfWork.User.Get(u => u.Id == userId);

			// TODO: Handle status of ProductionRequest

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
						CustomerId = userId
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

			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart
				.GetAll(u => u.UserId == productionRequest.CustomerId).ToList();

			_unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
			_unitOfWork.Save();

			return View(id);
		}

	}
}
