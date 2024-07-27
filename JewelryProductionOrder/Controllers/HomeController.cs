using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<BaseDesign> designs = _unitOfWork.BaseDesign.GetAll(d => d.Type == "Company").ToList();
			return View(designs);
		}

		public IActionResult ViewMore()
		{
			List<BaseDesign> designs = _unitOfWork.BaseDesign.GetAll(d => d.Type == "Company").ToList();
			return View(designs);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Details(int baseDesignId)
		{
			ShoppingCart cart = new ShoppingCart()
			{
				BaseDesignId = baseDesignId,
				BaseDesign = _unitOfWork.BaseDesign.Get(d => d.Id == baseDesignId),
				Quantity = 1
			};
			return View(cart);
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Customer)]
		public IActionResult Details(ShoppingCart shoppingCart)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			shoppingCart.UserId = userId;

			ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.UserId == userId &&
			u.BaseDesignId == shoppingCart.BaseDesignId);

			if (cartFromDb != null)
			{
				//shopping cart exists
				cartFromDb.Quantity += shoppingCart.Quantity;
				_unitOfWork.ShoppingCart.Update(cartFromDb);
				_unitOfWork.Save();
			}
			else
			{
				//add cart record
				_unitOfWork.ShoppingCart.Add(shoppingCart);
				_unitOfWork.Save();
			}
			TempData["success"] = "Cart updated successfully";

			return RedirectToAction(nameof(Index));
		}
	}
}
