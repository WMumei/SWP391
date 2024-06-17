using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Controllers
{
    public class JewelryDesignController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public JewelryDesignController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = hostEnvironment;
        }
        public IActionResult Create(int jId)
        {
            JewelryDesign obj = new JewelryDesign
            {
                JewelryId = jId,
                Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId)
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(JewelryDesign obj, IFormFile? file)
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
                obj.DesignFile = @"files" + fileName;
            }
            obj.Status = "Pending";
            _unitOfWork.JewelryDesign.Add(obj);
            return View(new JewelryDesign { ProductionRequestId = obj.ProductionRequestId});
        }

        public IActionResult Index()
        {
            List<JewelryDesign> jewelries = _unitOfWork.JewelryDesign.GetAll().ToList();
			return View(jewelries);
        }
    }
}
