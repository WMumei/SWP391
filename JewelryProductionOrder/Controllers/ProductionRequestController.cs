using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace SWP391.Controllers
{
    public class ProductionRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductionRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductionRequest obj)
        {
            obj.CreatedAt = DateTime.Now;
            _unitOfWork.ProductionRequest.Add(obj);
            _unitOfWork.Save();
            return View();
        }

        public IActionResult CustomerInfo()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.ToList();
            return View(obj);
        }
    }
}
