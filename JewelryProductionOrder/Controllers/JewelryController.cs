using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
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
            //get pro request tương ứng ra.
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == reqId, includeProperties:"Customer");
            Jewelry obj = new Jewelry
            {
                ProductionRequestId = reqId,
                CustomerId = productionRequest.CustomerId,
                ProductionRequest = productionRequest
            };
            return View(obj);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Create(Jewelry obj)
        {
            obj.CreatedAt = DateTime.Now;
            //obj.CustomerId = obj.ProductionRequest.CustomerId;
            _unitOfWork.Jewelry.Add(obj);
            // ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id);
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(j => j.Id == obj.ProductionRequestId);
           // obj.ProductionRequest.Address = productionRequest.Address;
           //there is no address column in jewelry table
            obj.CustomerId = productionRequest.CustomerId;
            obj.ProductionRequest.Address = productionRequest.Address;
            _unitOfWork.Save();
            return RedirectToAction("Index");
            //return View(new Jewelry { ProductionRequestId = obj.ProductionRequestId});
        }
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
        public IActionResult Index()
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(includeProperties:"MaterialSet,QuotationRequest,JewelryDesigns,WarrantyCard").ToList();
			return View(jewelries);
        }

        public IActionResult RequestIndex(int reqId)
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == reqId, includeProperties: "MaterialSet,QuotationRequest,JewelryDesigns,WarrantyCard").ToList();
            return View(jewelries);
        }

        public IActionResult Manufacture(int id)
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
            jewelry.Status = $"Manufactured";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        /*public IActionResult GetCustomer(int id)
        {
            Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (jewelry is not null)
            {
                jewelry.CustomerId = userId;
                jewelry.Status = $"Sending WarrantyCard";
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        */
       

        //public IActionResult Deliver(int id)
        //{
            //Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
            //User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
            //if (jewelry is not null)
            //{
            //    jewelry.ProductionStaffId = productionStaff.Id;
            //    jewelry.Status = $"Currently manufacturing by {productionStaff.Name}";
            //}
           // jewelry.Status = "Delivered";
            //_unitOfWork.Save();
            //return RedirectToAction("Index");
       // }
    }
}
