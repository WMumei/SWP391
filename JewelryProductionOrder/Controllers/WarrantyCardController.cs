using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	public class WarrantyCardController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;


		public WarrantyCardController(IUnitOfWork unitOfWork, UserManager<User> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public IActionResult Create(int jId, int? redirectRequest)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "Customer,MaterialSet,QuotationRequests");
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(j => j.Id == jewelry.ProductionRequestId);
			var customer = _unitOfWork.User.Get(u => u.Id == productionRequest.CustomerId);
			jewelry.CustomerId = customer.Id;
			customer.Name= productionRequest.ContactName;
			_unitOfWork.User.Update(customer);
			_unitOfWork.Save();
            //if (jewelry.MaterialSet == null && jewelry.QuotationRequests == null)
            //{
            //	TempData["Error"] = "Please create Material Set and Quotation Request!"; 
            //	if (redirectRequest is not null)
            //		return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
            //	return RedirectToAction("Index", "Home");
            //}
            //else
            //{


            WarrantyCardVM vm = new WarrantyCardVM
			{
				Jewelry = jewelry,
				WarrantyCard = new WarrantyCard { CreatedAt = DateTime.Now, ExpiredAt = DateTime.Now.AddYears(2) },

				Customer = customer

			};
			return View(vm);
			//}
		}


		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(WarrantyCardVM vm)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id, includeProperties: "Customer");
			if (jewelry.Status != SD.StatusManufactured)
			{
				TempData["error"] = "The jewelry hasn't been manufactured yet";
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = jewelry.ProductionRequestId });
			}

			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(j => j.Id == jewelry.ProductionRequestId,includeProperties:"Jewelries,Jewelries.WarrantyCard",tracked:true);
			var customer = _unitOfWork.User.Get(u => u.Id == productionRequest.CustomerId);


			vm.WarrantyCard.SalesStaffId = userId;
			vm.WarrantyCard.JewelryId = vm.Jewelry.Id;
			vm.WarrantyCard.CustomerId = customer.Id;
			vm.Customer = customer;
			vm.Jewelry = jewelry;
			if (vm.WarrantyCard.CreatedAt.Date < DateTime.Now.Date)
			{
				ModelState.AddModelError("WarrantyCard.CreatedAt", "Issued Date is not valid.");
			}
			if (vm.WarrantyCard.ExpiredAt < vm.WarrantyCard.CreatedAt.AddYears(1))
			{
				ModelState.AddModelError("WarrantyCard.ExpiredAt", "Expired Date is not valid.");
			}
			if (vm.WarrantyCard.CreatedAt.Date >= DateTime.Now.Date && vm.WarrantyCard.ExpiredAt >= vm.WarrantyCard.CreatedAt.AddYears(1))
			{
				_unitOfWork.WarrantyCard.Add(vm.WarrantyCard);
				_unitOfWork.Save();
				bool completed = true;
				foreach (var j in productionRequest.Jewelries)
				{
					if (j.WarrantyCard == null)
					{
						completed = false;
						break;
					}
				}
				if (completed)
				{
					productionRequest.Status = SD.StatusAllWarrantyCard;

				}
				_unitOfWork.Save();
				TempData["success"] = "Warranty Card is created successfully!";
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = productionRequest.Id });
			}

			return View(vm);
		}
		public IActionResult Index()
		{
			List<WarrantyCard> objWarrantyCardList = _unitOfWork.WarrantyCard.GetAll(includeProperties: "Jewelry,Customer").ToList();
			//IEnumerable<SelectListItem>
			return View(objWarrantyCardList);
		}
		
		public IActionResult DeletePost(int? id)
		{

			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == id);
			if (warrantyCard == null)
			{
				return NotFound();
			}
			_unitOfWork.WarrantyCard.Remove(warrantyCard);
			_unitOfWork.Save();
			TempData["success"] = "Warranty card is deleted successfully!";
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == id, includeProperties: "Customer,Jewelry");
			return View(warrantyCard);
		}
		[HttpPost]
		public IActionResult Edit(WarrantyCard obj)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == obj.Id);
            
            obj.Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == warrantyCard.JewelryId);
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(j => j.Id == obj.Jewelry. ProductionRequestId);
            obj.Customer = _unitOfWork.User.Get(j => j.Id == warrantyCard.CustomerId);
			if (obj.CreatedAt < DateTime.Now)
			{
				ModelState.AddModelError("CreatedAt", "Issued Date is not valid.");
			}
			if (obj.ExpiredAt < obj.CreatedAt.AddYears(1))
			{
				ModelState.AddModelError("ExpiredAt", "Expired Date is not valid.");
			}
			if (obj.CreatedAt >= DateTime.Now && obj.ExpiredAt >= obj.CreatedAt.AddYears(1))
			{
				warrantyCard.CreatedAt = obj.CreatedAt;
				warrantyCard.ExpiredAt = obj.ExpiredAt;

				_unitOfWork.WarrantyCard.Update(warrantyCard);

				_unitOfWork.Save();
				TempData["success"] = "Warranty Card is updated successfully. ";
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = productionRequest.Id });
			}
			return View(obj);
		}
		public IActionResult Details(int? id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(r => r.JewelryId == id, includeProperties: "Jewelry,Customer");
			WarrantyCardVM vm = new WarrantyCardVM
			{
				WarrantyCard = warrantyCard,
				Jewelry = warrantyCard.Jewelry,
				Customer = warrantyCard.Customer
			};
			return View(vm);
		}
	}
}
