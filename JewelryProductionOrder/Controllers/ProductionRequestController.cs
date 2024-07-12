using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;
using System.Security.Cryptography;

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
        

        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Design},{SD.Role_Production}")]
        public IActionResult Index()
        {
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAll(includeProperties: "Customer,Jewelries").ToList();
            return View(obj);
        }

        public IActionResult CustomerView()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAll(req => req.CustomerId == userId, includeProperties: "Customer,Jewelries").ToList();
            return View("Index", obj);
        }

        //[HttpPost]
        [Authorize(Roles = SD.Role_Sales)]
        //[HttpPost]
        /*[Authorize(Roles = SD.Role_Sales)]
        public IActionResult CustomerView()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAll(req => req.CustomerId == userId, includeProperties: "Customer,Jewelries").ToList();
            return View("Index", obj);
        }*/

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
                req.SalesStaffId = userId;
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Deliver(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id);
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer,WarrantyCard").ToList();
            User customer = _unitOfWork.User.Get(u => u.Id == productionRequest.CustomerId);
          
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            //Delivery delivery = _unitOfWork.Delivery.Get(u => u.CustomerId == customer.Id, includeProperties: "Customer, Jewelries, WarrantyCard");
            

            foreach (var jewelry in jewelries)
            {
                    
                    jewelry.SalesStaffId = userId;
                    
                    jewelry.Status = "Delivering";
                    jewelry.ProductionRequest.Status = "Delivering";
                    jewelry.ProductionRequest.Address = productionRequest.Address;
               /* Delivery delivery = new()
                {
                    SalesStaffId = userId,
                    Customer = customer,

                    Jewelry = jewelry,

                    WarrantyCard = jewelry.WarrantyCard,
                        DeliveredAt = DateTime.Now
                    };
               */
  
                    //jewelry.ProductionRequest = productionRequest;
                    //customer.PhoneNumber = productionRequest.Phone
                
                //productionRequest.Address = customer.Address;

                //productionRequest.Jewelries = jewelries;
                
            }
           
            _unitOfWork.Save();
            return View("Deliver", productionRequest);
        }
        public IActionResult Delivered(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id);
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer,WarrantyCard").ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            productionRequest.SalesStaffId = userId;
            User customer = _unitOfWork.User.Get(u => u.Id == productionRequest.CustomerId);
            
            foreach (var jewelry in jewelries)
            {
                //if (jewelry is not null)
                //{
                    jewelry.SalesStaffId = userId;
                    jewelry.Status = "Delivered";
                    jewelry.ProductionRequest.Status = "Delivered";

                  
                    Delivery delivery = new Delivery()
                    {
                        SalesStaffId = userId,
                        CustomerId = customer.Id,

                        JewelryId = jewelry.Id,

                        WarrantyCardId = jewelry.WarrantyCard.Id,
                        DeliveredAt = DateTime.Now
                    };
                    delivery.WarrantyCardId = jewelry.WarrantyCard.Id;
                    delivery.JewelryId = jewelry.Id;
                    delivery.CustomerId = customer.Id;
                    delivery.SalesStaffId = userId;
                    
                    _unitOfWork.Delivery.Add(delivery);
                    _unitOfWork.Save();

                //}


            }
            
            return RedirectToAction("Index");
        }

        public IActionResult CustomerViewDelivery(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries");
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer").ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            
            return View("CustomerViewDelivery", productionRequest);
        }
        public IActionResult Confirm(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries");
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer").ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            productionRequest.CustomerId = userId;

            foreach (var jewelry in jewelries)
            {
                if (jewelry is not null)
                {
                    
                    jewelry.Status = "Confirmed";
                    jewelry.ProductionRequest.Status = "Confirmed";
                   
                }


            }
            _unitOfWork.Save();
            return RedirectToAction("CustomerView");
        }
    }
		public IActionResult CancelRequest(int id)
		{
			ProductionRequest req = _unitOfWork.ProductionRequest.Get(r => r.Id == id);
			if (req is not null)
			{
				req.Status = SD.StatusCancelled;
				_unitOfWork.Save();
			}

			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == id).ToList();
			if (jewelries.Count > 0)
			{
				foreach (Jewelry jewelry in jewelries)
				{
					jewelry.Status = SD.StatusCancelled;
					QuotationRequest QuoReq = _unitOfWork.QuotationRequest.Get(qr => qr.JewelryId == jewelry.Id);
					if (QuoReq != null)
					{
						QuoReq.Status = SD.StatusCancelled;
					}
					List<JewelryDesign> jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(j => j.JewelryId == jewelry.Id).ToList();
					if (jewelryDesigns.Count > 0)
					{
						foreach (JewelryDesign JewelryDesign in jewelryDesigns)
						{
							JewelryDesign.Status = SD.StatusCancelled;
						}
					}
				}
			}
			return RedirectToAction("Index");
		}

		//public IActionResult Create()
		//{
		//    return View();
		//}

		//[HttpPost]
		//public IActionResult Create(ProductionRequest obj)
		//{
		//    obj.CreatedAt = DateTime.Now;

		//    ShoppingCartVM ShoppingCartVM = new ShoppingCartVM
		//    {
		//        ProductionRequest = obj,
		//        Customer = new User()
		//    };
		//    return View("Checkout", ShoppingCartVM);
		//}
		//public IActionResult Checkout()
		//{
		//    var claimsIdentity = (ClaimsIdentity)User.Identity;
		//    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
		//    ShoppingCartVM ShoppingCartVM = new ShoppingCartVM
		//    {
		//        ProductionRequest = new ProductionRequest { 
		//            //Quantity = 1 
		//        },
		//        Customer = _unitOfWork.User.Get(User => User.Id == userId)
		//    };
		//    return View(ShoppingCartVM);
		//}

		//[HttpPost]
		//public IActionResult Checkout(ShoppingCartVM ShoppingCartVM)
		//{
		//    var claimsIdentity = (ClaimsIdentity)User.Identity;
		//    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
		//    ShoppingCartVM.ProductionRequest.CustomerId = userId;
		//    ShoppingCartVM.ProductionRequest.Address = ShoppingCartVM.Customer.Address;
		//    ShoppingCartVM.ProductionRequest.CreatedAt = DateTime.Now;
		//    _unitOfWork.ProductionRequest.Add(ShoppingCartVM.ProductionRequest);
		//    _unitOfWork.Save();
		//    return RedirectToAction("CustomerView");
		//}
	}
}
