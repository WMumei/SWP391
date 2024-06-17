using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Controllers
{
    public class JewelryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JewelryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Create(int reqId)
        {
            Jewelry obj = new Jewelry
            {
                ProductionRequestId = reqId
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(Jewelry obj)
        {
            obj.CreatedAt = DateTime.Now;
            _unitOfWork.Jewelry.Add(obj);
            return View(new Jewelry { ProductionRequestId = obj.ProductionRequestId});
        }

        public IActionResult Index()
        {
            List<Jewelry> jewelries = _unitOfWork.Jewelry.GetAll().ToList();
			return View(jewelries);
        }

		public IActionResult Manufacture(int id)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
			User productionStaff = _unitOfWork.User.Get(u => u.Id == "1");
			if (jewelry is not null)
			{
				jewelry.ProductionStaffId = productionStaff.Id;
				jewelry.Status = $"Currently manufacturing";
			}
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}

        public IActionResult Complete(int id)
        {
            Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
            //User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
            //if (jewelry is not null)
            //{
            //    jewelry.ProductionStaffId = productionStaff.Id;
            //    jewelry.Status = $"Manufactured by {productionStaff.Name}";
            //}
            jewelry.Status = "Manufactured";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Deliver(int id)
        {
            //Jewelry jewelry = _unitOfWork.Jewelry.Get(jewelry => jewelry.Id == id);
            //User productionStaff = _unitOfWork.User.Get(u => u.Id == 1);
            //if (jewelry is not null)
            //{
            //    jewelry.ProductionStaffId = productionStaff.Id;
            //    jewelry.Status = $"Currently manufacturing by {productionStaff.Name}";
            //}
            //_unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
