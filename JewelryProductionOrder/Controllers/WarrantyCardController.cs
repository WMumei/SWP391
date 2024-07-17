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
using System.Drawing;
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

        public IActionResult Create(int jId, int? redirectRequest)
		{



			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "Customer,MaterialSet,QuotationRequests");
			var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
			if (jewelry.MaterialSet == null && jewelry.QuotationRequests == null)
			{
				TempData["Error"] = "Please create Material Set and Quotation Request!";
				if (redirectRequest is not null)
					return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
				return RedirectToAction("Index", "Home");
			}
			else
			{

				WarrantyCardVM vm = new WarrantyCardVM
				{
					Jewelry = jewelry,
					WarrantyCard = new WarrantyCard { CreatedAt = DateTime.Now, ExpiredAt = DateTime.Now.AddYears(2) },

					Customer = customer

				};
				return View(vm);
			}
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
            
            //ewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id== id,includeProperties:"WarrantyCard,Customer");
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == id, includeProperties:"Customer,Jewelry");

   //         WarrantyCardVM vm = new()
          
			//{
				
			//	WarrantyCard = warrantyCard,
   //             Jewelry = warrantyCard.Jewelry,
   //             Customer= warrantyCard.Customer
   //     };
            
           
            return View(warrantyCard);
		}
		[HttpPost]
		public IActionResult Edit( WarrantyCard obj)

		{




			//	Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.Jewelry.Id, includeProperties: "WarrantyCard,Customer",tracked: false);



			// vm.WarrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == jewelry.WarrantyCard.Id,tracked: false);
			//if (vm.WarrantyCard == null)
			//{
			//	// Nếu không tìm thấy WarrantyCard, trả về lỗi
			//	return NotFound();
			//}

			//vm.WarrantyCard.CustomerId = vm.Customer.Id;


			//_unitOfWork.WarrantyCard.Update(vm.WarrantyCard); 




			//_unitOfWork.Save();
			//         return RedirectToAction("Index");
			try
			{
				// Lấy thông tin Jewelry liên quan
				

				
				WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(j => j.Id == obj.Id);
				warrantyCard.CreatedAt =obj.CreatedAt;
				warrantyCard.ExpiredAt = obj.ExpiredAt;
				

				
			
							

				// Đánh dấu đối tượng WarrantyCard là đã thay đổi
				_unitOfWork.WarrantyCard.Update(warrantyCard);

				// Lưu các thay đổi vào cơ sở dữ liệu
				_unitOfWork.Save();

				// Chuyển hướng đến trang Index
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				// Log lỗi và hiển thị thông báo lỗi
				// Bạn có thể sử dụng một công cụ logging như Serilog hoặc NLog để log lỗi
				Console.WriteLine(ex.Message);
				return View(obj);
			}


		}
		public IActionResult Details(int? id)
		{
			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(r => r.JewelryId == id, includeProperties: "Jewelry,Customer");
			
			WarrantyCardVM vm = new WarrantyCardVM
			{
				WarrantyCard = warrantyCard,
				Jewelry = warrantyCard.Jewelry,
				Customer = warrantyCard.Customer
			};
			return View(vm);
		}
	}
}
