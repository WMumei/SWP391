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
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			obj.DesignStaffId = userId;
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == obj.JewelryId);
			obj.CreatedAt = DateTime.Now;
			
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (file is null)
			{
				ModelState.AddModelError("DesignFile", "Design file is null.");
                if (obj.Name is null)
                {
                    ModelState.AddModelError("Name", "Please enter name for design.");
                }

            }
			else
			//if (file is not null)
			{ 
				if(obj.Name is null)
				{
                    ModelState.AddModelError("Name", "Please enter name for design.");
				}
				else
				{
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(wwwRootPath, @"files");
                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.DesignFile = Path.Combine("\\files", fileName);

                    obj.Status = SD.StatusPending;
					obj.CustomerId = jewelry.CustomerId;
					_unitOfWork.JewelryDesign.Add(obj);
                    _unitOfWork.Save();
                    //DateTime vmCreatedAt = (DateTime)obj.CreatedAt;
                    //var oldDesigns = _unitOfWork.JewelryDesign
                    //    .GetAll(r => r.JewelryId == obj.JewelryId && r.CreatedAt < vmCreatedAt)
                    //    .OrderByDescending(r => r.CreatedAt);
                    //foreach (var oldDesign in oldDesigns)
                    //{
                    //    oldDesign.Status = SD.StatusDiscontinued;
                    //    _unitOfWork.Save();
                    //}
                   
                }
                TempData["success"] = "Created";

				return RedirectToAction(nameof(Details), new { id = obj.Id });
            }
            return RedirectToAction(nameof(Create), new { jId = obj.JewelryId });
            
        }

		//public IActionResult Index()
		//{
		//	List<JewelryDesign> jewelries = _unitOfWork.JewelryDesign.GetAll().ToList();
		//	return View(jewelries);
		//}

		public IActionResult Details(int id)
		{
			JewelryDesign design = _unitOfWork.JewelryDesign.Get(design => design.Id == id, includeProperties: "Jewelry");
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
			
			var oldDesigns = _unitOfWork.JewelryDesign
				.GetAll(r => r.JewelryId == design.JewelryId && r.Status != SD.CustomerApproved)
				.OrderByDescending(r => r.CreatedAt);
			foreach (var oldDesign in oldDesigns)
			{
				oldDesign.Status = SD.StatusDiscontinued;
				_unitOfWork.Save();
			}

			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == design.JewelryId);
			jewelry.Status = SD.StatusDesignApproved;
			_unitOfWork.Jewelry.Update(jewelry);
			_unitOfWork.Save();


			ProductionRequest req = _unitOfWork.ProductionRequest.Get(j => j.Id == jewelry.ProductionRequestId, includeProperties: "Jewelries", tracked: true);
            bool completed = true;
            foreach (var j in req.Jewelries)
            {
                if (j.Status != SD.StatusDesignApproved)
                {
                    completed = false;
                    break;
                }
            }
            if (completed)
            {
                req.Status = SD.StatusAllDesignApproved;
                
            }
            
			
			_unitOfWork.Save();
			TempData["Success"] = "Approved";
			if (redirectRequest is null)
				return RedirectToAction("Index", "Home");
			return RedirectToAction("Details", new { id = design.Id });
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
            _unitOfWork.JewelryDesign.Update(design);
            _unitOfWork.Save();
			TempData["Success"] = "Disapproved";

			if (redirectRequest is null)
				return RedirectToAction("Index", "Home");
			return RedirectToAction("Details", new { id = design.Id });
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
			var jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(jD => jD.JewelryId == jId, includeProperties: "Jewelry").ToList();
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (User.IsInRole(SD.Role_Customer))
			{
				//jewelryDesign = jewelryDesign.Where(jD => jD.CustomerId == userId && jD.Status == SD.CustomerApproved).ToList();
				jewelryDesigns = jewelryDesigns.Where(jD => jD.CustomerId == userId).ToList();
				//if (jewelryDesigns.Count == 0)
				//{
				//	jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(jD => jD.JewelryId == jId, includeProperties: "Jewelry").ToList();
				//}
			}

			return View(jewelryDesigns);
		}

	}
}
