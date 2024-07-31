using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Models.ViewModels.MaterialSetViewModels;
using JewelryProductionOrder.Repositories;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Models.Repositories.Repository.IRepository;
using Stripe.Checkout;
using System.Security.Claims;

namespace SWP391.Controllers
{
	[Authorize]
	public class MaterialSetController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public List<MaterialVM> MaterialListSession
		{
			get => HttpContext.Session.Get<List<MaterialVM>>(SessionConst.MATERIAL_LIST_KEY) ?? new List<MaterialVM>();
		}

		public List<Gemstone> GemstoneListSession
		{
			get => HttpContext.Session.Get<List<Gemstone>>(SessionConst.GEMSTONE_LIST_KEY) ?? new List<Gemstone>();
		}

		// The purpose of the deleted set is solely for the updating gemstones case.
		// In this case, when the gemstone is removed from the current set
		// and added to the deleted set.
		// This allows users to see and add back the gemstone from the available gemstones table,
		// although its status is still unavailable.
		public List<Gemstone> DeletedGemstoneListSession
		{
			get => HttpContext.Session.Get<List<Gemstone>>(SessionConst.DELETED_GEMSTONE_LIST_KEY) ?? new List<Gemstone>();
		}

		public MaterialSetController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Views(Old)
		//[Authorize(Roles = SD.Role_Sales)]
		//public IActionResult Upsert(int jId)
		//{
		//	MaterialSetVM materialSetVM = new MaterialSetVM
		//	{
		//		// Initialize the fields of the MaterialSetVM object
		//		//MaterialSet = new MaterialSet { },
		//		Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId),
		//		MaterialList = _unitOfWork.Material.GetAll().Select(u => new SelectListItem
		//		{
		//			Text = u.Name,
		//			Value = u.Id.ToString()
		//		}),
		//		GemstoneList = _unitOfWork.Gemstone.GetAll().Select(u => new SelectListItem
		//		{
		//			Text = u.Name,
		//			Value = u.Id.ToString()
		//		}),
		//	};
		//	Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
		//	if (jewelry.MaterialSetId is null)
		//	{
		//		MaterialSet materialSet = new MaterialSet() { CreatedAt = DateTime.Now, JewelryId = jId };
		//		_unitOfWork.MaterialSet.Add(materialSet);
		//		_unitOfWork.Save();
		//		jewelry.MaterialSetId = materialSet.Id;
		//		_unitOfWork.Jewelry.Update(jewelry);
		//		_unitOfWork.Save();

		//	}
		//	else
		//	{
		//		materialSetVM.MaterialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties: "MaterialSetMaterials,Gemstones,Materials");
		//	}

		//	return View(materialSetVM);
		//}
		//[HttpPost]
		//[Authorize(Roles = SD.Role_Sales)]
		//public IActionResult Upsert(MaterialSetVM materialSetVM, int? redirectRequest)
		//{
		//	//MaterialSet materialSet = new MaterialSet { CreatedAt = DateTime.Now };
		//	MaterialSet materialSet = _unitOfWork.MaterialSet.Get(u => u.Id == materialSetVM.Jewelry.MaterialSetId);

		//	if (materialSet is not null)
		//	{
		//		materialSet.TotalPrice = GetPrice(materialSet.Id);
		//		_unitOfWork.MaterialSet.Update(materialSet);
		//		_unitOfWork.Save();
		//		TempData["success"] = "Created";

		//		//if (redirectRequest is not null)
		//		//    return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
		//	}
		//	Jewelry jewelry = _unitOfWork.Jewelry.Get(u => u.Id == materialSetVM.Jewelry.Id);
		//	int redirectId = jewelry.ProductionRequestId;
		//	TempData["error"] = "Error";
		//	return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectId });
		//}
		//public IActionResult Index(int id, int jId)
		//{
		//	Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
		//	MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == id, includeProperties: "MaterialSetMaterials,Gemstones,Materials");

		//	MaterialSetVM materialSetVM = new MaterialSetVM
		//	{
		//		Jewelry = jewelry,
		//		MaterialSet = materialSet,
		//	};
		//	return View(materialSetVM);
		//}


		//[Authorize(Roles = SD.Role_Sales)]
		//public IActionResult AddGemstone(MaterialSetVM vm)
		//{
		//	if (vm.Gemstone is null)
		//	{
		//		TempData["error"] = "Please select a gemstone.";
		//		return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		//	}
		//	Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id);
		//	MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == jewelry.MaterialSetId, includeProperties: "Gemstones", tracked: true);
		//	Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == vm.Gemstone.Id, tracked: false);
		//	var ids = materialSet.Gemstones.Select(g => g.Id).ToList();
		//	if (!ids.Contains(gemstone.Id))
		//	{

		//		//materialSet.Gemstones.RemoveAll() ;
		//		materialSet.Gemstones.Add(gemstone);
		//		//_unitOfWork.MaterialSet.Update(materialSet);
		//		_unitOfWork.Save();
		//		materialSet.TotalPrice = GetPrice(materialSet.Id);

		//		_unitOfWork.MaterialSet.Update(materialSet);
		//		_unitOfWork.Save();
		//		TempData["success"] = "Added";
		//	}
		//	else
		//	{
		//		TempData["error"] = "This gemstone already exists in Set.";
		//	}

		//	return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		//}

		//[Authorize(Roles = SD.Role_Sales)]
		//public IActionResult AddMaterial(MaterialSetVM vm)
		//{
		//	if (vm.Material is null)
		//	{
		//		TempData["error"] = "Please select a material.";
		//		return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		//	}
		//	Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id);
		//	MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == jewelry.MaterialSetId, includeProperties: "Materials,MaterialSetMaterials", tracked: true);
		//	Material material = _unitOfWork.Material.Get(m => m.Id == vm.Material.Id, tracked: true);
		//	var ids = materialSet.Materials.Select(m => m.Id).ToList();
		//	if (!ids.Contains(material.Id))
		//	{

		//		//_unitOfWork.MaterialSet.Update(materialSet);
		//		var weight = Convert.ToDecimal(vm.Weight);
		//		if (weight <= 0)
		//		{
		//			TempData["error"] = "Please enter a valid weight.";
		//			return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

		//		}
		//		materialSet.Materials.Add(material);
		//		_unitOfWork.Save();
		//		materialSet.MaterialSetMaterials.Where(s => s.MaterialId == material.Id).FirstOrDefault().Weight = weight;
		//		TempData["success"] = "Added";
		//		_unitOfWork.MaterialSet.Update(materialSet);
		//		_unitOfWork.Save();
		//		materialSet.TotalPrice = GetPrice(materialSet.Id);
		//		_unitOfWork.MaterialSet.Update(materialSet);
		//		_unitOfWork.Save();
		//	}
		//	else
		//	{
		//		TempData["error"] = "This material already exists in Set.";
		//	}


		//	return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		//}

		//public IActionResult DeleteGemstone(int gemstoneId, int materialSetId)
		//{
		//	if (gemstoneId != 0 && materialSetId != 0)
		//	{
		//		try
		//		{
		//			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == materialSetId, includeProperties: "Gemstones", tracked: true);
		//			Gemstone gemstone = materialSet.Gemstones.Where(g => g.Id == gemstoneId).FirstOrDefault();
		//			materialSet.Gemstones.Remove(gemstone);
		//			_unitOfWork.MaterialSet.Update(materialSet);
		//			_unitOfWork.Save();
		//			materialSet.TotalPrice = GetPrice(materialSet.Id);
		//			_unitOfWork.MaterialSet.Update(materialSet);
		//			_unitOfWork.Save();
		//			return Json(new { message = "Deleted" });
		//		}
		//		catch (Exception e)
		//		{
		//		}
		//	}
		//	return Json(new { message = "Error" });

		//	//TempData["success"] = "Deleted";
		//	//return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

		//}
		////[HttpPost]

		//public IActionResult DeleteMaterial(int materialId, int materialSetId)
		//{
		//	try
		//	{

		//		MaterialSetMaterial obj = _unitOfWork.MaterialSetMaterial.Get(u => u.MaterialSetId == materialSetId && u.MaterialId == materialId);
		//		_unitOfWork.MaterialSetMaterial.Remove(obj);
		//		_unitOfWork.Save();
		//		MaterialSet materialSet = _unitOfWork.MaterialSet.Get(materialSet => materialSet.Id == materialSetId);
		//		materialSet.TotalPrice = GetPrice(materialSet.Id);
		//		//_unitOfWork.MaterialSet.Update(materialSet);
		//		_unitOfWork.Save();
		//		//TempData["success"] = "Deleted";
		//		return Json(new { message = "Deleted" });
		//	}
		//	catch (Exception e)
		//	{
		//		return Json(new { message = "Error: " + e.Message });
		//	}

		//	//return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
		//}
		////public IActionResult EditMaterial(MaterialSetVM vm, int materialEditId)
		////{
		////	return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

		////}
		////[HttpPost]
		//public IActionResult EditMaterial(int materialId, int materialSetId, string weight, int jewelryId)
		//{
		//	try
		//	{

		//		if (decimal.TryParse(weight, out decimal result))
		//		{
		//			if (result <= 0) return Json(new { message = "Please enter a valid weight." });

		//			MaterialSetMaterial join = _unitOfWork.MaterialSetMaterial.Get(m => m.MaterialSetId == materialSetId && m.MaterialId == materialId);
		//			join.Weight = result;

		//			_unitOfWork.MaterialSetMaterial.Update(join);
		//			_unitOfWork.Save();

		//			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(materialSet => materialSet.Id == materialSetId);
		//			materialSet.TotalPrice = GetPrice(materialSet.Id);
		//			//_unitOfWork.MaterialSet.Update(materialSet);
		//			_unitOfWork.Save();
		//			//TempData["success"] = "Edited";

		//			return Json(new { message = "Edited" });
		//		}
		//		else
		//		{
		//			return Json(new { message = "Please enter a valid weight." });

		//		}
		//	}
		//	catch (Exception e)
		//	{
		//		return Json(new { message = "Error: " + e.Message });
		//	}
		//}

		//private decimal GetPrice(int materialSetId)
		//{
		//	return _unitOfWork.MaterialSet.GetTotalPrice(materialSetId);
		//}

		#endregion
		[Authorize(Roles = SD.Role_Sales)]

		public IActionResult Details(int mId, int jId)
		{
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
			MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == mId, includeProperties: "MaterialSetMaterials,Gemstones,Materials");

			MaterialSetVM materialSetVM = new MaterialSetVM
			{
				Jewelry = jewelry,
				MaterialSet = materialSet,
			};
			ClearSession();
			return View(materialSetVM);
		}

		#region API
		/// <summary>
		/// Handles the GET request for creating or updating a material set.
		/// </summary>
		/// <param name="mId">The ID of the material set.</param>
		/// <param name="jId">The ID of the jewelry.</param>
		/// <returns>The view for creating or updating a material set.</returns>
		[Authorize(Roles = SD.Role_Sales)]

		public IActionResult Upsert(int mId, int jId)
		{
			// Create case
			if (mId != 0)
			{
				// If a jewelry has its quotation approved by a customer, its material set can not be modified
				// This prevents changing the set after the quotation has been paid and makes the set consistent throughtout the manufacturing process
				Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId && j.Status != SD.StatusProcessing);
				if (jewelry is not null)
				{
					TempData["error"] = "The Material Set can not be modified after the quotation of its jewelry has been approved!";
					// Return to material set details page
					return RedirectToAction("Details", new { mId, jId });
				}

				// Load the material set materials (join entity) to fill up the session list
				var materialSetMaterials = _unitOfWork.MaterialSetMaterial.GetAll(msm => msm.MaterialSetId == mId, includeProperties: "Material").ToList();

				if (materialSetMaterials == null)
				{
					return NotFound();
				}

				// Populate the session lists with the materials and gemstones
				var materialList = materialSetMaterials.Select(msm => new MaterialVM
				{
					Material = msm.Material,
					Weight = msm.Weight,
					Price = msm.Weight * msm.Material.Price
				}).ToList();
				HttpContext.Session.Set(SessionConst.MATERIAL_LIST_KEY, materialList);

				var gemstoneList = _unitOfWork.Gemstone.GetAll(g => g.MaterialSetId == mId).ToList();
				HttpContext.Session.Set(SessionConst.GEMSTONE_LIST_KEY, gemstoneList);

				HttpContext.Session.Remove(SessionConst.DELETED_GEMSTONE_LIST_KEY);
			}
			else
			{
				ClearSession();
			}

			return View();
		}


		[HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		[ActionName("Upsert")]
		public IActionResult UpsertPOST(int mId, int jId)
		{

			var materials = MaterialListSession;
			var gemstones = GemstoneListSession;
			var sessionGemstoneIds = GemstoneListSession.Select(g => g.Id).ToList();


			// Fail if there aren't anything in the set
			if (materials.Count == 0 && gemstones.Count == 0)
			{
				return Json(new { success = false, message = "The Material Set could not be empty!" });
			}

			// Can not modify the set if the quotation of its jewelry has been approved
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId && j.Status != SD.StatusProcessing);
			if (jewelry is not null)
			{
				return Json(new { success = false, message = "The Material Set can not be modified after the quotation of its jewelry has been approved!" });
			}

			// Case Insert
			if (mId == 0)
			{
				// Check again to make sure that all gemstones are available in the process of adding 
				// (no one else added it to a set while the user was selecting and adding)
				// Must get back from db to get latest status
				var dbGemstones = _unitOfWork.Gemstone.GetAll(g => sessionGemstoneIds.Contains(g.Id)).ToList();
				if (dbGemstones.Any(g => g.Status == SD.StatusUnavailable))
				{
					ClearSession();
					return Json(new { success = false, message = "Some gemstones are not available. Please try again" });
				}

				MaterialSet materialSet = new MaterialSet() { CreatedAt = DateTime.Now, JewelryId = jId, TotalPrice = GetSetTotal() };
				materialSet.TotalPrice = GetSetTotal();
				_unitOfWork.MaterialSet.Add(materialSet);
				_unitOfWork.Save();
				// Add each material to the set
				foreach (var material in materials)
				{
					if (material.Weight <= 0)
					{
						return Json(new { success = false, message = "Please enter a valid weight" });
					}

					var join = new MaterialSetMaterial()
					{
						MaterialId = material.Material.Id,
						Weight = material.Weight,
						MaterialSetId = materialSet.Id
					};
					_unitOfWork.MaterialSetMaterial.Add(join);
				}

				// Add each gemstone to the material set
				foreach (var gemstone in dbGemstones)
				{
					gemstone.MaterialSetId = materialSet.Id;
					gemstone.Status = SD.StatusUnavailable;
					_unitOfWork.Gemstone.Update(gemstone);
				}
				_unitOfWork.Save();
				ClearSession();
				return Json(new { success = true, message = "Material Set created!", redirectId = materialSet.Id });
			}
			// Case Update
			else
			{
				MaterialSet materialSet = _unitOfWork.MaterialSet.Get(i => i.Id == mId, tracked: true);
				materialSet.TotalPrice = GetSetTotal();
				if (materialSet == null)
				{
					return Json(new { success = false, message = "Material Set not found!" });
				}

				// Updating the material set will set the status previous quotations to discontinued
				var requests = _unitOfWork.QuotationRequest.GetAll(q => q.MaterialSetId == mId);
				foreach (QuotationRequest request in requests)
				{
					request.Status = SD.StatusDiscontinued;
					_unitOfWork.QuotationRequest.Update(request);
				}
				_unitOfWork.Save();

				// Remove existing materials and gemstones
				var existingMaterials = _unitOfWork.MaterialSetMaterial.GetAll(m => m.MaterialSetId == mId).ToList();
				var existingGemstones = _unitOfWork.Gemstone.GetAll(g => g.MaterialSetId == mId).ToList();

				// Fail if there is a gem that is unavailable and not already in the set
				// To clarify, this ensures that the newly added gemstone in session is still available. The only unvaiable gems of the list is already in the set (unvailable because it is already in this particular set)
				var existingGemstoneIds = existingGemstones.Select(m => m.Id).ToList();

				if (gemstones.Any(g => g.Status == SD.StatusUnavailable && !existingGemstoneIds.Contains(g.Id)))
				{
					ClearSession();
					return Json(new { success = false, message = "Some newly added gemstones are not available. Please try again!" });
				}

				// Remove currently existing materials in the set
				_unitOfWork.MaterialSetMaterial.RemoveRange(existingMaterials);
				// Add materials to the set
				foreach (var material in materials)
				{
					var join = new MaterialSetMaterial()
					{
						MaterialId = material.Material.Id,
						Weight = material.Weight,
						MaterialSetId = materialSet.Id
					};
					_unitOfWork.MaterialSetMaterial.Add(join);
				}

				foreach (var existingGemstone in existingGemstones)
				{
					existingGemstone.MaterialSetId = null;
					existingGemstone.Status = SD.StatusAvailable;
					//_unitOfWork.Gemstone.Update(existingGemstone);
				}

				/* 
				  Add gemstones to the material set
				*/
				// First part, add the gemstones that are being tracked
				var gemstoneToBeAdded = existingGemstones.Where(g => sessionGemstoneIds.Contains(g.Id)).ToList();
				foreach (var gemstone in gemstoneToBeAdded)
				{
					gemstone.MaterialSetId = materialSet.Id;
					gemstone.Status = SD.StatusUnavailable;
				}
				// Second part, add those that aren't being tracked
				var gemstoneToBeAddedNoTracking = gemstones.Where(g => !existingGemstoneIds.Contains(g.Id)).ToList();
				foreach (var gemstone in gemstoneToBeAddedNoTracking)
				{
					gemstone.MaterialSetId = materialSet.Id;
					gemstone.Status = SD.StatusUnavailable;
					_unitOfWork.Gemstone.Update(gemstone);
				}


				_unitOfWork.Save();
				ClearSession();
				return Json(new { success = true, message = "Material Set updated!" });
			}
		}


		[Authorize(Roles = SD.Role_Sales)]
		[HttpGet]
		public IActionResult GetMaterials()
		{
			var sessionMaterialIds = MaterialListSession.Select(m => m.Material.Id).ToList();
			var materials = _unitOfWork.Material.GetAll(m => !sessionMaterialIds.Contains(m.Id));
			return Json(new { data = materials });
		}
		[Authorize(Roles = SD.Role_Sales)]
		[HttpGet]
		public IActionResult GetGemstones()
		{
			var sessionGemstoneIds = GemstoneListSession.Select(g => g.Id).ToList();
			var sessionDeletedGemstoneIds = DeletedGemstoneListSession.Select(g => g.Id).ToList();

			// Retrieve the gemstone if
			// (it is available OR in deleted set) AND not in the currently selected gemstone
			var gemstones = _unitOfWork.Gemstone.GetAll(g => (g.Status != SD.StatusUnavailable || sessionDeletedGemstoneIds.Contains(g.Id)) && !sessionGemstoneIds.Contains(g.Id))
				.ToList();

			return Json(new { data = gemstones });
		}


		[Authorize(Roles = SD.Role_Sales)]
		[HttpGet]
		public IActionResult GetSessionMaterials()
		{
			return Json(new { data = MaterialListSession });
		}
		[Authorize(Roles = SD.Role_Sales)]
		[HttpGet]
		public IActionResult GetSessionGemstones()
		{
			return Json(new { data = GemstoneListSession });
		}


		[Authorize(Roles = SD.Role_Sales)]
		[HttpPost]
		public IActionResult AddMaterial(int id)
		{
			// Fail if the material already exists in current set
			if (MaterialListSession.Exists(m => m.Material.Id == id))
			{
				return Json(new { success = false, message = "Material already exists in the set" });
			}

			// Otherwise, add that to session if material exists 
			Material? material = _unitOfWork.Material.Get(m => m.Id == id);
			if (material is null)
			{
				return Json(new { success = false, message = "Material not found" });
			}

			var materialVM = new MaterialVM { Material = material, Weight = 1, Price = material.Price };
			var list = MaterialListSession;
			list.Add(materialVM);
			HttpContext.Session.Set(SessionConst.MATERIAL_LIST_KEY, list);

			return Json(new { success = true, message = "Material added successfully" });
		}
		[Authorize(Roles = SD.Role_Sales)]
		[HttpPost]
		public IActionResult AddGemstone(int id)
		{
			// Fail if the gemstone already exists in current set
			if (GemstoneListSession.Exists(g => g.Id == id))
			{
				return Json(new { success = false, message = "Gemstone already exists in the set" });
			}

			// Fail if gemstone doesn't exist OR (unavailable AND not in the deleted set).
			// In other words, success only if gemstone exists AND (availabe OR in the deleted set)
			var sessionDeletedGemstoneIds = DeletedGemstoneListSession.Select(g => g.Id).ToList();
			bool inDeletedSet = sessionDeletedGemstoneIds.Contains(id);
			Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == id && (g.Status == SD.StatusAvailable || inDeletedSet));
			if (gemstone is null)
			{
				return Json(new { success = false, message = "Gemstone not found or unavailable" });
			}

			// If it's in the deleted set, remove it from there
			var deletedGemstoneList = DeletedGemstoneListSession;
			var inDeletedGemstone = deletedGemstoneList.FirstOrDefault(g => g.Id == id);
			if (inDeletedGemstone is not null)
			{
				deletedGemstoneList.Remove(inDeletedGemstone);
				HttpContext.Session.Set(SessionConst.DELETED_GEMSTONE_LIST_KEY, deletedGemstoneList);
			}



			var gemstoneList = GemstoneListSession;
			gemstoneList.Add(gemstone);
			HttpContext.Session.Set(SessionConst.GEMSTONE_LIST_KEY, gemstoneList);

			return Json(new { success = true, message = "Gemstone added successfully" });
		}


		[Authorize(Roles = SD.Role_Sales)]
		[HttpPost]
		public IActionResult UpdateMaterial(int id, decimal weight)
		{
			// Weight validation
			if (weight <= 0)
			{
				return Json(new { success = false, message = "Please enter a valid weight" });
			}

			// Update the material if found in set
			var materials = MaterialListSession;
			var materialVM = materials.FirstOrDefault(m => m.Material.Id == id);
			if (materialVM is not null)
			{
				materials.Remove(materialVM);
				materialVM.Weight = weight;
				materialVM.Price = weight * materialVM.Material.Price;
				materials.Add(materialVM);

				HttpContext.Session.Set(SessionConst.MATERIAL_LIST_KEY, materials);
				return Json(new { success = true, message = $"Material updated successfully" });
			}
			return Json(new { success = false, message = "Material not found" });
		}


		[Authorize(Roles = SD.Role_Sales)]
		[HttpDelete]
		public IActionResult DeleteMaterial(int id)
		{
			// Find the material in the session list
			var materials = MaterialListSession;
			var material = materials.FirstOrDefault(m => m.Material.Id == id);
			if (material != null)
			{
				// Remove the material from the session list
				materials.Remove(material);
				HttpContext.Session.Set(SessionConst.MATERIAL_LIST_KEY, materials);
				return Json(new { success = true, message = "Material deleted successfully" });
			}
			return Json(new { success = false, message = "Material not found" });
		}
		[Authorize(Roles = SD.Role_Sales)]
		[HttpDelete]
		public IActionResult DeleteGemstone(int id)
		{
			// Find the gemstone in the session list
			var gemstones = GemstoneListSession;
			var gemstone = gemstones.FirstOrDefault(g => g.Id == id);
			if (gemstone != null)
			{
				// Remove the gemstone from the session list
				gemstones.Remove(gemstone);
				HttpContext.Session.Set(SessionConst.GEMSTONE_LIST_KEY, gemstones);

				// If it's not in the deleted set, add it to there
				var deletedGemstoneList = DeletedGemstoneListSession;
				var deletedGemstoneListIds = deletedGemstoneList.Select(g => g.Id).ToList();
				if (!deletedGemstoneListIds.Contains(id))
				{
					deletedGemstoneList.Add(gemstone);
					HttpContext.Session.Set(SessionConst.DELETED_GEMSTONE_LIST_KEY, deletedGemstoneList);

				}
				return Json(new { success = true, message = "Gemstone deleted successfully" });
			}

			return Json(new { success = false, message = "Gemstone not found" });
		}


		[HttpGet]
		[Authorize(Roles = $"{SD.Role_Manager},{SD.Role_Sales},{SD.Role_Customer}")]
		public IActionResult GetPrice(int mId)
		{
			decimal materialTotal = GetMaterialTotal();
			decimal gemstoneTotal = GetGemstoneTotal();
			return Json(new { materialTotal, gemstoneTotal, setTotal = materialTotal + gemstoneTotal });
		}


		[HttpGet]
		[Authorize(Roles = $"{SD.Role_Manager},{SD.Role_Sales},{SD.Role_Customer}")]
		public IActionResult GetCurrentPrice(int mId)
		{
			// Retrieve the MaterialSet from the database
			var materialSet = _unitOfWork.MaterialSet.Get(
				m => m.Id == mId,
				includeProperties: "MaterialSetMaterials,MaterialSetMaterials.Material,Gemstones"
			);

			if (materialSet == null)
			{
				return Json(new { success = false });
			}

			// Calculate the total price
			decimal materialTotal = materialSet.MaterialSetMaterials.Sum(msm => msm.Weight * msm.Material.Price);
			decimal gemstoneTotal = materialSet.Gemstones.Sum(g => g.Price);
			decimal setTotal = materialTotal + gemstoneTotal;

			return Json(new { success = true, materialTotal, gemstoneTotal, setTotal });
		}


		#endregion

		private decimal GetSetTotal()
		{
			return GetMaterialTotal() + GetGemstoneTotal();
		}

		private string GetCurrentUserId()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}
		//[HttpPost]

		private decimal GetMaterialTotal()
		{
			decimal total = 0;
			foreach (var material in MaterialListSession)
			{
				total += material.Price;
			}
			return total;
		}

		private decimal GetGemstoneTotal()
		{
			decimal total = 0;
			foreach (var gemstone in GemstoneListSession)
			{
				total += gemstone.Price;
			}
			return total;
		}

		private void ClearSession()
		{
			HttpContext.Session.Remove(SessionConst.MATERIAL_LIST_KEY);
			HttpContext.Session.Remove(SessionConst.DELETED_GEMSTONE_LIST_KEY);
			HttpContext.Session.Remove(SessionConst.GEMSTONE_LIST_KEY);
		}
	}
}
