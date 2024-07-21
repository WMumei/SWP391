using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Repositories.Repository.IRepository;

namespace SWP391.Controllers
{
    [Authorize]
    public class MaterialSetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MaterialSetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Create(int jId)
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
        public IActionResult Create(MaterialSetVM materialSetVM, int reqIndex, int? redirectRequest)
        {
            //MaterialSet materialSet = new MaterialSet { CreatedAt = DateTime.Now };
			MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == materialSetVM.Jewelry.Id, includeProperties: "MaterialSet").MaterialSet;
            
            List<MaterialSetMaterial> materialSetMaterial = _unitOfWork.MaterialSetMaterial.GetAll(s => s.MaterialSetId == materialSet.Id, includeProperties: "Material").ToList();
            foreach (MaterialSetMaterial set in materialSetMaterial)
            {
                materialSet.TotalPrice += set.Weight * set.Material.Price;
            }
			_unitOfWork.MaterialSet.Update(materialSet);
			_unitOfWork.Save();
            
            materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == materialSet.Id, includeProperties: "Gemstones");
            foreach (Gemstone gemstone in materialSet.Gemstones)
            {
                materialSet.TotalPrice += gemstone.Price;
			}
			_unitOfWork.MaterialSet.Update(materialSet);
			_unitOfWork.Save();

			if (redirectRequest is not null)
				return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
            return RedirectToAction("Index", "Jewelry");
        }
        //public IActionResult Index()
        //{
        //    List<MaterialSet> obj = _unitOfWork.MaterialSet.GetAll().ToList();
        //    return View(obj);
        //}
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult AddGemstone(MaterialSetVM vm)
        {
			MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "MaterialSet").MaterialSet;
			Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == vm.Gemstone.Id, tracked: true);
			materialSet.Gemstones.Add(gemstone);

            _unitOfWork.MaterialSet.Update(materialSet);
            _unitOfWork.Save();
			return RedirectToAction("Create", new { jId = vm.Jewelry.Id });
        }

		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult AddMaterial(MaterialSetVM vm)
		{
			MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "MaterialSet").MaterialSet;
			Material material = _unitOfWork.Material.Get(m => m.Id == vm.Material.Id, tracked: true);
			materialSet.Materials.Add(material);
			_unitOfWork.MaterialSet.Update(materialSet);
			var weight = Convert.ToDecimal(vm.Weight);
            materialSet.MaterialSetMaterials.Where(s => s.MaterialId == material.Id).FirstOrDefault().Weight = weight;
			_unitOfWork.MaterialSet.Update(materialSet);
			_unitOfWork.Save();

   //         MaterialSetMaterial materialSetMaterial = _unitOfWork.MaterialSetMaterial.Get(s => s.MaterialId == material.Id && s.MaterialSetId == materialSet.Id);
   //         materialSetMaterial.Weight = weight;

			//_unitOfWork.MaterialSetMaterial.Update(materialSetMaterial);
			//_unitOfWork.Save();
			return RedirectToAction("Create", new { jId = vm.Jewelry.Id });
		}

        public IActionResult DeleteGemstone(MaterialSetVM vm, int gemDeleteId)
        {
			MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "MaterialSet").MaterialSet;
			Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == gemDeleteId);
			materialSet.Gemstones.Remove(gemstone);
			_unitOfWork.MaterialSet.Update(materialSet);
			_unitOfWork.Save();
			
			return RedirectToAction("Create", new { jId = vm.Jewelry.Id });
		}

		public IActionResult DeleteMaterial(MaterialSetVM vm, int materialDeleteId)
		{
			MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "MaterialSet").MaterialSet;
			Material material = _unitOfWork.Material.Get(g => g.Id == materialDeleteId);
			materialSet.Materials.Remove(material);
			_unitOfWork.MaterialSet.Update(materialSet);
			_unitOfWork.Save();
			return RedirectToAction("Create", new { jId = vm.Jewelry.Id });
		}		
		public IActionResult EditMaterial(MaterialSetVM vm, int materialEditId)
		{
			//MaterialSet materialSet = _unitOfWork.Jewelry.Get(Jewelry => Jewelry.Id == vm.Jewelry.Id, includeProperties: "MaterialSet").MaterialSet;
			//Material material = _unitOfWork.Material.Get(m => m.Id == materialEditId);
			MaterialSetMaterial join = vm.MaterialSet.MaterialSetMaterials.Where(m => m.MaterialSetId == vm.MaterialSet.Id && m.MaterialId == materialEditId).FirstOrDefault();
			//join.Weight = weight;
			_unitOfWork.MaterialSetMaterial.Update(join);
			_unitOfWork.Save();
			return RedirectToAction("Create", new { jId = vm.Jewelry.Id });
		}

		private decimal GetPrice(int materialSetId)
		{
			return _unitOfWork.MaterialSet.GetTotalPrice(materialSetId);
		}

	}
}
