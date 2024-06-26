using Azure.Core;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using SWP391.Controllers;
using System.Security.Claims;
using System.Security.Cryptography;

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
            Jewelry obj = new Jewelry
            {
                ProductionRequestId = reqId,
                Status = "Processing"
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
            return RedirectToAction("Index");
            //return View(new Jewelry { ProductionRequestId = obj.ProductionRequestId});
        }
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
        public IActionResult Index()
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(includeProperties:"MaterialSet,QuotationRequests,JewelryDesigns").ToList();
            bool checkStatus = jewelries != null && jewelries.Exists(r => r.Status == "Canceled");
            CheckJewelryVM checkJewelryVM = new CheckJewelryVM()
            {
                Jewelries = jewelries,
                checkStatus = checkStatus
            };
			return View(checkJewelryVM);
        }

        public IActionResult RequestIndex(int reqId)
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == reqId, includeProperties: "MaterialSet,QuotationRequests,JewelryDesigns").ToList();

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
            return RedirectToAction("Index");
        }


        public IActionResult CancelJewelry(int reqId)
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == reqId).ToList();
            QuotationRequestController quotationRequestController = new QuotationRequestController(_unitOfWork);
            if (jewelries.Count > 0)
            {
                foreach (Jewelry jewelry in jewelries)
                {
                    jewelry.Status = "Canceled";
                    quotationRequestController.CancelQuotationRequest(jewelry.Id);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
