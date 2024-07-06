using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;

namespace JewelryProductionOrder.Controllers
{
    public class BaseDesignController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public BaseDesignController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = hostEnvironment;
		}

		public IActionResult Create()
        {
            BaseDesign obj = new BaseDesign
            {
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(BaseDesign obj, IFormFile? file)
        {
            obj.CreatedAt = DateTime.Now;
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(wwwRootPath, @"files");
                using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.Image = Path.Combine("\\files", fileName);
            }

            _unitOfWork.BaseDesign.Add(obj);
            _unitOfWork.Save();

            // TODO: Add to shopping cart

            return RedirectToAction("Index", "Home");
        }

    }
}
