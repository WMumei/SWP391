using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using SWP391.Controllers;
using System.Security.Claims;

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
                obj.DesignFile = Path.Combine("\\files", fileName);
            }
            obj.Status = "Pending";
            //obj.JewelryId = obj.Jewelry.Id;
			_unitOfWork.JewelryDesign.Add(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Jewelry");
            return View(new JewelryDesign { ProductionRequestId = obj.ProductionRequestId});
        }

        public IActionResult Index()
        {
            List<JewelryDesign> jewelries = _unitOfWork.JewelryDesign.GetAll().ToList();
			return View(jewelries);
        }

        public IActionResult Details(int jId)
		{
			JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.JewelryId == jId, includeProperties:"Jewelry");
            return View(design);
		}
		public IActionResult CustomerApprove(int id)
        {
            JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (design is not null)
			{
				design.CustomerId = userId;
				design.Status = $"Approved by Customer";
			}
			_unitOfWork.Save();
			return RedirectToAction("Index", "Home");
			return RedirectToAction("Index");
        }

        public IActionResult Manufacture(int jId)
        {
            JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.JewelryId == jId);
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Jewelries.FirstOrDefault().Id == jId, includeProperties:"Materials,Gemstones");
            ManufactureVM vm = new()
            {
                JewelryDesign = design,
                MaterialSet = materialSet,
				Jewelry = jewelry
			};
			return View(vm);
		}
		public IActionResult CancelJewelryDesign(int jId)
		{
			List<JewelryDesign> jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(j => j.JewelryId == jId).ToList();
			if (jewelryDesigns.Count > 0)
			{
				foreach (JewelryDesign JewelryDesign in jewelryDesigns)
				{
					JewelryDesign.Status = "Canceled";
				}

				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			else
			{
				return NotFound();
			}
		}
	}
}
