using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                ProductionRequest = new ProductionRequest { Quantity = 1, Address = ""},
                Customer = _unitOfWork.User.Get(User => User.Id == userId),
                //Address
            };
            return View(orderVM);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderVM orderVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var customer= _unitOfWork.User.Get(User => User.Id == userId);
            //var productionRequest = _unitOfWork.ProductionRequest.Get(U => U.Id == orderVM.ProductionRequest.Id);
            //_unitOfWork.ProductionRequest.Add(customer);
            orderVM.ProductionRequest.CustomerId = userId;
        
            //customer.Address is null
            orderVM.ProductionRequest.CreatedAt = DateTime.Now;
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
        public IActionResult Deliver(int id)
        {
            Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == jewelry.ProductionRequestId, includeProperties: "Jewelries");
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            User customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);

            productionRequest.CustomerId = customer.Id;
            if (jewelry is not null)
            {
                jewelry.SalesStaffId = userId;
                jewelry.Status = "Delivering";
                //jewelry.ProductionRequest = productionRequest;
                //customer.PhoneNumber = productionRequest.Phone
            }
            _unitOfWork.Save();
            return View("Deliver");
        }
    }
}
