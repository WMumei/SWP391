using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

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
		[Authorize(Roles = SD.Role_Sales)]
		public async Task<ActionResult> Index()
		{
			{
				var role = await _roleManager.FindByNameAsync("Customer");
				if (role == null)
				{
					return NotFound("Role not found");
				}

				var userIds = await _userManager.GetUsersInRoleAsync("Customer");
				if (userIds == null)
				{
					return BadRequest("Error retrieving users in role 'Customer'");
				}
				int customerCount = userIds.Count;

				var delivered = _unitOfWork.Jewelry.GetAll().Where(r => r.Status == SD.StatusPaid).ToList();
				if (delivered == null)
				{
					return NotFound("Jewelry not found");
				}
				int deliveryCount = delivered.Count;

				DateTime targetDate = new DateTime(2, 1, 1);
				List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
			   .Where(qr => qr.Status == SD.StatusPaid && qr.CreatedAt <= targetDate)
			   .ToList();

				List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
				List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

                ViewBag.StartDate = DateTime.Now.AddMonths(-1);
                ViewBag.EndDate = DateTime.Now;
                ViewBag.Dates = rDates;
				ViewBag.Revenues = revenues;
				ViewBag.CustomerCount = customerCount;
				ViewBag.DeliveryCount = deliveryCount;

				return View(requests);
			}
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public async Task<ActionResult> Index(DateTime? startDate, DateTime? endDate)
		{
			{
				var role = await _roleManager.FindByNameAsync("Customer");
				if (role == null)
				{
					return NotFound("Role not found");
				}
				var userIds = await _userManager.GetUsersInRoleAsync("Customer");
				if (userIds == null)
				{
					return BadRequest("Error retrieving users in role 'Customer'");
				}
				int customerCount = userIds.Count;
				Boolean invalidDate = false;
				List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
			   .Where(qr => qr.Status == SD.StatusPaid)
			   .ToList();
				if (startDate.HasValue && endDate.HasValue)
				{
					if (startDate < endDate)
					{
						requests = requests.Where(qr => qr.CreatedAt >= startDate.Value && qr.CreatedAt <= endDate.Value).ToList();
					}
				}
				else if (!startDate.HasValue || !endDate.HasValue)
				{
					DateTime targetDate = new DateTime(2, 1, 1);
					requests = requests.Where(qr => qr.CreatedAt <= targetDate).ToList();
					invalidDate = true;
				}

				List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
				List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

				if (requests.Count > 0)
				{
					TempData["success"] = "Data found";
				}
				else if (invalidDate)
				{
					TempData["error"] = "Invalid date range";
				}
				else
				{
					TempData["error"] = "Data not found";
				}

				ViewBag.StartDate = startDate;
				ViewBag.EndDate = endDate;
				ViewBag.Dates = rDates;
				ViewBag.Revenues = revenues;
				ViewBag.CustomerCount = customerCount;

				return View(requests);
			}
		}
	}
}