using JewelryProductionOrder.Data;
using JewelryProductionOrder.Repositories;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    private readonly QuotationRequestRepository _quotationRequestRepository; //To sum up for total revenue

    public DashboardController(QuotationRequestRepository quotationRequestRepository)
    {
        _quotationRequestRepository = quotationRequestRepository;
    }

    //Find quotation request with status = approved and sum total price together
    public IActionResult GetTotalRevenue()
    {
        var approvedQuotationRequests = _quotationRequestRepository.GetApprovedQuotationRequests();
        var totalRevenue = approvedQuotationRequests.Sum(qr => qr.TotalPrice);

        return Ok(new { TotalRevenue = totalRevenue });
    }

    public IActionResult Index()
    {
        return View();
    }
}