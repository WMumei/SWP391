using Humanizer;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Models.Repositories.Repository.IRepository;
using static System.Collections.Specialized.BitVector32;
using System;
using System.Diagnostics;

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

        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
        public IActionResult Create()
        {
            Material material = new Material();
            return View(material);
        }

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
		public IActionResult Create(Material obj)
		{
			_unitOfWork.Material.Add(obj);
			_unitOfWork.Save();
			TempData["success"] = "Material Created";
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
			if (ModelState.IsValid)
			{
				_unitOfWork.Material.Update(material);
				_unitOfWork.Save();
				TempData["success"] = "Material updated";
				return RedirectToAction("Index");
			}
			if (!ModelState.IsValid)
			{
				foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
				{
					Debug.WriteLine(error.ErrorMessage);
				}
				// ...
			}
			return View();
			//_unitOfWork.Material.Update(dbM);
			//_unitOfWork.Save();
   //         return RedirectToAction("Index");
        }

		[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager}")]
		public IActionResult Delete(int mId)
		{
			
			List<MaterialSetMaterial> materialSetMaterials = _unitOfWork.MaterialSetMaterial.GetAll(includeProperties: "Material").ToList();
			Material material = _unitOfWork.Material.Get(m => m.Id == mId );
			if (material == null)
			{
				return NotFound();
			}
			bool isMaterialInUse = materialSetMaterials.Any(msm => msm.MaterialId == mId);
			if (isMaterialInUse)
			{
				TempData["error"] = "Material is currently in use";
				return RedirectToAction("Index");
			}

			_unitOfWork.Material.Remove(material);
			_unitOfWork.Save();
			TempData["success"] = "Material Removed";
			return RedirectToAction("Index");
		}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Material> objMaterial = _unitOfWork.Material.GetAll().ToList();
            return Json(new { data = objMaterial });
        }
        #endregion
    }
}
