using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Repositories.IRepository;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Repositories.Repository.IRepository;
using System;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JewelryProductionOrder.Controllers
{
	public class WarrantyCardController : Controller
	{
		//private readonly ApplicationDbContext _db;
		private readonly IWarrantyCardRepository _warrantyCardRepo;
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;
		//private string userId;

		public WarrantyCardController(IUnitOfWork unitOfWork, UserManager<User> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

        public IActionResult Create(int jId)
		{

			

            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "Customer");
		    var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
			if(jewelry.MaterialSet ==null && jewelry.QuotationRequests == null)
			{
                TempData["WarningMessage"] = "Please create Material Set and Quotation Request!";
            }
			WarrantyCardVM vm = new WarrantyCardVM
			{
				Jewelry = jewelry,
				WarrantyCard = new WarrantyCard { CreatedAt = DateTime.Now, ExpiredAt = DateTime.Now.AddYears(2) },
				//CreatedAt = DateTime.Now,
                //ExpiredAt = DateTime.Now,
                Customer = customer
				//CustomerId = customer.Id
			};
            return View(vm);
        }
		
        
        [HttpPost]
		[Authorize(Roles = SD.Role_Sales)]
		public IActionResult Create(WarrantyCardVM vm)
		{
            //lưu người tạo
            var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			vm.WarrantyCard.SalesStaffId = userId;
			
			vm.WarrantyCard.JewelryId = vm.Jewelry.Id;
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.WarrantyCard.JewelryId, includeProperties: "Customer");
            var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId );
            
            _unitOfWork.Save();
           
       

            
            
			vm.WarrantyCard.CustomerId = customer.Id;
			
			_unitOfWork.WarrantyCard.Add(vm.WarrantyCard);
			_unitOfWork.Save();
			return RedirectToAction("Index", "Jewelry");
		}
		public IActionResult Index()
		{
			List<WarrantyCard> objWarrantyCardList = _unitOfWork.WarrantyCard.GetAll(includeProperties: "Jewelry,Customer").ToList();
			//IEnumerable<SelectListItem>
			return View(objWarrantyCardList);
		}
		/*public IActionResult Delete(int? id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);
			
			
			return View(warrantyCard);
		}
		*/
		//[HttpPost, ActionName("Delete")]
		//[HttpDelete]
		
		public IActionResult DeletePost(int? id)
		{

			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);
            if (warrantyCard == null)
			{
				return NotFound();
			}
			_unitOfWork.WarrantyCard.Remove(warrantyCard);
			_unitOfWork.Save();
			TempData["success"] = "Warranty Card is deleted successfully!";
			return RedirectToAction("Index");
		}
		
		public IActionResult Edit(int id)

		{
            //WarrantyCard warrantyCardFromDb = _unitOfWork.WarrantyCard.Get(u => u.Id == id, includeProperties: "Jewelry,Customer");
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.WarrantyCard.Id== id, includeProperties: "Customer");
			var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
			WarrantyCardVM vm = new()
			{
				WarrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id, includeProperties: "Jewelry,Customer"),
				//Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == WarrantyCard.JewelryId, includeProperties: "Customer"),
				Jewelry = jewelry,
              Customer= customer
        };
			//vm.WarrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);

            return View(vm);
		}
		[HttpPost]
		public IActionResult Edit(WarrantyCardVM vm)
			//not yet
		{
			//lưu người sửa
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            vm.WarrantyCard.SalesStaffId = userId;

           // vm.WarrantyCard.JewelryId = vm.Jewelry.Id;
            
            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id, includeProperties: "Customer");
            var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
            _unitOfWork.Save();
            vm.WarrantyCard.CustomerId = customer.Id;
           
			
			//vm.WarrantyCard.Jewelry = jewelry;
            _unitOfWork.WarrantyCard.Update(vm.WarrantyCard); //câu lệnh này bị lỗi conflict id của jewelry table

                _unitOfWork.Save();
                return RedirectToAction("Index");
           


            


            //return View(vm);
            //return RedirectToAction("Index");
        }
    public IActionResult Details(int? id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(r => r.JewelryId == id, includeProperties: "Jewelry,Customer");
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == id, includeProperties: "Customer");
            User customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
			WarrantyCardVM vm = new WarrantyCardVM
			{
				WarrantyCard = warrantyCard,
				Jewelry = jewelry,
				Customer = customer
			};
			return View(vm);
		}
	}
}
