using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;
using System.IO.Compression;
using System.Security.Cryptography;


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
		public IActionResult Create(JewelryDesign obj, List<IFormFile> files , int? redirectRequest)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			obj.DesignStaffId = userId;
			
			Jewelry jewelry = _unitOfWork.Jewelry.Get(j => j.Id == obj.JewelryId);
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(r => r.Id == jewelry.ProductionRequestId,tracked:true);
            productionRequest.DesignStaffId = userId;
			
			_unitOfWork.Save();
			obj.CreatedAt = DateTime.Now;
			if (obj.Name is null)
			{
				ModelState.AddModelError("Name", "Please enter name for design.");
			}
			if (files != null && files.Count > 0)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
                List<string> designFiles = new List<string>();
  
                foreach (var file in files)
				{
					
					
						string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
						string filePath = Path.Combine(wwwRootPath, @"files");
						using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
						{
							file.CopyTo(fileStream);
						}
                    //obj.DesignFile = Path.Combine("\\files", fileName);
                    designFiles.Add(Path.Combine("\\files", fileName));
				}
                obj.DesignFile = string.Join(",", designFiles);
                obj.Status = SD.StatusPending;
				obj.CustomerId = jewelry.CustomerId;
				_unitOfWork.JewelryDesign.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Created";
				
                if (redirectRequest is null)
                    return RedirectToAction("Index", "Home");
                return RedirectToAction("ViewAll", new { jId = obj.JewelryId });
            }
			else
			{
				ModelState.AddModelError("DesignFile", "At least one image file is required.");
				//return View(obj);
			}
			return View(obj);
            
        }
        public IActionResult DownloadAllFiles(int id)
        {
            var jewelryDesign = _unitOfWork.JewelryDesign.Get(u => u.Id == id);
            if (jewelryDesign == null || string.IsNullOrEmpty(jewelryDesign.DesignFile))
            {
                return NotFound();
            }

            var fileUrls = jewelryDesign.DesignFile.Split(',').Select(f => f.Trim()).ToList();
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            if (fileUrls.Count == 1)
            {
                // Single file download
                var fileUrl = fileUrls[0];
                var filePath = Path.Combine(wwwRootPath, fileUrl.Replace("/", "\\").TrimStart('\\'));
                if (System.IO.File.Exists(filePath))
                {
                    var fileBytes = System.IO.File.ReadAllBytes(filePath);
                    var fileName = Path.GetFileName(filePath);
                    return File(fileBytes, "application/octet-stream", fileName);
                }
			}
			else
			{
                var tempZipPath = Path.Combine(wwwRootPath, $"DesignFiles_{id}.zip");
                using (var zipArchive = ZipFile.Open(tempZipPath, ZipArchiveMode.Create))
                {
                    foreach (var fileUrl in fileUrls)
                    {
                        var filePath = Path.Combine(wwwRootPath, fileUrl.Replace("/", "\\").TrimStart('\\'));
                        if (System.IO.File.Exists(filePath))
                        {
                            zipArchive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                        }
                    }
                }
                var fileBytes = System.IO.File.ReadAllBytes(tempZipPath);
                System.IO.File.Delete(tempZipPath);

                return File(fileBytes, "application/zip", $"DesignFiles_{id}.zip");
            }
			return NotFound();
        }

		//public IActionResult Index()
		//{
		//	List<JewelryDesign> jewelries = _unitOfWork.JewelryDesign.GetAll().ToList();
		//	return View(jewelries);
		//}

		[Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Design},{SD.Role_Production}")]
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
			return RedirectToAction("Details", new { id = design.Id });
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

			return RedirectToAction("Details", new { id = design.Id });
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

		[Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Design},{SD.Role_Production}")]
		public IActionResult ViewAll(int jId)
		{
			var jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(jD => jD.JewelryId == jId, includeProperties: "Jewelry").ToList();
			Jewelry jewelry = _unitOfWork.Jewelry.Get(r => r.Id == jId);
			ProductionRequest productionRequest = _unitOfWork.ProductionRequest.Get(r => r.Id == jewelry.ProductionRequestId);
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (User.IsInRole(SD.Role_Customer))
			{
				//jewelryDesign = jewelryDesign.Where(jD => jD.CustomerId == userId && jD.Status == SD.CustomerApproved).ToList();
				jewelryDesigns = jewelryDesigns.Where(jD => jD.CustomerId == jewelry.CustomerId).ToList();
				//if (jewelryDesigns.Count == 0)
				//{
				//	jewelryDesigns = _unitOfWork.JewelryDesign.GetAll(jD => jD.JewelryId == jId, includeProperties: "Jewelry").ToList();
				//}
			}
			else if (User.IsInRole(SD.Role_Design))
			{
				jewelryDesigns = jewelryDesigns.Where(jD => jD.DesignStaffId == productionRequest.DesignStaffId).ToList();
			}

			return View(jewelryDesigns);
		}

	}
}
