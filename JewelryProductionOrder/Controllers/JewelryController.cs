using Microsoft.AspNetCore.Mvc;

namespace JewelryProductionOrder.Controllers
{
    public class JewelryController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
