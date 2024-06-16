using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.Repositories.Repository.IRepository;

namespace SWP391.Controllers
{
    public class ProductionRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductionRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(ProductionRequest obj)
        //{
        //    obj.CreatedAt = DateTime.Now;

        //    OrderVM orderVM = new OrderVM
        //    {
        //        ProductionRequest = obj,
        //        Customer = new User()
        //    };
        //    return View("Checkout", orderVM);
        //}
        public IActionResult Checkout()
        {
            OrderVM orderVM = new OrderVM
            {
                ProductionRequest = new ProductionRequest { Quantity = 1},
                Customer = new User {}
            };
            return View(orderVM);
        }
        [HttpPost]
        public IActionResult Checkout(OrderVM orderVM)
        {
            orderVM.Customer.RoleId = 2;
            _unitOfWork.User.Add(orderVM.Customer);
            _unitOfWork.Save();

            orderVM.ProductionRequest.CustomerId = orderVM.Customer.Id;
            _unitOfWork.ProductionRequest.Add(orderVM.ProductionRequest);
            _unitOfWork.Save();
            return View();
        }
        public IActionResult Index()
        {
            List<ProductionRequest> obj = _unitOfWork.ProductionRequest.GetAllWithCustomers().ToList();
            return View(obj);
        }

        //[HttpPost]
        public IActionResult TakeRequest(int id)
        {
            ProductionRequest req = _unitOfWork.ProductionRequest.Get(req => req.Id == id);
            User staff = _unitOfWork.User.Get(u => u.Id == 2);
            if (req is not null)
            {
                req.SalesStaffId = staff.Id;
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
