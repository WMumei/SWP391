using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository;
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
            List<QuotationRequest> requests = _unitOfWork.QuotationRequest.GetAll().ToList();
            return View();
        }

        public IActionResult Details(int jId)
        {
            QuotationRequest request = _unitOfWork.QuotationRequest.Get(r => r.JewelryId == jId);
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "MaterialSet");
            QuotationRequestVM vm = new QuotationRequestVM
            {
                QuotationRequest = request,
                Jewelry = jewelry,
                MaterialSet = jewelry.MaterialSet
            };
            return View(request);
        }

        public IActionResult Create(int jId)
        {
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
            MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == jewelry.MaterialSetId, includeProperties:"Gemstones,Materials");
            QuotationRequestVM vm = new QuotationRequestVM
			{
				Jewelry = jewelry,
				QuotationRequest = new QuotationRequest {  },
                MaterialSet = jewelry.MaterialSet
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(QuotationRequestVM vm)
        {
			vm.QuotationRequest.CreatedAt = DateTime.Now;
            vm.QuotationRequest.Status = "Pending";
            MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Id == vm.MaterialSet.Id);
			vm.QuotationRequest.MaterialSetId = materialSet.Id;
            vm.QuotationRequest.JewelryId = vm.Jewelry.Id;
			vm.QuotationRequest.TotalPrice = vm.QuotationRequest.LaborPrice + materialSet.TotalPrice;
			_unitOfWork.QuotationRequest.Add(vm.QuotationRequest);
			_unitOfWork.Save();
			return View("Details", new { jId = vm.Jewelry.Id });
        }

		public IActionResult ManagerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			User manager = _unitOfWork.User.Get(u => u.Id == "3");
			if (req is not null)
			{
				req.ManagerId = manager.Id;
				req.Status = $"Approved by Manager";
			}
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
		public IActionResult CustomerApprove(int id)
		{
			QuotationRequest req = _unitOfWork.QuotationRequest.Get(req => req.Id == id);
			User customer = _unitOfWork.User.Get(u => u.Id == "2");
			if (req is not null)
			{
				req.CustomerId = customer.Id;
				req.Status = $"Approved by Customer";
			}
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}

		//[HttpPost,ActionName("Delete")]
		//public IActionResult DeletePOST(int? id)
		//{
		//    QuotationRequest quorequest = _unitOfWork.QuotationRequest.Find(id);
		//    if (quorequest == null)
		//    {
		//        return NotFound();
		//    }
		//    _unitOfWork.QuotationRequest.Remove(quorequest);
		//    _unitOfWork.SaveChanges();
		//    return RedirectToAction("Index");

		//}
	}
}
