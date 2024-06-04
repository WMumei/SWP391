using Microsoft.AspNetCore.Mvc;

namespace JewelryProductionOrder.Controllers
{
    public class WarrantyCardController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
