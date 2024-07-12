using System.Reflection.Metadata;
using Azure.Core;
using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Areas.Staff.Controllers
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

                var delivered = _unitOfWork.Jewelry.GetAll().Where(r => r.Status == "Delivered").ToList();
                if (delivered == null)
                {
                    return NotFound("Jewelry not found");
                }
                int deliveryCount = delivered.Count;

                List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
               .Where(qr => qr.Status == "Approved")
               .ToList();

                List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
                List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

                ViewBag.Dates = rDates;
                ViewBag.Revenues = revenues;
                ViewBag.CustomerCount = customerCount;
                ViewBag.DeliveryCount = deliveryCount;

                return View(requests);
            }
        }

        [HttpPost]
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

                List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
               .Where(qr => qr.Status == "Approved")
               .ToList();
                if (startDate < endDate)
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        requests = requests.Where(qr => qr.CreatedAt >= startDate.Value && qr.CreatedAt <= endDate.Value).ToList();
                    }
                }

                List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
                List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

                if (requests.Count > 0)
                {
                    TempData["success"] = "Data found";
                }
                else
                {
                    TempData["error"] = "Data not found";
                }

                ViewBag.Dates = rDates;
                ViewBag.Revenues = revenues;
                ViewBag.CustomerCount = customerCount;

                return View(requests);
            }
        }
    }
}