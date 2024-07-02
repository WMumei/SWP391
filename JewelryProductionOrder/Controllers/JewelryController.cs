using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
    public class JewelryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JewelryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Create(int reqId)
        {
            var productionRequest = _unitOfWork.ProductionRequest.Get(pr => pr.Id == reqId, includeProperties:"Jewelries");
            if (productionRequest == null)
            {
                return NotFound();
            }
            Jewelry obj = new Jewelry
            {
                ProductionRequestId = reqId,
                ProductionRequest = productionRequest
            };
            return View(obj);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Create(Jewelry obj)
        {
            obj.CreatedAt = DateTime.Now;
            _unitOfWork.Jewelry.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Jewelry created successfully";
            return RedirectToAction("Index");
            //return View(new Jewelry { ProductionRequestId = obj.ProductionRequestId});
        }
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
        public IActionResult Index()
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(includeProperties:"MaterialSet,QuotationRequests,JewelryDesigns").ToList();
			return View(jewelries);
        }

        public IActionResult RequestIndex(int reqId)
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == reqId, includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns,ProductionRequest").ToList();
            return View(jewelries);
        }

        public IActionResult StartManufacture(int id)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			if (jewelry is not null)
			{
				jewelry.ProductionStaffId = userId;
				jewelry.Status = $"Currently manufacturing";
			}
			_unitOfWork.Save();
			TempData["success"] = "Progess updated";
			return RedirectToAction("Index");
		}

        public IActionResult Complete(int id)
        {
            Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
            //User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
            //if (jewelry is not null)
            //{
            //    jewelry.ProductionStaffId = productionStaff.Id;
            //    jewelry.Status = $"Manufactured by {productionStaff.Name}";
            //}
            jewelry.Status = "Manufactured";
            _unitOfWork.Save();
			TempData["success"] = "Progress updated";
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
            jewelry.Status = "Delivered";
            _unitOfWork.Save();
			TempData["success"] = "Progress updated";
			return RedirectToAction("Index");
        }
    }
}
