using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;

namespace JewelryProductionOrder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
			_unitOfWork = unitOfWork;
		}

        public IActionResult Index()
        {
            List<BaseDesign> designs = _unitOfWork.BaseDesign.GetAll(d => d.Type == "Company").ToList();
			return View(designs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
