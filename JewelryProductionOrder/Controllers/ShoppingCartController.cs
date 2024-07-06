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
	}
}
