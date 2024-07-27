using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
	[Authorize]
	public class JewelryDesignController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public JewelryDesignController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = hostEnvironment;
		}
		public IActionResult Create(int jId)
		{
			JewelryDesign obj = new JewelryDesign
			{
				JewelryId = jId,
				Jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId)
			};
			return View(obj);
		}

		[HttpPost]
		[Authorize(Roles = SD.Role_Design)]
		public IActionResult Create(JewelryDesign obj, IFormFile? file, int? redirectRequest)
		{
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
				obj.DesignFile = Path.Combine("\\files", fileName);
			}
			obj.Status = SD.StatusPending;
			//obj.JewelryId = obj.Jewelry.Id;
			_unitOfWork.JewelryDesign.Add(obj);
			_unitOfWork.Save();
			if (redirectRequest is null)
				return RedirectToAction("Index", "Jewelry");
			return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
			//return View(new JewelryDesign { ProductionRequestId = obj.ProductionRequestId });
		}

		public IActionResult Index()
		{
			List<JewelryDesign> jewelries = _unitOfWork.JewelryDesign.GetAll().ToList();
			return View(jewelries);
		}

		public IActionResult Details(int jId)
		{
			JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.JewelryId == jId, includeProperties: "Jewelry");
			return View(design);
		}
		[Authorize(Roles = SD.Role_Customer)]
		public IActionResult CustomerApprove(int id, int? redirectRequest)
		{
			JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (design is not null)
			{
				design.CustomerId = userId;
				design.Status = SD.CustomerApproved;
			}
			_unitOfWork.JewelryDesign.Update(design);
			_unitOfWork.Save();

			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == design.JewelryId);
			jewelry.Status = SD.DesignApproved;
			_unitOfWork.Jewelry.Update(jewelry);
			_unitOfWork.Save();
			ProductionRequest req = _unitOfWork.ProductionRequest.Get(j => j.Id == jewelry.ProductionRequestId);
			req.Status = SD.DesignApproved;
			_unitOfWork.ProductionRequest.Update(req);
			_unitOfWork.Save();
			TempData["Success"] = "Approved";
			if (redirectRequest is null)
				return RedirectToAction("Index", "Home");
			return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
		}

		[Authorize(Roles = SD.Role_Customer)]
		public IActionResult CustomerDisapprove(int id, int? redirectRequest)
		{
			JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.Id == id);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (design is not null)
			{
				design.CustomerId = userId;
				design.Status = SD.CustomerDisapproved;
			}
			_unitOfWork.Save();
			TempData["Success"] = "Disapproved";

			if (redirectRequest is null)
				return RedirectToAction("Index", "Home");
			return RedirectToAction("RequestIndex", "Jewelry", new { reqId = redirectRequest });
		}

		//public IActionResult Manufacture(int jId)
		//{
		//	JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.JewelryId == jId);
		//	Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == jId);
		//	MaterialSet materialSet = _unitOfWork.MaterialSet.Get(m => m.Jewelries.FirstOrDefault().Id == jId, includeProperties: "Materials,Gemstones");
		//	ManufactureVM vm = new()
		//	{
		//		JewelryDesign = design,
		//		MaterialSet = materialSet,
		//		Jewelry = jewelry
		//	};
		//	return View(vm);
		//}

		[Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Design}")]
		public IActionResult ViewAll(int jId)
		{
			var jewelryDesign = _unitOfWork.JewelryDesign.GetAll(jD => jD.JewelryId == jId).ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			//if (User.IsInRole(SD.Role_Customer))
			//{
			//	jewelryDesign = jewelryDesign.Where(jD => jD.CustomerId == userId && jD.Status == SD.CustomerApproved).ToList();
			//	if (jewelryDesign.Count == 0)
			//	{
			//		jewelryDesign = _unitOfWork.JewelryDesign.GetAll(jD => jD.JewelryId == jId).ToList();
			//	}
			//}

			return View(jewelryDesign);
		}

	}
}
