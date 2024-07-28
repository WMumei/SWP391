using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace SWP391.Controllers
{
	[Authorize]
	public class QuotationRequestController : Controller

	{
		private readonly IUnitOfWork _unitOfWork;

		public QuotationRequestController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index(int jId)
		{
			List<QuotationRequest> requests;
			if (User.IsInRole(SD.Role_Customer))
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				requests = _unitOfWork.QuotationRequest.GetAll(r => r.JewelryId == jId && r.CustomerId == userId && r.Status == SD.ManagerApproved, includeProperties: "Jewelry").ToList();
			}
			else if (User.IsInRole(SD.Role_Sales))
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				requests = _unitOfWork.QuotationRequest.GetAll(r => r.JewelryId == jId && r.SalesStaffId == userId, includeProperties: "Jewelry").ToList();
			}
			else if (User.IsInRole(SD.Role_Manager))
			{
				requests = _unitOfWork.QuotationRequest.GetAll(r => r.JewelryId == jId, includeProperties: "Jewelry").ToList();
			}
			else
			{
				return NotFound();
			}

			return View(requests);
		}

		public IActionResult Details(int id)
		{
			QuotationRequest request = _unitOfWork.QuotationRequest.Get(r => r.Id == id, includeProperties: "Jewelry");
			if (request is null || request.Status == SD.StatusDiscontinued) return NotFound();
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == request.MaterialSetId, includeProperties: "Gemstones,Materials,MaterialSetMaterials");
			QuotationRequestVM vm = new QuotationRequestVM
			{
				QuotationRequest = request,
				Jewelry = request.Jewelry,
				MaterialSet = materialSet
			};
			return View(vm);

		}

		public IActionResult Create(int jId, int redirectRequest)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "MaterialSet,QuotationRequests");
			if (jewelry.MaterialSet is null)
			{
				TempData["error"] = "Material Set is not ready!";
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest});
			}
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSet.Id, includeProperties: "Gemstones,Materials,MaterialSetMaterials");
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
			if (vm.QuotationRequest.LaborPrice <= 0)
			{
                TempData["error"] = "Labor Price must be > 0";
                if (redirectRequest is not null)
                    return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
            }


			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id, includeProperties: "ProductionRequest,MaterialSet");
			if (jewelry.MaterialSet is null)
			{
				TempData["error"] = "Material Set is not ready!";
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
			}

			vm.QuotationRequest.SalesStaffId = userId;
			vm.QuotationRequest.CreatedAt = DateTime.Now;
			vm.QuotationRequest.Status = SD.StatusPending;

			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == vm.MaterialSet.Id);
			vm.QuotationRequest.MaterialSetId = materialSet.Id;
			vm.QuotationRequest.JewelryId = vm.Jewelry.Id;

			vm.QuotationRequest.TotalPrice = vm.QuotationRequest.LaborPrice + materialSet.TotalPrice;

			_unitOfWork.QuotationRequest.Add(vm.QuotationRequest);
			_unitOfWork.Save();

			jewelry.ProductionRequest.Status = SD.StatusQuotationing;
			_unitOfWork.ProductionRequest.Update(jewelry.ProductionRequest);
			_unitOfWork.Save();

			DateTime vmCreatedAt = vm.QuotationRequest.CreatedAt;
			var oldRequests = _unitOfWork.QuotationRequest
				.GetAll(r => r.JewelryId == vm.Jewelry.Id && r.CreatedAt < vmCreatedAt);
				//.OrderByDescending(r => r.CreatedAt);
			foreach (var oldRequest in oldRequests)
			{
				oldRequest.Status = SD.StatusDiscontinued;
				_unitOfWork.Save();
			}
			TempData["success"] = "Created";
			//if (redirectRequest is not null)
			//	return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
			return RedirectToAction(nameof(Details), new { id = vm.QuotationRequest.Id });
		}

		[Authorize(Roles = SD.Role_Manager)]
		public IActionResult ManagerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (req.Status == SD.StatusDiscontinued) return NotFound();

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
			return RedirectToAction("Details", new { id = req.Id });
		}

		[Authorize(Roles = SD.Role_Manager)]
		public IActionResult ManagerDisapprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (req.Status == SD.StatusDiscontinued) return NotFound();

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
			return RedirectToAction("Details", new { id = req.Id });

		}

		[Authorize(Roles = SD.Role_Customer)]
		public IActionResult CustomerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (req.Status == SD.StatusDiscontinued) return NotFound();

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

			ProductionRequest request = _unitOfWork.ProductionRequest.Get(p => p.Id == jewelry.ProductionRequestId, includeProperties: "Jewelries", tracked: true);
			bool completed = true;
			foreach (var j in request.Jewelries)
			{
				if (j.Status != SD.StatusQuotationApproved)
				{
					completed = false;
					break;
				}
			}
			if (completed)
			{
				request.Status = SD.StatusAllQuotationApproved;

			}
			//_unitOfWork.ProductionRequest.Update(request);
			_unitOfWork.Save();
			TempData["Success"] = "Approved!";

			return RedirectToAction("Details", new { id = req.Id });

		}

		[Authorize(Roles = SD.Role_Customer)]
		public IActionResult CustomerDisapprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (req.Status == SD.StatusDiscontinued) return NotFound();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (req is not null)
			{
				req.CustomerId = userId;
				req.Status = SD.CustomerDisapproved;
			}
			_unitOfWork.QuotationRequest.Update(req);
			_unitOfWork.Save();
			TempData["success"] = "Disapproved!";
			return RedirectToAction("Details", new { id = req.Id });

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
		[Authorize(Roles = $"{SD.Role_Manager},{SD.Role_Customer},{SD.Role_Sales}")]
		public IActionResult ViewAll(int jId)
		{
			var quotationRequests = _unitOfWork.QuotationRequest.GetAll(r => r.JewelryId == jId, includeProperties: "Jewelry").ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (User.IsInRole(SD.Role_Customer))
			{
				quotationRequests = quotationRequests.Where(r => r.Status == SD.ManagerApproved || r.Status == SD.CustomerApproved || r.Status == SD.StatusPaid).ToList();
			}
			/*else if(User.IsInRole(SD.Role_Sales))
			{
				quotationRequests = quotationRequests.Where(r => r.SalesStaffId == userId).ToList();
			}*/

			return View(quotationRequests);
		}

	}
}
