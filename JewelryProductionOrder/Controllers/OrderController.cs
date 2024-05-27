using Microsoft.AspNetCore.Mvc;

namespace SWP391.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
