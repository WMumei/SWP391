using JewelryProductionOrder.Controllers;
using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace SWP391.Controllers
{
    public class ProductionRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public ProductionRequestController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(ProductionRequest obj)
        //{
        //    obj.CreatedAt = DateTime.Now;

        //    OrderVM orderVM = new OrderVM
        //    {
        //        ProductionRequest = obj,
        //        Customer = new User()
        //    };
        //    return View("Checkout", orderVM);
        //}
        public IActionResult Checkout()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            OrderVM orderVM = new OrderVM
            {
                ProductionRequest = new ProductionRequest { Quantity = 1},
                Customer = _unitOfWork.User.Get(User => User.Id == userId)
            };
            return View(orderVM);
        }
        [HttpPost]
        public IActionResult Checkout(OrderVM orderVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            orderVM.ProductionRequest.CustomerId = userId;
            orderVM.ProductionRequest.Address = orderVM.Customer.Address;
            orderVM.ProductionRequest.CreatedAt = DateTime.Now;
            orderVM.ProductionRequest.Status = "Processing";
			_unitOfWork.ProductionRequest.Add(orderVM.ProductionRequest);
            _unitOfWork.Save();
            return RedirectToAction("CustomerView");
        }
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
        public IActionResult Index()
        {
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAll(includeProperties:"Customer,Jewelries").ToList();
            return View(obj);
        }

		public IActionResult CustomerView()
		{
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAll(req => req.CustomerId == userId,includeProperties: "Customer,Jewelries").ToList();
			return View("Index", obj);
		}

		//[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
        public IActionResult TakeRequest(int id)
        {
            ProductionRequest req = _unitOfWork.ProductionRequest.Get(req => req.Id == id);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (req is not null)
            {
                req.SalesStaffId = userId;
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult CancelRequest(int id)
        {
            ProductionRequest req = _unitOfWork.ProductionRequest.Get(r => r.Id == id);
            if (req is not null)
            {
                req.Status = "Canceled";
                _unitOfWork.Save();
            }
            // Call the Cancel method in JewelryController
            JewelryController jewelryController = new JewelryController(_unitOfWork);
            jewelryController.CancelJewelry(id);

            return RedirectToAction("Index");
        }
    }
}
