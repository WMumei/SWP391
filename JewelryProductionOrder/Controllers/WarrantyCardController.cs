﻿using JewelryProductionOrder.Data;
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
using System.Security.Claims;
using System.Security.Cryptography;

namespace JewelryProductionOrder.Controllers
{
	public class WarrantyCardController : Controller
	{
		//private readonly ApplicationDbContext _db;
		private readonly IWarrantyCardRepository _warrantyCardRepo;
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;
		//private string userId;

		public WarrantyCardController(IUnitOfWork unitOfWork, UserManager<User> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public IActionResult Create(int jId)
		{

			

            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "Customer");
		    var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
			if(jewelry.MaterialSet ==null && jewelry.QuotationRequest == null)
			{
                TempData["WarningMessage"] = "Please create MaterialSet and QuotationRequest!";
            }
			WarrantyCardVM vm = new WarrantyCardVM
			{
				Jewelry = jewelry,
				WarrantyCard = new WarrantyCard { },
				CreatedAt = DateTime.Now,
				Customer = customer
				//CustomerId = customer.Id
			};
            return View(vm);
        }
		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(WarrantyCardVM vm)
		{
            //lưu người tạo
            var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			vm.WarrantyCard.SalesStaffId = userId;
			
			vm.WarrantyCard.JewelryId = vm.Jewelry.Id;
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.WarrantyCard.JewelryId, includeProperties: "Customer");
            var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId );
            
            _unitOfWork.Save();
           
            vm.WarrantyCard.CreatedAt = DateTime.Now;
			vm.WarrantyCard.ExpiredAt = vm.WarrantyCard.CreatedAt.AddYears(3);

            
            
			vm.WarrantyCard.CustomerId = customer.Id;
			
			_unitOfWork.WarrantyCard.Add(vm.WarrantyCard);
			_unitOfWork.Save();
			return RedirectToAction("Index", "Jewelry");
		}
		public IActionResult Index()
		{
			List<WarrantyCard> objWarrantyCardList = _unitOfWork.WarrantyCard.GetAll(includeProperties: "Jewelry,Customer").ToList();
			//IEnumerable<SelectListItem>
			return View(objWarrantyCardList);
		}
		public IActionResult Delete(int? id)
		{
			WarrantyCard warrantyCardFromDb = _warrantyCardRepo.Get(u => u.Id == id);
			if (warrantyCardFromDb == null)
			{
				return NotFound();
			}
			
			return View(warrantyCardFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			WarrantyCard warrantyCard = _warrantyCardRepo.Get(u => u.Id == id);
			if (warrantyCard == null)
			{
				return NotFound();
			}
			_unitOfWork.WarrantyCard.Remove(warrantyCard);
			_unitOfWork.Save();
			TempData["success"] = "Warranty Card is deleted successfully!";
			return RedirectToAction("Index");
		}
		
		public IActionResult Edit(int? id)
		{
			//not yet
            WarrantyCard? warrantyCardFromDb = _unitOfWork.WarrantyCard.Get(u => u.Id == id, includeProperties: "Jewelry,Customer");
            if (warrantyCardFromDb.Id == null)
			{
				return NotFound();
			}
			
			if (warrantyCardFromDb == null)
			{ return NotFound(); }
			return View(warrantyCardFromDb);
		}
		[HttpPost]
		public IActionResult Edit(WarrantyCardVM vm)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.WarrantyCard.Update(vm.WarrantyCard);

				_unitOfWork.Save();
				return RedirectToAction("Index", "WarrantyCard");
			}
			return View(vm);
		}
		public IActionResult Details(int? id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(r => r.JewelryId == id, includeProperties: "Jewelry,Customer");
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == id, includeProperties: "Customer");
            User customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
			WarrantyCardVM vm = new WarrantyCardVM
			{
				WarrantyCard = warrantyCard,
				Jewelry = jewelry,
				Customer = customer
			};
			return View(vm);
		}
	}
}
