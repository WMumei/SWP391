using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	public class BaseDesignController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public BaseDesignController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = hostEnvironment;
		}

		public IActionResult Create()
		{
			BaseDesign obj = new BaseDesign
			{
			};
			return View(obj);
		}

		[HttpPost]
		[Authorize]
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

			if (User.IsInRole("Customer")) obj.Type = "Customer";
			else obj.Type = "Company";

			_unitOfWork.BaseDesign.Add(obj);
			_unitOfWork.Save();

			ShoppingCart shoppingCart = new ShoppingCart
			{
				BaseDesignId = obj.Id,
				Quantity = 1,
				UserId = userId
			};
			_unitOfWork.ShoppingCart.Add(shoppingCart);
			_unitOfWork.Save();

			TempData["success"] = "Create successfully";

			return RedirectToAction("Index", "Home");
		}

	}
}
