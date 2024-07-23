using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;

namespace JewelryProductionOrder.Controllers
{
    public class GemstoneController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GemstoneController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Gemstone> objGemstoneList = _unitOfWork.Gemstone.GetAll().Where(u => u.Status == "Available").ToList();
            return View(objGemstoneList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gemstone objGemstone)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Gemstone.Add(objGemstone);
                _unitOfWork.Save();
                TempData["success"] = "Gemstone added";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Gemstone? gemstoneFromDb = _unitOfWork.Gemstone.Get(u => u.Id == id);
            if (gemstoneFromDb == null)
            {
                return NotFound();
            }
            return View(gemstoneFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Gemstone objGemstone)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Gemstone.Update(objGemstone);
                _unitOfWork.Save();
                TempData["success"] = "Gemstone updated";
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
        }

        public IActionResult Delete(int id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            Gemstone? gemstoneFromDb = _unitOfWork.Gemstone.Get(u =>u.Id == id);

            if (gemstoneFromDb == null)
            {
                return NotFound();
            }
            return View(gemstoneFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Gemstone? objGemstone = _unitOfWork.Gemstone.Get(u => u.Id == id);
            if (objGemstone == null)
            {
                return NotFound();
            }
            objGemstone.Status = "Unavailable";
            _unitOfWork.Gemstone.Update(objGemstone);
            _unitOfWork.Save();
            TempData["success"] = "Gemstone removed";
            return RedirectToAction("Index");
        }
    }
}
