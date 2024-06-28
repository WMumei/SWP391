using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
    public class ShoppingCartController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		public ShoppingCartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public IActionResult Checkout()
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			// TODO: handle filling production req
			OrderVM order = new()
			{
				ShoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
				includeProperties: "BaseDesign").ToList(),
				ProductionRequest = new()
			};


			return View(order);
		}

    }
}
