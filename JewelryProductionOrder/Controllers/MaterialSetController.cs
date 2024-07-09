using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Repositories.Repository.IRepository;

namespace SWP391.Controllers
{
    public class MaterialSetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MaterialSetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
            return View(materialSetVM);
        }
        [HttpPost]
        public IActionResult Create(MaterialSetVM materialSetVM)
        {
            MaterialSet materialSet = new MaterialSet { CreatedAt = DateTime.Now };

			Gemstone gemstone = _unitOfWork.Gemstone.Get(g => g.Id == materialSetVM.Gemstone.Id, tracked: true);
			Material material = _unitOfWork.Material.Get(m => m.Id == materialSetVM.Material.Id, tracked: true);

			materialSet.Materials.Add(material);
            materialSet.Gemstones.Add(gemstone);
            _unitOfWork.MaterialSet.Add(materialSet);
            _unitOfWork.Save();
            var weight = Convert.ToDecimal(materialSetVM.Weight);
            materialSet.MaterialSetMaterials.First().Weight = weight;
            materialSet.TotalPrice = material.Price * weight + gemstone.Price;
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == materialSetVM.Jewelry.Id);
            jewelry.MaterialSetId = materialSet.Id;
            _unitOfWork.Jewelry.Update(jewelry);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Jewelry");
            //return RedirectToAction("Create", new { jId = jewelry.Id});
        }
        public IActionResult Index()
        {
            List<MaterialSet> obj = _unitOfWork.MaterialSet.GetAll().ToList();
            return View(obj);
        }

    }
}
