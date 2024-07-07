
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Areas.Staff.Controllers
{
	[Area("Staff")]
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
			var jewelry = _unitOfWork.Jewelry.Get(p => p.Id == id, includeProperties:"BaseDesign");
			if (jewelry == null)
			{
				return NotFound();
			}
			return View(jewelry);
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Edit(Jewelry jewelry)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Jewelry.Update(jewelry);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(jewelry);
		}

		[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
		public IActionResult Index()
		{

			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns").ToList();
			bool checkStatus = jewelries != null && jewelries.Exists(r => r.Status == SD.StatusCancelled);
			CheckJewelryVM checkJewelryVM = new CheckJewelryVM()
			{
				Jewelries = jewelries,
				checkStatus = checkStatus
			};
			return View(checkJewelryVM);
		}

		public IActionResult RequestIndex(int reqId)
		{

			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == reqId, includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns,ProductionRequest").ToList();
			return View(jewelries);
		}

		[Authorize(SD.Role_Production)]
		public IActionResult StartManufacture(int id)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


			if (jewelry is not null)
			{
				jewelry.ProductionStaffId = userId;
				jewelry.Status = SD.StatusManufaturing;
			}
			_unitOfWork.Save();
			TempData["Success"] = "Started Manufacturing Jewelry!";
			return RedirectToAction("Index");
		}
		[Authorize(SD.Role_Production)]
		public IActionResult Complete(int id)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
			//User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
			//if (jewelry is not null)
			//{
			//    jewelry.ProductionStaffId = productionStaff.Id;
			//    jewelry.Status = $"Manufactured by {productionStaff.Name}";
			//}
			jewelry.Status = SD.StatusManufactured;
			_unitOfWork.Save();
			TempData["Success"] = "Jewelry Completed!";
			return RedirectToAction("Index");
		}

		public IActionResult Deliver(int id)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
			//User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
			//if (jewelry is not null)
			//{
			//    jewelry.ProductionStaffId = productionStaff.Id;
			//    jewelry.Status = $"Currently manufacturing by {productionStaff.Name}";
			//}
			jewelry.Status = SD.StatusDelivered;
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}

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
	}
}
