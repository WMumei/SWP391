using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProductionOrder.Controllers
{
    public class WarrantyCardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWarrantyCardRepository _warrantyCardRepo;
        public WarrantyCardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            List<WarrantyCard> objWarrantyCardList = _warrantyCardRepo.GetAll().ToList();
            return View();
        }

    }
}
