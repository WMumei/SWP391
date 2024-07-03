using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;

namespace JewelryProductionOrder.Controllers
{
    public class BaseDesignController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

		public BaseDesignController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

        public IActionResult Details(int id)
        {
            BaseDesign design = _unitOfWork.BaseDesign.Get(d => d.Id == id);
			return View(design);
        }

    }
}
