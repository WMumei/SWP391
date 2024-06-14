using Microsoft.AspNetCore.Mvc;

namespace JewelryProductionOrder.Controllers
{
    public class JewelryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
