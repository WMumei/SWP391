using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories.IRepository;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
    public class WarrantyCardController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly IWarrantyCardRepository _warrantyCardRepo;
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;

		public WarrantyCardController(IUnitOfWork unitOfWork, UserManager<User> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public IActionResult Create(int jId)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			//var Custumer = _unitOfWork.User.Get(User => User.Id == userId);
			WarrantyCardVM vm = new WarrantyCardVM
			{
				Jewelry = jewelry,
				WarrantyCard = new WarrantyCard { },
				//Customer = jewelry.User.Get()
			};
			return View(vm);
		}
		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(WarrantyCardVM vm)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			vm.WarrantyCard.SalesStaffId = userId;

			vm.WarrantyCard.CreatedAt = DateTime.Now;
			
			
			//vm.QuotationRequest.MaterialSetId = materialSet.Id;
			vm.WarrantyCard	.JewelryId = vm.Jewelry.Id;
			//vm.QuotationRequest.TotalPrice = vm.QuotationRequest.LaborPrice + materialSet.TotalPrice;
			_unitOfWork.WarrantyCard.Add(vm.WarrantyCard);
			_unitOfWork.Save();
			return RedirectToAction("Index", "Jewelry");
		}
		public IActionResult Index()
        {
            List<WarrantyCard> objWarrantyCardList = _warrantyCardRepo.GetAll().ToList();
            return View();
        }

    }
}
