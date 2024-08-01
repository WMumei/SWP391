using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;

namespace JewelryProductionOrder.Controllers
{
	[Authorize(Roles = $"{SD.Role_Sales},{SD.Role_Manager},{SD.Role_Admin}")]
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
                if (objGemstone.Status != SD.StatusUnavailable && objGemstone.Status != SD.StatusAvailable)
                {
                    TempData["error"] = "Invalid status";
                    return View(objGemstone);
                }

                _unitOfWork.Gemstone.Add(objGemstone);
                _unitOfWork.Save();
                TempData["success"] = "Gemstone added";
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
                if (objGemstone.Status != SD.StatusUnavailable && objGemstone.Status != SD.StatusAvailable)
                {
                    TempData["error"] = "Invalid status";
                    return View(objGemstone);
                }
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
            if (id == 0)
            {
                return NotFound();
            }
            Gemstone? gemstoneFromDb = _unitOfWork.Gemstone.Get(u => u.Id == id && u.Status == SD.StatusAvailable);

            if (gemstoneFromDb == null)
            {
                return NotFound();
            }
            return View(gemstoneFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Gemstone? objGemstone = _unitOfWork.Gemstone.Get(u => u.Id == id && u.Status == SD.StatusAvailable);
            if (objGemstone == null)
            {
                return NotFound();
            }
            objGemstone.Status = SD.StatusUnavailable;
            _unitOfWork.Gemstone.Update(objGemstone);
            _unitOfWork.Save();
            TempData["success"] = "Gemstone removed";
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Gemstone> objGemstoneList = _unitOfWork.Gemstone.GetAll().Where(u => u.Status == "Available").ToList();
            return Json(new { data = objGemstoneList });
        }

        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var productToBeDeleted = _unitOfWork.Gemstone.Get(u => u.Id == id);
        //    if (productToBeDeleted == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    productToBeDeleted.Status = "Unavailable";
        //    _unitOfWork.Gemstone.Update(productToBeDeleted);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Gemstone removed";
        //    return Json(new { success = true, message = "Gemstone removed" });
        //}
        #endregion
    }
}
