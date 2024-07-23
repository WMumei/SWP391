using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Controllers
{
	public class MaterialController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public MaterialController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
		public IActionResult Index()
		{
			List<Material> materialList = _unitOfWork.Material.GetAll().ToList();
			return View(materialList);
		}

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
		public IActionResult Create(Material obj)
		{
			_unitOfWork.Material.Add(obj);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}

        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
        public IActionResult Edit(int mId)
		{
			var material = _unitOfWork.Material.Get(m => m.Id == mId);
			if (material == null)
			{
				return NotFound();
			}
			return View(material);
		}

		[HttpPost]
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
        public IActionResult Edit(Material material)
		{

			Material dbM = _unitOfWork.Material.Get(m => m.Id == material.Id);
            dbM.Price = material.Price;
            dbM.Name = material.Name;
			_unitOfWork.Material.Update(dbM);
			_unitOfWork.Save();
            return RedirectToAction(nameof(Edit));
        }

		[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
		public IActionResult Delete(int mId)
		{
			Material material = _unitOfWork.Material.Get(m => m.Id == mId);
			if (material == null)
			{
				return NotFound();
			}
			_unitOfWork.Material.Remove(material);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}


	}
}
