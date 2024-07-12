using Azure.Core;
using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
			bool checkStatus = requests != null && requests.Exists(r => r.Status == SD.StatusPending);
			bool checkCancel = requests != null && requests.Exists(r => r.Status == SD.StatusCancelled);
			CheckQuotationVM vm = new CheckQuotationVM
			{
				QuotationRequests = requests,
				checkStatus = checkStatus,
				checkCancel = checkCancel
			};
			return View(vm);
		}

		// Get all quotation of a jewelry
		public IActionResult JewelryView(int jId)
		{
			List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll(r => r.JewelryId == jId, includeProperties: "Jewelry").ToList();
			if (requests is null) return NotFound();

			return View("Index", requests);
		}

		public IActionResult Details(int jId)
		{
			QuotationRequest request = _unitOfWork.QuotationRequest.Get(r => r.JewelryId == jId, includeProperties: "Jewelry");
			if (request is null) return NotFound();
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == request.Jewelry.MaterialSetId, includeProperties: "Gemstones,Materials,MaterialSetMaterials");
			QuotationRequestVM vm = new QuotationRequestVM
			{
				QuotationRequest = request,
				Jewelry = request.Jewelry,
				MaterialSet = materialSet
			};
			return View(vm);

		}

		public IActionResult Create(int jId)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties: "Gemstones,Materials,MaterialSetMaterials");
			QuotationRequestVM vm = new QuotationRequestVM
			{
				Jewelry = jewelry,
				QuotationRequest = new QuotationRequest { },
				MaterialSet = materialSet
			};
			return View(vm);
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(QuotationRequestVM vm, int? redirectRequest)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			vm.QuotationRequest.SalesStaffId = userId;
			vm.QuotationRequest.CreatedAt = DateTime.Now;
			vm.QuotationRequest.Status = SD.StatusPending;
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == vm.MaterialSet.Id);
			vm.QuotationRequest.MaterialSetId = materialSet.Id;
			vm.QuotationRequest.JewelryId = vm.Jewelry.Id;
			vm.QuotationRequest.TotalPrice = vm.QuotationRequest.LaborPrice + materialSet.TotalPrice;
			_unitOfWork.QuotationRequest.Add(vm.QuotationRequest);
			_unitOfWork.Save();

			QuotationRequest oldRequest = _unitOfWork.QuotationRequest.Get(r => r.Id < vm.QuotationRequest.Id
			&& (r.Status == SD.StatusPending));
			if (oldRequest is not null)
			{
				oldRequest.Status = SD.StatusDiscontinued;
				_unitOfWork.Save();
			}
			if (redirectRequest is not null)
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
			return RedirectToAction("Index", new { jId = vm.Jewelry.Id });
		}
		[Authorize(Roles = SD.Role_Manager)]
		public IActionResult ManagerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (req is null)
			{
				return NotFound();
			}
				req.ManagerId = userId;
				req.Status = SD.ManagerApproved;
			_unitOfWork.QuotationRequest.Update(req);
				_unitOfWork.Save();
				TempData["Success"] = "Approved!";
			return RedirectToAction("Details", new { jId = req.JewelryId });
		}

		[Authorize(Roles = SD.Role_Manager)]
		public IActionResult ManagerDisapprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (req is null)
			{
				return NotFound();
			}
			req.ManagerId = userId;
			req.Status = SD.ManagerDisapproved;
			_unitOfWork.QuotationRequest.Update(req);
			_unitOfWork.Save();
			TempData["Success"] = "Disapproved!";
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
				req.Status = SD.CustomerApproved;
			}
			_unitOfWork.QuotationRequest.Update(req);
			_unitOfWork.Save();

			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == req.JewelryId);
			jewelry.Status = SD.StatusQuotationApproved;
			_unitOfWork.Jewelry.Update(jewelry);
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
				req.Status = SD.CustomerDisapproved;
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
