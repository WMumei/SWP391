using Azure.Core;
using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Repositories.Repository;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SWP391.Controllers
{
    public class QuotationRequestController : Controller

    {
		private readonly IUnitOfWork _unitOfWork;
		public QuotationRequestController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
        public IActionResult Index(int jId)
        {
            List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll().Where(r => r.JewelryId == jId).ToList();
            bool checkStatus = requests != null && requests.Exists(r => r.Status == "Pending");
            bool checkCancel = requests != null && requests.Exists(r => r.Status == "Canceled");
            CheckQuotationVM vm = new CheckQuotationVM
            {
                QuotationRequests = requests,
                checkStatus = checkStatus,
				checkCancel = checkCancel
            };
            return View(vm);
        }

        public IActionResult Details(int jId, bool checkRedirect)
        {
			if (checkRedirect is false)
			{
                QuotationRequest request = _unitOfWork.QuotationRequest.Get(r => r.Id == jId);
                Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == request.JewelryId, includeProperties: "MaterialSet");
                MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties: "Gemstones,Materials");
                QuotationRequestVM vm = new QuotationRequestVM
                {
                    QuotationRequest = request,
                    Jewelry = jewelry,
                    MaterialSet = materialSet
                };
                return View(vm);
            }
			else
			{
				QuotationRequest request = _unitOfWork.QuotationRequest.Get(r => r.JewelryId == jId);
				Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "MaterialSet");
				MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties: "Gemstones,Materials");
				QuotationRequestVM vm = new QuotationRequestVM
				{
					QuotationRequest = request,
					Jewelry = jewelry,
					MaterialSet = materialSet
				};
				return View(vm);
			}
        }

        public IActionResult Create(int jId)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties: "Gemstones,Materials");
			QuotationRequestVM vm = new QuotationRequestVM
			{
				Jewelry = jewelry,
				QuotationRequest = new QuotationRequest { },
				MaterialSet = jewelry.MaterialSet
			};
			return View(vm);
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(QuotationRequestVM vm)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			vm.QuotationRequest.SalesStaffId = userId;
			vm.QuotationRequest.CreatedAt = DateTime.Now;
			vm.QuotationRequest.Status = "Pending";
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == vm.MaterialSet.Id);
			vm.QuotationRequest.MaterialSetId = materialSet.Id;
			vm.QuotationRequest.JewelryId = vm.Jewelry.Id;
			vm.QuotationRequest.TotalPrice = vm.QuotationRequest.LaborPrice + materialSet.TotalPrice;
			_unitOfWork.QuotationRequest.Add(vm.QuotationRequest);
			_unitOfWork.Save();

			QuotationRequest oldRequest = _unitOfWork.QuotationRequest.Get(r => r.Id < vm.QuotationRequest.Id
			&& (r.Status == "Pending"));
			if (oldRequest is not null)
			{
				oldRequest.Status = "Discontinue";
				_unitOfWork.Save();
			}

			return RedirectToAction("Index", new { jId = vm.Jewelry.Id });
		}
		[Authorize(Roles = SD.Role_Manager)]
		public IActionResult ManagerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (req is not null)
			{
				req.ManagerId = userId;
				req.Status = $"Approved by Manager";
			}
			_unitOfWork.Save();
			return RedirectToAction("Details", new { jId = req.JewelryId});
		}

        [Authorize(Roles = SD.Role_Manager)]
		public IActionResult ManagerDisapprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (req is not null)
			{
				req.ManagerId = userId;
				req.Status = $"Disapproved by Manager";
			}
			_unitOfWork.Save();
			return RedirectToAction("Details", new { jId = req.JewelryId });
		}

        [Authorize(Roles = SD.Role_Customer)]
		public IActionResult CustomerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (req is not null)
			{
				req.CustomerId = userId;
				req.Status = $"Approved by Customer";
			}
			_unitOfWork.Save();
            return RedirectToAction("Details", new { jId = req.JewelryId });
		}

        [Authorize(Roles = SD.Role_Customer)]
        public IActionResult CustomerDisapprove(int id)
        {
            QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (req is not null)
            {
                req.CustomerId = userId;
                req.Status = $"Disapproved by Customer";
            }
            _unitOfWork.Save();
            return RedirectToAction("Details", new { jId = req.JewelryId });
        }
        
        //public bool CheckQuotationStatus(int jId)
        //{
        //    QuotationRequest request = _unitOfWork.QuotationRequest.Get(r => r.JewelryId == jId);
        //    CheckStatusVM vm = new CheckStatusVM
        //    {
        //        checkStatus = (request != null && request.Status == "Pending")
        //    };
        //    return vm.checkStatus;
        //}

		
        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    QuotationRequest quorequest = _unitOfWork.QuotationRequest.Find(id);
        //    if (quorequest == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.QuotationRequest.Remove(quorequest);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("Index");

        //}
    }
}
