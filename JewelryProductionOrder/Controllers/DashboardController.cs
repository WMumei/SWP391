using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using NuGet.Common;
using NuGet.Packaging;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace JewelryProductionOrder.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public DashboardController(IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_roleManager = roleManager;
		}
		//[Authorize(Roles = SD.Role_Sales)]
		//public async Task<ActionResult> Index()
		//{
		//	{
		//		var role = await _roleManager.FindByNameAsync("Customer");
		//		if (role == null)
		//		{
		//			return NotFound("Role not found");
		//		}

		//		var userIds = await _userManager.GetUsersInRoleAsync("Customer");
		//		if (userIds == null)
		//		{
		//			return BadRequest("Error retrieving users in role 'Customer'");
		//		}
		//		int customerCount = userIds.Count;

		//		var delivered = _unitOfWork.Jewelry.GetAll().Where(r => r.Status == "Delivered").ToList();
		//		if (delivered == null)
		//		{
		//			return NotFound("Jewelry not found");
		//		}
		//		int deliveryCount = delivered.Count;

		//		DateTime targetDate = new DateTime(2, 1, 1);
		//		List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
		//	   .Where(qr => qr.Status == "Approved" && qr.CreatedAt <= targetDate)
		//	   .ToList();

		//		List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
		//		List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

		//		ViewBag.Dates = rDates;
		//		ViewBag.Revenues = revenues;
		//		ViewBag.CustomerCount = customerCount;
		//		ViewBag.DeliveryCount = deliveryCount;

		//		return View(requests);
		//	}
		//}

		//[HttpPost]
		//[Authorize(Roles = SD.Role_Sales)]
		//public async Task<ActionResult> Index(DateTime? startDate, DateTime? endDate)
		//{
		//	{
		//		var role = await _roleManager.FindByNameAsync("Customer");
		//		if (role == null)
		//		{
		//			return NotFound("Role not found");
		//		}
		//		var userIds = await _userManager.GetUsersInRoleAsync("Customer");
		//		if (userIds == null)
		//		{
		//			return BadRequest("Error retrieving users in role 'Customer'");
		//		}
		//		int customerCount = userIds.Count;
		//		Boolean invalidDate = false;
		//		List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
		//	   .Where(qr => qr.Status == "Approved")
		//	   .ToList();
		//		if (startDate.HasValue && endDate.HasValue)
		//		{
		//			if (startDate < endDate)
		//			{
		//				requests = requests.Where(qr => qr.CreatedAt >= startDate.Value && qr.CreatedAt <= endDate.Value).ToList();
		//			}
		//		}
		//		else if (!startDate.HasValue || !endDate.HasValue)
		//		{
		//			DateTime targetDate = new DateTime(2, 1, 1);
		//			requests = requests.Where(qr => qr.CreatedAt <= targetDate).ToList();
		//			invalidDate = true;
		//		}

		//		List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
		//		List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

		//		if (requests.Count > 0)
		//		{
		//			TempData["success"] = "Data found";
		//		}
		//		else if (invalidDate)
		//		{
		//			TempData["error"] = "Invalid date range";
		//		}
		//		else
		//		{
		//			TempData["error"] = "Data not found";
		//		}

		//		ViewBag.Dates = rDates;
		//		ViewBag.Revenues = revenues;
		//		ViewBag.CustomerCount = customerCount;

		//		return View(requests);
		//	}
		//}
		public IActionResult Index(List<decimal?> pricelist)
		{

			return View(pricelist);
		}
		//[HttpPost]
		//public IActionResult Index(int year)
		//{
		//	return View();
		//}



		[HttpGet]
		public IActionResult GetRevenueByYear(int year, int month)
		{
			decimal?[] revenueData;
			List<QuotationRequest> quotations;
			if (month != 0)
			{
				revenueData = Enumerable.Repeat((decimal?)0, 31).ToArray();
				quotations = _unitOfWork.QuotationRequest.GetAll(q => q.CreatedAt.Year == year
				&& q.CreatedAt.Month == month && q.Status == SD.StatusPaid).ToList();

			} else
			{
				revenueData = Enumerable.Repeat((decimal?)0, 12).ToArray();
				quotations = _unitOfWork.QuotationRequest.GetAll(q => q.CreatedAt.Year == year
				&& q.Status == SD.StatusPaid).ToList();
			}

			foreach (var quotation in quotations)
			{
				if (month != 0)
				{
					revenueData[quotation.CreatedAt.Day - 1] += quotation.TotalPrice;
				} else
				{
					revenueData[quotation.CreatedAt.Month - 1] += quotation.TotalPrice;
				}
			}

			return Json(revenueData);
		}
		[HttpGet]
		public IActionResult GetRevenueByDateRange(string startDate, string endDate, int diffInDays)
		{
			var startDateObj = DateTime.Parse(startDate);
			var endDateObj = DateTime.Parse(endDate);
			decimal?[] soldData = Enumerable.Repeat((decimal?)0, diffInDays).ToArray();
			List<QuotationRequest> quotations = _unitOfWork.QuotationRequest.GetAll(q => q.CreatedAt.Date >= startDateObj.Date
			&& q.CreatedAt.Date <= endDateObj.Date && q.Status == SD.StatusPaid).ToList();
			foreach (var quotation in quotations)
			{
				soldData[(quotation.CreatedAt - startDateObj).Days] += quotation.TotalPrice;
			}
			return Json(soldData);
		}

		[HttpGet]
		public IActionResult GetJewelryByDateRange(string startDate, string endDate, int diffInDays)
		{
			var startDateObj = DateTime.Parse(startDate);
			var endDateObj = DateTime.Parse(endDate);
			decimal?[] soldData = Enumerable.Repeat((decimal?)0, diffInDays).ToArray();
			List<Delivery> deliveries = _unitOfWork.Delivery.GetAll(q => q.DeliveredAt.Date >= startDateObj.Date
			&& q.DeliveredAt.Date <= endDateObj.Date).ToList();
			foreach (var delivery in deliveries)
			{
				soldData[(delivery.DeliveredAt - startDateObj).Days] += 1;
			}
			return Json(soldData);
		}

		[HttpGet]
		public IActionResult GetRevenueByAll()
		{
			List<QuotationRequest> quotations = _unitOfWork.QuotationRequest.GetAll(q => q.Status == SD.StatusPaid).ToList();
			// Get distinct years
			var distinctYears = quotations
				.Select(q => q.CreatedAt.Year)
				.Distinct();
			// Count distinct years
			int distinctYearCount = distinctYears.Count();
			// Find the minimum year
			int minYear = distinctYears.Min();
			decimal?[] soldData = Enumerable.Repeat((decimal?)0, distinctYearCount).ToArray();
			foreach (var quotation in quotations)
			{
				soldData[quotation.CreatedAt.Year - minYear] += quotation.TotalPrice;
			}
			int[] years = distinctYears.ToArray();

			Array.Sort(years);
			var result = new
			{
				Value1 = soldData,
				Value2 = years
			};
			return Json(result);
		}
		[HttpGet]
		public IActionResult GetJewelryByAll()
		{
			List<Delivery> deliveries = _unitOfWork.Delivery.GetAll().ToList();
			// Get distinct years
			var distinctYears = deliveries
				.Select(q => q.DeliveredAt.Year)
				.Distinct();
			// Count distinct years
			int distinctYearCount = distinctYears.Count();
			// Find the minimum year
			int minYear = distinctYears.Min();
			decimal?[] soldData = Enumerable.Repeat((decimal?)0, distinctYearCount).ToArray();
			foreach (var delivery in deliveries)
			{
				soldData[delivery.DeliveredAt.Year - minYear] += 1;
			}
			int[] years = distinctYears.ToArray();

			Array.Sort(years);
			var result = new
			{
				Value1 = soldData,
				Value2 = years
			};
			return Json(result);
		}

		[HttpGet]
		public IActionResult GetJewelrySold(int year, int month)
		{
			decimal?[] soldData;
			List<Delivery> deliveries;

			if (month != 0)
			{
				if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
				{

					soldData = Enumerable.Repeat((decimal?)0, 31).ToArray();
				} else if (month == 2)
				{
					soldData = Enumerable.Repeat((decimal?)0, 28).ToArray();
				}
				else
				{
					soldData = Enumerable.Repeat((decimal?)0, 30).ToArray();
				}

				deliveries = _unitOfWork.Delivery.GetAll(q => q.DeliveredAt.Year == year
				&& q.DeliveredAt.Month == month).ToList();
			}
			else
			{
				soldData = Enumerable.Repeat((decimal?)0, 12).ToArray();
				deliveries = _unitOfWork.Delivery.GetAll(q => q.DeliveredAt.Year == year).ToList();
			}

			foreach (var delivery in deliveries)
			{
				if (month != 0)
				{
					//check jewelry nao co trong thang do
					//lay ngay deliveredAt
					soldData[delivery.DeliveredAt.Day - 1] += 1;
				}
				else
				{
					soldData[delivery.DeliveredAt.Month - 1] += 1;
				}

			}


			return Json(soldData);
		}
		[HttpGet]
		public IActionResult GetGemstone()
		{
			List<Gemstone> gemstones = _unitOfWork.Gemstone.GetAll(g => g.Status == SD.StatusUnavailable).ToList();

			int gemstoneCount = gemstones.Count;
			var type = gemstones
				.Select(q => q.Name)
				.Distinct();
			int typeCount = type.Count();
			//double rate = typeCount / gemstoneCount;
			int[] soldData = new int[typeCount];
			String[] label = type.ToArray();
			for (int i = 0; i < typeCount; i++)
			{
				soldData[i] = gemstones.Count(q => q.Name == label[i]);

			}

			var result = new
			{
				quantity = soldData,
				labels = label
			};
			return Json(result);
		}
		//[HttpGet]
		//public IActionResult GetMaterial()
		//{
		//	List<MaterialSetMaterial> materialSetMaterials = _unitOfWork.MaterialSetMaterial.GetAll(includeProperties: "Material").ToList();



		//	var materialTypes = materialSetMaterials
		//		.Select(q => q.Material.Type)
		//		.Distinct();
		//	int typeCount = materialTypes.Count();
		//	decimal[] soldData = new decimal[typeCount];
		//	//
		//	String[] label = materialTypes.ToArray();
		//	//
		//	foreach (var materialset in materialSetMaterials)
		//	{
		//		var w = materialTypes.Select(q => q.Weight);

		//	}
		//	for (int i = 0; i < typeCount; i++)
		//	{


		//	}


		//	var result = new
		//	{
		//		quantity = soldData,
		//		labels = label
		//	};
		//	return Json(result);
		//}
		[HttpGet]
		public IActionResult GetRevenue()
		{
			List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll(q => q.Status == SD.StatusPaid).ToList();
			
			List<decimal?> decimalList = new List<decimal?>();
            foreach (var q in requests)
			{
                decimalList.Add(q.TotalPrice.Value);
				
			}
            var sum = decimalList.Sum();

            return Content(sum.ToString());
        }
    }
}