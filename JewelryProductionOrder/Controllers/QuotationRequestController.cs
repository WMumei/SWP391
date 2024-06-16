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
        
       
        
        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeletePOST(int id)
        //{
            //QuotationRequest quorequest = _unitOfWork.QuotationRequest.Find(id);
           // if (quorequest == null) {
              //  return NotFound();
            // }
            //_unitOfWork.QuotationRequests.Remove(quorequest);
            //_db.SaveChanges();
           // return RedirectToAction("Index");

        }
    }
}
