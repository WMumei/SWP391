using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Options;
using Models.Repositories.Repository.IRepository;
using Stripe;
using Stripe.Checkout;
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

		[Authorize]
		public IActionResult Index()
		{
			List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAll(includeProperties: "Customer,Jewelries,SalesStaff").ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (User.IsInRole(SD.Role_Customer))
			{
				obj = obj.Where(obj => obj.CustomerId == userId).ToList();
			}
			if (User.IsInRole(SD.Role_Sales))
			{
				obj = obj.Where(obj => obj.SalesStaffId == userId).ToList();
			}

			return View(obj);
		}


		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Deliver(int id)
		
		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Customer,Jewelries");
			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "WarrantyCard").ToList();

			_unitOfWork.Save();
			return View("Deliver", productionRequest);
		}
		public IActionResult Delivered(int id)

		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Customer,Jewelries",tracked:true);
			
			productionRequest.Status = SD.StatusDelivered;
			TempData["success"] = "Order is delivering";
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
		public IActionResult CustomerViewDelivery(int id)
		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries", tracked: true);

			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer,SalesStaff,ProductionRequest").ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			return View("CustomerViewDelivery", jewelries);
		}
		//[Authorize(Roles = SD.Role_Customer)]
		public IActionResult Confirm(int id)
		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries");
			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(jewelry => jewelry.ProductionRequestId == productionRequest.Id, includeProperties: "Customer,ProductionRequest,WarrantyCard").ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			productionRequest.CustomerId = userId;

			foreach (var jewelry in jewelries)
			{
				if (jewelry is not null)
				{

					jewelry.Status = SD.StatusDelivered;
					jewelry.ProductionRequest.Status = SD.StatusRequestDone;
					
					Delivery delivery = new Delivery()
					{
						//SalesStaffId = userId,
						CustomerId = jewelry.CustomerId,
						JewelryId = jewelry.Id,
						WarrantyCardId = jewelry.WarrantyCard.Id,
						DeliveredAt = DateTime.Now,
						SalesStaffId = userId
					};

					_unitOfWork.Jewelry.Update(jewelry);
					_unitOfWork.Delivery.Add(delivery);
				}
			}
			
			TempData["success"] = "Order is delivered successfully";
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
        public IActionResult CancelRequest(int id)
        {
            ProductionRequest req = _unitOfWork.ProductionRequest.Get(r => r.Id == id && r.Status != SD.StatusRequestDone 
			&& r.Status != SD.StatusAllManufactured && r.Status != SD.StatusConfirmDelivered && r.Status != SD.StatusPaid,tracked:true);
			if (req is null) return NotFound();
            
                req.Status = SD.StatusCancelled;
                _unitOfWork.Save();
           

			List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == id).ToList();
			if (jewelries.Count > 0)
			{
				foreach (Jewelry jewelry in jewelries)
				{
					if (jewelry.Status != SD.StatusManufaturing && jewelry.Status != SD.StatusManufactured)
					{
						MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.JewelryId == jewelry.Id);
						MaterialSetMaterial materialSetMaterial = _unitOfWork.MaterialSetMaterial.Get(m => m.MaterialSetId == materialSet.Id);
						if (materialSet != null)
						{
							List<Gemstone> gemstones = _unitOfWork.Gemstone.GetAll(g => g.MaterialSetId == materialSet.Id).ToList();
							foreach (var gem in gemstones)
							{
								gem.Status = SD.StatusAvailable;
								_unitOfWork.Gemstone.Update(gem);
								_unitOfWork.Save();
							}
							_unitOfWork.MaterialSetMaterial.Remove(materialSetMaterial);
							_unitOfWork.Save();

						}
					}
					QuotationRequest QuoReq = _unitOfWork.QuotationRequest.Get(qr => qr.JewelryId == jewelry.Id);
					if (QuoReq != null)
					{
						QuoReq.Status = SD.StatusCancelled;
						_unitOfWork.QuotationRequest.Update(QuoReq);
						_unitOfWork.Save();
					}
					List<JewelryDesign> jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(j => j.JewelryId == jewelry.Id).ToList();
					if (jewelryDesigns.Count > 0)
					{
						foreach (JewelryDesign JewelryDesign in jewelryDesigns)
						{
							JewelryDesign.Status = SD.StatusCancelled;
							_unitOfWork.JewelryDesign.Update(JewelryDesign);
							_unitOfWork.Save();
						}
					}

					jewelry.Status = SD.StatusCancelled;
					_unitOfWork.Jewelry.Update(jewelry);
					_unitOfWork.Save();
				}
			}
			return RedirectToAction("Index");
		}

		#region Payment
		public IActionResult Payment(int pId)
		{
			//var domain = "https://localhost:7133/";
			var domain = Request.Scheme + "://" + Request.Host.Value + "/";

			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == pId);

			var options = new SessionCreateOptions
			{
				SuccessUrl = domain + $"ProductionRequest/OrderConfirmation/{productionRequest.Id}",
				CancelUrl = domain + "ProductionRequest/Index",
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
			};
			var jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == pId).ToList();

			if (jewelries.Count() == 0)
			{
				return BadRequest("No jewelries found for the given production request.");
			}

			foreach (var jewelry in jewelries)
			{
				//var quotations = _unitOfWork.QuotationRequest.GetAll(q => q.JewelryId == jewelry.Id && q.Status == SD.CustomerApproved).ToList();
				var quotation = _unitOfWork.QuotationRequest.Get(q => q.JewelryId == jewelry.Id && q.Status == SD.CustomerApproved);
				if (quotation is null)
				{
					return Json(new { success = false, message = $"Not found any approved quotation for the jewelry {jewelry.Id},{jewelry.Name} in the request" });
				}
				else
				{
					var sessionLineItem = new SessionLineItemOptions
					{
						Quantity = 1,
						PriceData = new SessionLineItemPriceDataOptions
						{
							UnitAmount = (long)(quotation.TotalPrice * 100),
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
			_unitOfWork.Save();
			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);

		}


		public IActionResult OrderConfirmation(int id)
		{
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(u => u.Id == id, includeProperties: "Jewelries");
			var service = new SessionService();
			Session session = service.Get(productionRequest.SessionId);
			if (session.PaymentStatus.ToLower() == "paid")
			{
				_unitOfWork.ProductionRequest.UpdateStripePaymentId(id, session.Id, session.PaymentIntentId);
				_unitOfWork.ProductionRequest.UpdateStatus(id, SD.StatusAllQuotationApproved, SD.StatusPaid);
				_unitOfWork.Save();
			}
			TempData["success"] = "Paid!"; 
			return RedirectToAction("Index");
		}


		#endregion


		#region Old
		//      public IActionResult CancelRequest(int id)
		//{
		//	ProductionRequest req = _unitOfWork.ProductionRequest.Get(r => r.Id == id);
		//	if (req is not null)
		//	{
		//		req.Status = SD.StatusCancelled;
		//		_unitOfWork.Save();
		//	}

		//List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == id).ToList();
		//if (jewelries.Count > 0)
		//{
		//    foreach (Jewelry jewelry in jewelries)
		//    {
		//        jewelry.Status = SD.StatusCancelled;
		//        QuotationRequest QuoReq = _unitOfWork.QuotationRequest.Get(qr => qr.JewelryId == jewelry.Id);
		//        if (QuoReq != null)
		//        {
		//            QuoReq.Status = SD.StatusCancelled;
		//        }
		//        List<JewelryDesign> jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(j => j.JewelryId == jewelry.Id).ToList();
		//        if (jewelryDesigns.Count > 0)
		//        {
		//            foreach (JewelryDesign JewelryDesign in jewelryDesigns)
		//            {
		//                JewelryDesign.Status = SD.StatusCancelled;
		//            }
		//        }
		//    }
		//}
		//	return RedirectToAction("Index");
		//}

		//public bool checkPayment(int pId)
		//{
		//	List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll(j => j.ProductionRequestId == pId).ToList();

		//	foreach (Jewelry jewelry in jewelries)
		//	{
		//		List<QuotationRequest> quotations = _unitOfWork.QuotationRequest.GetAll(q => q.JewelryId == jewelry.Id).ToList();

		//		bool hasApprovedQuotation = quotations.Any(q => q.Status == SD.CustomerApproved);

		//		if (!hasApprovedQuotation)
		//		{
		//			return false;
		//		}
		//	}

		//	return true;
		//}
		//[HttpPost]
		//[Authorize(Roles = SD.Role_Sales)]
		//public IActionResult TakeRequest(int id)
		//{
		//	ProductionRequest req = _unitOfWork.ProductionRequest.Get(req => req.Id == id);
		//	var claimsIdentity = (ClaimsIdentity)User.Identity;
		//	var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
		//	if (req is not null)
		//	{
		//		req.SalesStaffId = userId;
		//	}
		//	_unitOfWork.Save();
		//	return RedirectToAction("Index");
		//}

//		DoubleOrder {
//			ProductionRequest request = _unitOfWork.ProductionRequest.Get(req => req.CustomerId == userId && req.Status == SD.StatusAllQuotationApproved);
//			if (request is not null)
//			{
//				var service = new SessionService();
//				if (request.SessionId is null)
//				{
//					return View("Index", obj);
//	}
//	Session session = service.Get(request.SessionId);
//				if (session.PaymentStatus.ToLower() == "paid")
//				{
//					OrderConfirmation(request.Id);
//}
//			}
//}
		#endregion

	}
}
