using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	[Authorize]
	public class BaseDesignController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public BaseDesignController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = hostEnvironment;
		}
		[Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Design}")]
		public IActionResult Create()
		{
			BaseDesign obj = new BaseDesign
			{
			};
			return View(obj);
		}

		[HttpPost]
		[Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Design}")]
		public IActionResult Create(BaseDesign obj, IFormFile? file)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			obj.CreatedAt = DateTime.Now;

			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (file is not null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				string filePath = Path.Combine(wwwRootPath, @"files");
				using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
				obj.Image = Path.Combine("\\files", fileName);
			}

			if (User.IsInRole(SD.Role_Customer)) obj.Type = "Customer";
			else obj.Type = "Company";

			_unitOfWork.BaseDesign.Add(obj);
			_unitOfWork.Save();
			if (User.IsInRole(SD.Role_Customer))
			{
				ShoppingCart shoppingCart = new ShoppingCart
				{
					BaseDesignId = obj.Id,
					Quantity = 1,
					UserId = userId
				};
				_unitOfWork.ShoppingCart.Add(shoppingCart);
				_unitOfWork.Save();
			}

			TempData["success"] = "Create successfully";
			if (User.IsInRole("Customer"))
			{
				return RedirectToAction("RequestIndex", "Jewelry");
			}
			return RedirectToAction("Index");
		}

		[Authorize(Roles = $"{SD.Role_Manager},{SD.Role_Design}")]
		public IActionResult Index()
		{
			List<BaseDesign> designList = _unitOfWork.BaseDesign.GetAll().ToList();
			return View(designList);
		}

		[Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Design},{SD.Role_Manager},{SD.Role_Sales}")]
		public IActionResult Details(int bId)
		{
			BaseDesign design = _unitOfWork.BaseDesign.Get(design => design.Id == bId);
			return View(design);
		}

		[Authorize(Roles = $"{SD.Role_Design}")]
		public IActionResult Edit(int bId)
		{
			var baseDesign = _unitOfWork.BaseDesign.Get(m => m.Id == bId);
			if (baseDesign == null)
			{
				return NotFound();
			}
			return View(baseDesign);
		}

		[HttpPost]
		[Authorize(Roles = $"{SD.Role_Design}")]
		public IActionResult Edit(BaseDesign baseDesign, IFormFile? file)
		{
			var existingDesign = _unitOfWork.BaseDesign.Get(d => d.Id == baseDesign.Id);
			if (existingDesign == null)
			{
				return NotFound();
			}

			existingDesign.Name = baseDesign.Name;
			existingDesign.Description = baseDesign.Description;

			
			if (file is not null)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				string filePath = Path.Combine(wwwRootPath, @"files");
				using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
				existingDesign.Image = Path.Combine("\\files", fileName);
			}

			_unitOfWork.BaseDesign.Update(existingDesign);
			_unitOfWork.Save();

			if (User.IsInRole("Customer"))
			{
				return RedirectToAction("RequestIndex", "Jewelry");
			}
			return RedirectToAction("Index");
		}

		[Authorize(Roles = $"{SD.Role_Design}")]
		public IActionResult Delete(int bId)
		{
			BaseDesign baseDesign = _unitOfWork.BaseDesign.Get(bD => bD.Id == bId);
			if (baseDesign == null)
			{
				return NotFound();
			}
			_unitOfWork.BaseDesign.Remove(baseDesign);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
}
