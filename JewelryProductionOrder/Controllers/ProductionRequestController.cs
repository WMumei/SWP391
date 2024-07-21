using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Models.Repositories.Repository.IRepository;
using Stripe.Checkout;
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
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = SD.Role_Sales)]
        public IActionResult Deliver(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id,includeProperties:"Customer,Jewelries");
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "WarrantyCard").ToList();
            User customer = _unitOfWork.User.Get(u => u.Id == productionRequest.CustomerId);


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;



            _unitOfWork.Save();
            return View("Deliver", productionRequest);
        }
        public IActionResult Delivered(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id);
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "WarrantyCard").ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            User customer = _unitOfWork.User.Get(u => u.Id == productionRequest.CustomerId);
            productionRequest.Status = SD.StatusRequestDone;
			_unitOfWork.ProductionRequest.Update(productionRequest);
            _unitOfWork.Save();
			foreach (var jewelry in jewelries)
			{
				//jewelry.SalesStaffId = userId;
				jewelry.Status = SD.StatusDelivered;
				Delivery delivery = new Delivery()
				{
					//SalesStaffId = userId,
					CustomerId = customer.Id,
					JewelryId = jewelry.Id,
					WarrantyCardId = jewelry.WarrantyCard.Id,
					DeliveredAt = DateTime.Now,
					SalesStaffId = userId
				};

				_unitOfWork.Jewelry.Update(jewelry);
				_unitOfWork.Delivery.Add(delivery);
				TempData["success"] = "Order is delivered successfully";
				_unitOfWork.Save();
			}

			return RedirectToAction("Index");
        }

		public IActionResult CustomerViewDelivery(int id)
		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries,SalesStaff");
			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer,SalesStaff").ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			//var saleStaff=_unitOfWork.User.Get(u=>u.Id==userId);
               

			return View("CustomerViewDelivery", productionRequest);
		}
		//[Authorize(Roles = SD.Role_Customer)]
        public IActionResult Confirm(int id)
        {
            ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries");
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer,ProductionRequest").ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            productionRequest.CustomerId = userId;

            foreach (var jewelry in jewelries)
            {
                if (jewelry is not null)
                {

                    jewelry.Status = SD.StatusConfirmDelivered;
					jewelry.ProductionRequest.Status = SD.StatusConfirmDelivered;
                    TempData["success"] = "Confirmed Order successfully";
                }


            }
            _unitOfWork.Save();
            return RedirectToAction("CustomerView");
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

		public bool checkPayment(int pId)
		{
			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == pId).ToList();

			foreach (Jewelry jewelry in jewelries)
			{
				List<QuotationRequest> quotations = _unitOfWork.QuotationRequest.GetAll(q => q.JewelryId == jewelry.Id).ToList();

				bool hasApprovedQuotation = quotations.Any(q => q.Status == SD.CustomerApproved);

				if (!hasApprovedQuotation)
				{
					return false;
				}
			}

			return true;
		}

		public IActionResult Payment(int pId)
		{
            //var domain = "https://localhost:7133/";
            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            //var domain = "https://jpo.somee.com/";

            var options = new SessionCreateOptions
			{
				SuccessUrl = domain,
				CancelUrl = domain + "ProductionRequest/CustomerView",
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
			};

			var jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == pId).ToList();

			if (!jewelries.Any())
			{
				return BadRequest("No jewelries found for the given production request.");
			}

			foreach (var jewelry in jewelries)
			{
				//var quotations = _unitOfWork.QuotationRequest.GetAll(q => q.JewelryId == jewelry.Id && q.Status == SD.CustomerApproved).ToList();
				var quotations = _unitOfWork.QuotationRequest.GetAll(q => q.JewelryId == jewelry.Id).ToList();

				foreach (var quotation in quotations)
				{
					var sessionLineItem = new SessionLineItemOptions
					{	
						Quantity = 1,
						PriceData = new SessionLineItemPriceDataOptions
						{
							UnitAmount = (long)(quotation.TotalPrice),
							Currency = "USD",
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = jewelry.Name
							}
						},
					};
					options.LineItems.Add(sessionLineItem);
				}
			}

			var service = new SessionService();
			Session session = service.Create(options);
			_unitOfWork.ProductionRequest.UpdateStripePaymentId(pId, session.Id, session.PaymentIntentId);
			_unitOfWork.ProductionRequest.UpdateStatus(pId, SD.StatusPending, SD.StatusPaid);
			_unitOfWork.Save();
			Response.Headers.Add("Location", session.Url);

			return new StatusCodeResult(303);
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
