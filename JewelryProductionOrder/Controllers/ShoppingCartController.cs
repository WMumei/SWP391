using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories.IRepository;
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
	}
}
