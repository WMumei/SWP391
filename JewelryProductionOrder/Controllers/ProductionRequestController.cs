using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;

namespace SWP391.Controllers
{
    public class ProductionRequestController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductionRequestController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductionRequest obj)
        {
            obj.CreatedAt = DateTime.Now;
            _db.ProductionRequests.Add(obj);
            _db.SaveChanges();
            return View();
        }

        public IActionResult CustomerInfo()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<ProductionRequest> obj = _db.ProductionRequests.ToList();
            return View(obj);
        }
    }
}
