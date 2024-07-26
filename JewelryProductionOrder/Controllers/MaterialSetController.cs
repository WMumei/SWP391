using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Repositories.Repository.IRepository;

namespace SWP391.Controllers
{
	[Authorize(Roles = SD.Role_Sales)]
	public class MaterialSetController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public MaterialSetController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Upsert(int jId)
		{
			MaterialSetVM materialSetVM = new MaterialSetVM
			{
				// Initialize the fields of the MaterialSetVM object
				//MaterialSet = new MaterialSet { },
				Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId),
				MaterialList = _unitOfWork.Material.GetAll().Select(u => new SelectListItem
				{
					Text = u.Type,
					Value = u.Id.ToString()
				}),
				GemstoneList = _unitOfWork.Gemstone.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
			};
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			if (jewelry.MaterialSetId is null)
			{
				MaterialSet materialSet = new MaterialSet() { CreatedAt = DateTime.Now };
				_unitOfWork.MaterialSet.Add(materialSet);
				_unitOfWork.Save();
				jewelry.MaterialSetId = materialSet.Id;
				_unitOfWork.Jewelry.Update(jewelry);
				_unitOfWork.Save();

			}
			else
			{
				materialSetVM.MaterialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties: "MaterialSetMaterials,Gemstones,Materials");
			}

			return View(materialSetVM);
		}
		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Upsert(MaterialSetVM materialSetVM, int? redirectRequest)
		{
			//MaterialSet materialSet = new MaterialSet { CreatedAt = DateTime.Now };
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(u => u.Id == materialSetVM.Jewelry.MaterialSetId);

			if (materialSet is not null)
			{
				materialSet.TotalPrice = GetPrice(materialSet.Id);
				_unitOfWork.MaterialSet.Update(materialSet);
				_unitOfWork.Save();
				TempData["success"] = "Created";

				//if (redirectRequest is not null)
				//    return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
			}
			Jewelry jewelry = _unitOfWork.Jewelry.Get(u => u.Id == materialSetVM.Jewelry.Id);
			int redirectId = jewelry.ProductionRequestId;
			TempData["error"] = "Error";
			return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectId });
		}
		public IActionResult Index(int id, int jId)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == id, includeProperties: "MaterialSetMaterials,Gemstones,Materials");

			MaterialSetVM materialSetVM = new MaterialSetVM
			{
				Jewelry = jewelry,
				MaterialSet = materialSet,
			};
			return View(materialSetVM);
		}


		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult AddGemstone(MaterialSetVM vm)
		{
			if (vm.Gemstone is null)
			{
				TempData["error"] = "Please select a gemstone.";
				return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
			}
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == jewelry.MaterialSetId, includeProperties: "Gemstones", tracked: true);
			Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == vm.Gemstone.Id, tracked: false);
			var ids = materialSet.Gemstones.Select(g => g.Id).ToList();
			if (!ids.Contains(gemstone.Id))
			{

				//materialSet.Gemstones.RemoveAll() ;
				materialSet.Gemstones.Add(gemstone);
				//_unitOfWork.MaterialSet.Update(materialSet);
				_unitOfWork.Save();
				materialSet.TotalPrice = GetPrice(materialSet.Id);

				_unitOfWork.MaterialSet.Update(materialSet);
				_unitOfWork.Save();
				TempData["success"] = "Added";
			}
			else
			{
				TempData["error"] = "This gemstone already exists in Set.";
			}

			return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		}

		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult AddMaterial(MaterialSetVM vm)
		{
			if (vm.Material is null)
			{
				TempData["error"] = "Please select a material.";
				return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
			}
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == jewelry.MaterialSetId, includeProperties: "Materials,MaterialSetMaterials", tracked: true);
			Material material = _unitOfWork.Material.Get(m => m.Id == vm.Material.Id, tracked: true);
			var ids = materialSet.Materials.Select(m => m.Id).ToList();
			if (!ids.Contains(material.Id))
			{

				//_unitOfWork.MaterialSet.Update(materialSet);
				var weight = Convert.ToDecimal(vm.Weight);
				if (weight <= 0)
				{
					TempData["error"] = "Please enter a valid weight.";
					return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

				}
				materialSet.Materials.Add(material);
				_unitOfWork.Save();
				materialSet.MaterialSetMaterials.Where(s => s.MaterialId == material.Id).FirstOrDefault().Weight = weight;
				TempData["success"] = "Added";
				_unitOfWork.MaterialSet.Update(materialSet);
				_unitOfWork.Save();
				materialSet.TotalPrice = GetPrice(materialSet.Id);
				_unitOfWork.MaterialSet.Update(materialSet);
				_unitOfWork.Save();
			}
			else
			{
				TempData["error"] = "This material already exists in Set.";
			}


			return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		}

		public IActionResult DeleteGemstone(int gemstoneId, int materialSetId)
		{
			if (gemstoneId != 0 && materialSetId != 0)
			{
				try
				{
					MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == materialSetId, includeProperties: "Gemstones", tracked: true);
					Gemstone gemstone = materialSet.Gemstones.Where(g => g.Id == gemstoneId).FirstOrDefault();
					materialSet.Gemstones.Remove(gemstone);
					_unitOfWork.MaterialSet.Update(materialSet);
					_unitOfWork.Save();
					materialSet.TotalPrice = GetPrice(materialSet.Id);
					_unitOfWork.MaterialSet.Update(materialSet);
					_unitOfWork.Save();
					return Json(new { message = "Deleted" });
				}
				catch (Exception e)
				{
				}
			}
			return Json(new { message = "Error" });

			//TempData["success"] = "Deleted";
			//return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

		}
		//[HttpPost]

		public IActionResult DeleteMaterial(int materialId, int materialSetId)
		{
			try
			{

				MaterialSetMaterial obj = _unitOfWork.MaterialSetMaterial.Get(u => u.MaterialSetId == materialSetId && u.MaterialId == materialId);
				_unitOfWork.MaterialSetMaterial.Remove(obj);
				_unitOfWork.Save();
				MaterialSet materialSet = _unitOfWork.MaterialSet.Get(materialSet => materialSet.Id == materialSetId);
				materialSet.TotalPrice = GetPrice(materialSet.Id);
				//_unitOfWork.MaterialSet.Update(materialSet);
				_unitOfWork.Save();
				//TempData["success"] = "Deleted";
				return Json(new { message = "Deleted" });
			}
			catch (Exception e)
			{
				return Json(new { message = "Error: " + e.Message });
			}

			//return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		}
		//public IActionResult EditMaterial(MaterialSetVM vm, int materialEditId)
		//{
		//	return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

		//}
		//[HttpPost]
		public IActionResult EditMaterial(int materialId, int materialSetId, string weight, int jewelryId)
		{
			try
			{

				if (decimal.TryParse(weight, out decimal result))
				{
					if (result <= 0) return Json(new { message = "Please enter a valid weight." });

					MaterialSetMaterial join = _unitOfWork.MaterialSetMaterial.Get(m => m.MaterialSetId == materialSetId && m.MaterialId == materialId);
					join.Weight = result;

					_unitOfWork.MaterialSetMaterial.Update(join);
					_unitOfWork.Save();

					MaterialSet materialSet = _unitOfWork.MaterialSet.Get(materialSet => materialSet.Id == materialSetId);
					materialSet.TotalPrice = GetPrice(materialSet.Id);
					//_unitOfWork.MaterialSet.Update(materialSet);
					_unitOfWork.Save();
					//TempData["success"] = "Edited";

					return Json(new { message = "Edited" });
				}
				else
				{
					return Json(new { message = "Please enter a valid weight." });

				}
			}
			catch (Exception e)
			{
				return Json(new { message = "Error: " + e.Message });
			}
		}

		private decimal GetPrice(int materialSetId)
		{
			return _unitOfWork.MaterialSet.GetTotalPrice(materialSetId);
		}

	}
}
