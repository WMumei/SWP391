using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace SWP391.Controllers
{
    public class QuotationRequestController : Controller

    {
        private readonly IUnitOfWork _unitOfWork;
        public QuotationRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<QuotationRequest> requests =  _unitOfWork.QuotationRequest.GetAllWithSaleStaffs().ToList();
            return View(requests);
        }
       public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(QuotationRequest obj)
        {
            obj.CreatedAt = DateTime.Now;
            _unitOfWork.QuotationRequest.Add(obj); //add object vào db
            _unitOfWork.Save(); //lưu thay đổi vào db
            return View();
        }
        
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            QuotationRequest? objFromDb = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (objFromDb == null)
			{
				return NotFound();
			}
        return View(objFromDb);
        }
        [HttpPost]
        public IActionResult Edit(QuotationRequest obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedAt = DateTime.Now;
                _unitOfWork.QuotationRequest.Update(obj);
                _unitOfWork.Save();
				return RedirectToAction("Index");
			}
            return View();
		}
		public IActionResult DeletePOST(int? id)
		{
			
			if (id == null)
			{
				return NotFound();
			}
			QuotationRequest objFromDb = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (objFromDb == null)
			{
				return NotFound();
			}
			return View(objFromDb);

		}
		[HttpPost,ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            QuotationRequest quorequest = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			if (quorequest == null) {
			 return NotFound();
			 }
			_unitOfWork.QuotationRequest.Remove(quorequest);
			_unitOfWork.Save();
			return RedirectToAction("Index");

		}
}
}
