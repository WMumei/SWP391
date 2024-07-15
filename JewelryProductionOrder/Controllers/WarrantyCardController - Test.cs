//using JewelryProductionOrder.Data;
//using JewelryProductionOrder.Models;
//using JewelryProductionOrder.Models.ViewModels;
//using JewelryProductionOrder.Repositories.IRepository;
//using JewelryProductionOrder.Utility;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Models.Repositories.Repository.IRepository;
//using System;
//using System.Security.Claims;
//using System.Security.Cryptography;

//namespace JewelryProductionOrder.Controllers
//{
//	public class WarrantyCardController : Controller
//	{
//		//private readonly ApplicationDbContext _db;
//		private readonly IWarrantyCardRepository _warrantyCardRepo;
//		private readonly IUnitOfWork _unitOfWork;
//		private readonly UserManager<User> _userManager;
//		//private string userId;

//		public WarrantyCardController(IUnitOfWork unitOfWork, UserManager<User> userManager)
//		{
//			_unitOfWork = unitOfWork;
//			_userManager = userManager;
//		}

//        public IActionResult Create(int jId)
//		{

			

//            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId, includeProperties: "Customer");
//		    var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
//			if(jewelry.MaterialSet ==null && jewelry.QuotationRequests == null)
//			{
//                TempData["WarningMessage"] = "Please create Material Set and Quotation Request!";
//            }
//			WarrantyCardVM vm = new WarrantyCardVM
//			{
//				Jewelry = jewelry,
//				WarrantyCard = new WarrantyCard { CreatedAt = DateTime.Now, ExpiredAt = DateTime.Now.AddYears(2) },
//				//CreatedAt = DateTime.Now,
//                //ExpiredAt = DateTime.Now,
//                Customer = customer
//				//CustomerId = customer.Id
//			};
//            return View(vm);
//        }
		
        
//        [HttpPost]
//		[Authorize(Roles = SD.Role_Sales)]
//		public IActionResult Create(WarrantyCardVM vm)
//		{
//            //lưu người tạo
//            var claimsIdentity = (ClaimsIdentity)User.Identity;
//			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
//			vm.WarrantyCard.SalesStaffId = userId;
			
//			vm.WarrantyCard.JewelryId = vm.Jewelry.Id;
//            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == vm.WarrantyCard.JewelryId, includeProperties: "Customer");
//            var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId );
            
//            _unitOfWork.Save();
           
       

            
            
//			vm.WarrantyCard.CustomerId = customer.Id;
			
//			_unitOfWork.WarrantyCard.Add(vm.WarrantyCard);
//			_unitOfWork.Save();
//			return RedirectToAction("Index", "Jewelry");
//		}
//		public IActionResult Index()
//		{
//			List<WarrantyCard> objWarrantyCardList = _unitOfWork.WarrantyCard.GetAll(includeProperties: "Jewelry,Customer").ToList();
//			//IEnumerable<SelectListItem>
//			return View(objWarrantyCardList);
//		}
//		/*public IActionResult Delete(int? id)
//		{
//			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);
			
			
//			return View(warrantyCard);
//		}
//		*/
//		//[HttpPost, ActionName("Delete")]
//		//[HttpDelete]
		
//		public IActionResult DeletePost(int? id)
//		{

//			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id);
//            if (warrantyCard == null)
//			{
//				return NotFound();
//			}
//			_unitOfWork.WarrantyCard.Remove(warrantyCard);
//			_unitOfWork.Save();
//			TempData["success"] = "Warranty Card is deleted successfully!";
//			return RedirectToAction("Index");
//		}
//        //private readonly ApplicationDbContext _context;

//        //public WarrantyCardController(ApplicationDbContext context)
//        //{
//        //    _context = context;
//        //}

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.WarrantyCard.Id == id, includeProperties: "Customer");
//            var customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
//            //var product =  _unitOfWork.WarrantyCard.Get(u => u.Id == id);
//            WarrantyCardVM vm = new()
//            {
//                WarrantyCard = _unitOfWork.WarrantyCard.Get(u => u.Id == id),

//                Jewelry = jewelry,
//                Customer = customer
//            };
//            return View(vm);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedAt,ExpiredAt,CustomerId,JewelryId,SalesStaffId")] WarrantyCardVM product)
//        {
//            //if (id != product.Id)
//            //{
//            //    return NotFound();
//            //}

            
//                try
//                {
//                    _unitOfWork.WarrantyCard.Update(product.WarrantyCard);
//                     _unitOfWork.Save();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    //if (!ProductExists(product.Id))
//                    //{
//                        return NotFound();
//                    //}
//                    //else
//                    //{
//                    //    throw;
//                    //}
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            //return View(product);
//            //return RedirectToAction(nameof(Index));
        

//        //private bool ProductExists(int id)
//        //{
//        //    return _unitOfWork.WarrantyCard.Get(e => e.Id == id);
//        //}
      
//    public IActionResult Details(int? id)
//		{
//			WarrantyCard warrantyCard = _unitOfWork.WarrantyCard.Get(r => r.JewelryId == id, includeProperties: "Jewelry,Customer");
//			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == id, includeProperties: "Customer");
//            User customer = _unitOfWork.User.Get(u => u.Id == jewelry.CustomerId);
//			WarrantyCardVM vm = new WarrantyCardVM
//			{
//				WarrantyCard = warrantyCard,
//				Jewelry = jewelry,
//				Customer = customer
//			};
//			return View(vm);
//		}
//	}
//}
