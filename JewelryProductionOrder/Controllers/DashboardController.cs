using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

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
            List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll()
           .Where(qr => qr.Status == "Approved")
           .ToList();
            //list<delivery> deliveries = _unitofwork.delivery.getall().tolist();

            List<string> rDates = requests.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
            List<decimal> revenues = rDates.Select(date => requests.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

            //List<string> dDates = deliveries.Where(d => d.DeliveredAt.HasValue)
            //                                .Select(d => d.DeliveredAt.Value.ToString("yyyy-MM-dd"))
            //                                .Distinct()
            //                                .ToList();
            //List<int> deliveryCounts = dDates.Select(date => deliveries.Where(d => d.DeliveredAt.HasValue && d.DeliveredAt.Value.ToString("yyyy-MM-dd") == date).Count()).ToList();

            ViewBag.Dates = rDates;
            ViewBag.Revenues = revenues;
            ViewBag.CustomerCount = customerCount;
            //ViewBag.DeliveryDates = dDates;
            //ViewBag.DeliveryCounts = deliveryCounts;

            return View(requests);
        }
    }
}

//public IActionResult RevenuePeriod(DateTime? startDate, DateTime? endDate)
//{
//    List<QuotationRequest> data;
//    if (startDate.HasValue && endDate.HasValue)
//    {
//        if (startDate > endDate)
//        {
//            data = _unitOfWork.QuotationRequest.GetAll()
//            .Where(qr => qr.Status == "Approved" && qr.CreatedAt>= startDate && qr.CreatedAt <= endDate)
//            .ToList();
//            List<string> dates = data.Select(qr => qr.CreatedAt.ToString("yyyy-MM-dd")).Distinct().ToList();
//            List<decimal> revenues = dates.Select(date => data.Where(qr => qr.CreatedAt.ToString("yyyy-MM-dd") == date).Sum(qr => qr.TotalPrice ?? 0)).ToList();

//            ViewBag.Dates = dates;
//            ViewBag.Revenues = revenues;

//            return View(data);
//        }
//    }
//    else
//    {
//        return RedirectToAction("Index");
//    }
//    return View();
//}
