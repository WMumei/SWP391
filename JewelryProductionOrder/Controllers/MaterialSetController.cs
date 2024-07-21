using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                    Text = u.Name,
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

            materialSet.TotalPrice = GetPrice(materialSet.Id);
            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();
            TempData["success"] = "Created";

            if (redirectRequest is not null)
                return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
            return RedirectToAction("Index", "Jewelry");
        }
        public IActionResult Index(int id, int jId)
        {
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
            MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == id,includeProperties: "MaterialSetMaterials,Gemstones,Materials");

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
            MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "Gemstones").MaterialSet;
            Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == vm.Gemstone.Id, tracked: true);
            var ids = materialSet.Gemstones.Select(g => g.Id).ToList();
			if (!ids.Contains(gemstone.Id))
            {
                materialSet.Gemstones.Add(gemstone);
                _unitOfWork.MaterialSet.Update(materialSet);
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
            MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "Materials").MaterialSet;
            Material material = _unitOfWork.Material.Get(m => m.Id == vm.Material.Id, tracked: true);
            var ids = materialSet.Materials.Select(m => m.Id).ToList();
            if (!ids.Contains(material.Id))
            {
                materialSet.Materials.Add(material);
                _unitOfWork.MaterialSet.Update(materialSet);
                var weight = Convert.ToDecimal(vm.Weight);
                materialSet.MaterialSetMaterials.Where(s => s.MaterialId == material.Id).FirstOrDefault().Weight = weight;
                TempData["success"] = "Added";
            }
            else
            {
                TempData["error"] = "This material already exists in Set.";
            }

            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();
            materialSet.TotalPrice = GetPrice(materialSet.Id);
            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
        }

        public IActionResult DeleteGemstone(int gemDeleteId, int materialSetId)
        {
            MaterialSet materialSet = _unitOfWork.MaterialSet.Get(s => s.Id == materialSetId, includeProperties: "Gemstones");
            Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == gemDeleteId);
            materialSet.Gemstones.Remove(gemstone);
            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();
            materialSet.TotalPrice = GetPrice(materialSet.Id);
            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();

            //TempData["success"] = "Deleted";
            //return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
            return Json(new { message = "Deleted" });

        }
        //[HttpPost]

        public IActionResult DeleteMaterial(int materialId, int materialSetId)
        {
            MaterialSetMaterial obj = _unitOfWork.MaterialSetMaterial.Get(u => u.MaterialSetId == materialSetId && u.MaterialId == materialId);
            _unitOfWork.MaterialSetMaterial.Remove(obj);
            _unitOfWork.Save();
            MaterialSet materialSet = _unitOfWork.MaterialSet.Get(materialSet => materialSet.Id == materialSetId);
            materialSet.TotalPrice = GetPrice(materialSet.Id);
            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();
            //TempData["success"] = "Deleted";
            return Json(new { message = "Deleted" });

            //return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });
        }
        //public IActionResult EditMaterial(MaterialSetVM vm, int materialEditId)
        //{
        //	return RedirectToAction(nameof(Upsert), new { jId = vm.Jewelry.Id });

        //}
        //[HttpPost]
        public IActionResult EditMaterial(int materialId, int materialSetId, decimal weight, int jewelryId)
        {

            MaterialSetMaterial join = _unitOfWork.MaterialSetMaterial.Get(m => m.MaterialSetId == materialSetId && m.MaterialId == materialId);
            join.Weight = weight;

            _unitOfWork.MaterialSetMaterial.Update(join);
            _unitOfWork.Save();
            //TempData["success"] = "Edited";

            return Json(new { message = "Edited" });
        }

        private decimal GetPrice(int materialSetId)
        {
            return _unitOfWork.MaterialSet.GetTotalPrice(materialSetId);
        }

    }
}
