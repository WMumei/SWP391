using Microsoft.AspNetCore.Mvc;

namespace SWP391.Controllers
{
    public class QuotationController : Controller
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
