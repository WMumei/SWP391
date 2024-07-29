
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	[Authorize()]
	public class JewelryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public JewelryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Edit(int id)
		{
			var jewelry = _unitOfWork.Jewelry.Get(p => p.Id == id, includeProperties: "BaseDesign,ProductionRequest");
			if (jewelry == null)
			{
				return NotFound();
			}
			return View(jewelry);
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Edit(Jewelry jewelry, int? redirectRequest)
		{

			Jewelry dbJ = _unitOfWork.Jewelry.Get(j => j.Id == jewelry.Id);
			dbJ.Description = jewelry.Description;
			dbJ.Name = jewelry.Name;
			_unitOfWork.Jewelry.Update(dbJ);
			_unitOfWork.Save();
			if (redirectRequest is not null)
				return RedirectToAction(nameof(RequestIndex), new { reqId = redirectRequest });
			return RedirectToAction(nameof(Edit));
		}

		[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
		//public IActionResult Index()
		//{

		//	List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns").ToList();
		//	bool checkStatus = jewelries != null && jewelries.Exists(r => r.Status == SD.StatusCancelled);
		//	CheckJewelryVM checkJewelryVM = new CheckJewelryVM()
		//	{
		//		Jewelries = jewelries,
		//		checkStatus = checkStatus
		//	};
		//	return View(checkJewelryVM);
		//}
		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(Jewelry obj)
		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(j => j.Id == obj.ProductionRequestId, includeProperties: "Customer");
			obj.CreatedAt = DateTime.Now;
			obj.CustomerId = productionRequest.CustomerId;
			//obj.ProductionRequest.Address = productionRequest.Address;
			_unitOfWork.Jewelry.Add(obj);
			_unitOfWork.Save();
			return RedirectToAction("Index");
			//return View(new Jewelry { ProductionRequestId = obj.ProductionRequestId});
		}
		[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
		public IActionResult Index()
		{
			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns,WarrantyCard").ToList();
			return View(jewelries);
		}

		public IActionResult RequestIndex(int reqId)
		{

			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == reqId, includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns,ProductionRequest,WarrantyCard").ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (jewelries.Count == 0)
			{
				return NotFound();
            }
			if (User.IsInRole(SD.Role_Customer))
			{
				if (jewelries.First().ProductionRequest.CustomerId != userId)
				{
					return NotFound();
				}
			}

			HttpContext.Session.Remove(SessionConst.MATERIAL_LIST_KEY);
			HttpContext.Session.Remove(SessionConst.GEMSTONE_LIST_KEY);
			HttpContext.Session.Remove(SessionConst.DELETED_GEMSTONE_LIST_KEY);
			return View(jewelries);
		}

		[Authorize(Roles = SD.Role_Production)]
		public IActionResult Manufacture(int jId, int? redirectRequest)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == jId, tracked: true);
			if (jewelry is null)
			{
				return NotFound();
			}
			if (jewelry.Status != SD.StatusDesignApproved)
			{
				TempData["Error"] = "Jewelry Design has not been approved";
			}
			else
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

				jewelry.ProductionStaffId = userId;
				jewelry.Status = SD.StatusManufaturing;
				_unitOfWork.Jewelry.Update(jewelry);

				_unitOfWork.Save();
				TempData["Success"] = "Started Manufacturing Jewelry!";
			}
			if (redirectRequest is not null)
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
			return RedirectToAction("Index");
		}

		[Authorize(Roles = SD.Role_Production)]
		public IActionResult Complete(int jId, int? redirectRequest)
		{
			try
			{

				Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == jId, tracked: true);
				if (jewelry is null)
				{
					TempData["error"] = "Jewelry not found";
					return RedirectToAction("Index", "Home");
				}
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				jewelry.ProductionStaffId = userId;

				jewelry.Status = SD.StatusManufactured;
				_unitOfWork.Jewelry.Update(jewelry);
				_unitOfWork.Save();

				ProductionRequest request = _unitOfWork.ProductionRequest.Get(p => p.Id == jewelry.ProductionRequestId, includeProperties: "Jewelries", tracked: true);
				bool completed = true;
				foreach (var j in request.Jewelries)
				{
					if (j.Status != SD.StatusManufactured)
					{
						completed = false;
						break;
					}
				}
				if (completed)
					request.Status = SD.StatusAllManufactured;
				//_unitOfWork.ProductionRequest.Update(request);
				_unitOfWork.Save();
				TempData["Success"] = "Jewelry Completed!";
				if (redirectRequest is not null)
					return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
				return RedirectToAction("Index", "Home");
			}
			catch (Exception e)
			{
				return RedirectToAction("Index", "Home");
			}
		}

        //public IActionResult Deliver(int id, int? redirectRequest)
        //{
        //	Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
        //	//User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
        //	//if (jewelry is not null)
        //	//{
        //	//    jewelry.ProductionStaffId = productionStaff.Id;
        //	//    jewelry.Status = $"Currently manufacturing by {productionStaff.Name}";
        //	//}
        //	jewelry.Status = SD.StatusDelivered;
        //	_unitOfWork.Save();
        //	if (redirectRequest is not null)
        //		return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
        //	return RedirectToAction("Index");
        //}

        //public IActionResult Create(int reqId)
        //{
        //	var productionRequest = _unitOfWork.ProductionRequest.Get(pr => pr.Id == reqId, includeProperties: "Jewelries");
        //	if (productionRequest == null)
        //	{
        //		return NotFound();
        //	}
        //	// Check if all jewelry has been created
        //	if (productionRequest.Quantity <= productionRequest.Jewelries.Count)
        //	{
        //		TempData["Error"] = "All Jewelry has been created";
        //		return RedirectToAction("Index");
        //	}
        //	Jewelry obj = new Jewelry
        //	{
        //		ProductionRequestId = reqId,
        //		Status = SD.StatusProcessing,
        //		ProductionRequest = productionRequest
        //	};
        //	return View(obj);
        //}

        //[HttpJewelry]
        //[Authorize(Roles = SD.Role_Sales + "," + SD.Role_Admin)]
        //public IActionResult Create(Jewelry obj)
        //{
        //	//if (ModelState.IsValid) { 

        //	ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(pr => pr.Id == obj.ProductionRequestId);
        //	// Check if all jewelry has been created
        //	if (productionRequest.Quantity <= productionRequest.Jewelries.Count)
        //	{
        //		TempData["Error"] = "All Jewelry has been created";
        //		return RedirectToAction("Index");
        //	}
        //	obj.CreatedAt = DateTime.Now;
        //	_unitOfWork.Jewelry.Add(obj);
        //	_unitOfWork.Save();
        //	// If all jewelry has been created, redirect to index
        //	if (productionRequest.Quantity > productionRequest.Jewelries.Count)
        //	{
        //		return RedirectToAction("Create", new { reqId = obj.ProductionRequestId });
        //	}
        //	return RedirectToAction("Index");
        //	//         }
        //	//         else
        //	//         {
        //	//             TempData["Error"] = "Error creating Jewelry";
        //	//             return RedirectToAction("Create", new { reqId = obj.ProductionRequestId });
        //	//}
        //}

        //public IActionResult Create(int reqId)
        //{
        //	var productionRequest = _unitOfWork.ProductionRequest.Get(pr => pr.Id == reqId, includeProperties: "Jewelries");
        //	if (productionRequest == null)
        //	{
        //		return NotFound();
        //	}
        //	Jewelry obj = new Jewelry
        //	{
        //		ProductionRequestId = reqId,
        //		CustomerId = productionRequest.CustomerId,
        //		ProductionRequest = productionRequest
        //	};
        //	return View(obj);
        //}
    }
}
