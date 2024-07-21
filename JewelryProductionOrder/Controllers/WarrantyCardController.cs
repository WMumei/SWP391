using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories.IRepository;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Repositories.Repository.IRepository;
using System;
using System.Drawing;
using System.Security.Claims;
using System.Security.Cryptography;

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
			var customer = _unitOfWork.User.Get(u => u.Id == jewelry.Customer.Id);
			if (jewelry.MaterialSet == null && jewelry.QuotationRequests == null)
			{
				TempData["Error"] = "Please create Material Set and Quotation Request!"; 
				if (redirectRequest is not null)
					return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
				return RedirectToAction("Index", "Home");
			}
			else
			{

				WarrantyCardVM vm = new WarrantyCardVM
				{
					Jewelry = jewelry,
					WarrantyCard = new WarrantyCard { CreatedAt = DateTime.Now, ExpiredAt = DateTime.Now.AddYears(2) },
					
					Customer = customer
				
				};
				return View(vm);
			}
		}


		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(WarrantyCardVM vm)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id,includeProperties: "Customer");
			var customer = _unitOfWork.User.Get(u => u.Id == jewelry.Customer.Id);

			vm.WarrantyCard.SalesStaffId = userId;
			vm.WarrantyCard.JewelryId = vm.Jewelry.Id;
			vm.WarrantyCard.CustomerId = customer.Id;
			vm.Customer = customer;
			vm.Jewelry = jewelry;
			if (vm.WarrantyCard.CreatedAt < DateTime.Now)
			{

				ModelState.AddModelError("WarrantyCard.CreatedAt", "Issued Date is not valid.");
			}
			if (vm.WarrantyCard.ExpiredAt < vm.WarrantyCard.CreatedAt.AddYears(1))
			{
				ModelState.AddModelError("WarrantyCard.ExpiredAt", "Expired Date is not valid.");
			}
			if (vm.WarrantyCard.CreatedAt >= DateTime.Now && vm.WarrantyCard.ExpiredAt >= vm.WarrantyCard.CreatedAt.AddYears(1))
			{

				_unitOfWork.WarrantyCard.Add(vm.WarrantyCard);
				_unitOfWork.Save();
				TempData["success"] = "Warranty Card is created successfully!";
				return RedirectToAction("Index", "Jewelry");
			}


			return View(vm);
		}
		public IActionResult Index()
		{
			List<WarrantyCard> objWarrantyCardList = _unitOfWork.WarrantyCard.GetAll(includeProperties: "Jewelry,Customer").ToList();
			//IEnumerable<SelectListItem>
			return View(objWarrantyCardList);
		}
		/*public IActionResult Delete(int? id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);
			
			
			return View(warrantyCard);
		}
		*/
		//[HttpPost, ActionName("Delete")]
		//[HttpDelete]

		//public IActionResult DeletePost(int? id)
		//{

		//	WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);
		//	if (warrantyCard == null)
		//	{
		//		return NotFound();
		//	}
		//	_unitOfWork.WarrantyCard.Remove(warrantyCard);
		//	_unitOfWork.Save();
		//	TempData["success"] = "Warranty Card is deleted successfully!";
		//	return RedirectToAction("Index");
		//}

		public IActionResult Edit(int id) { 


        WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == id, includeProperties: "Customer,Jewelry");
			

			return View(warrantyCard);
		}
		[HttpPost]
		public IActionResult Edit(WarrantyCard obj)

		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == obj.Id);
			obj.Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == warrantyCard.JewelryId);
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
				return RedirectToAction("Index");
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
