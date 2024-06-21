using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

public class DashboardController : Controller
{
	private readonly IUnitOfWork _unitOfWork;
	public DashboardController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public IActionResult Index()
	{
		List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll().ToList();
		return View(requests);
	}

	//Find quotation request with status = approved and sum total price together
	public IActionResult GetTotalRevenue()
    {
        return View();
    }
}