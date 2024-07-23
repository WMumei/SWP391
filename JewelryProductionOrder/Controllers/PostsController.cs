﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Sales)]
        public async Task<IActionResult> Create(Post post, IFormFile ImagePath)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            post.CreatedAt = DateTime.Now;
            post.SalesStaffId = userId;

            if (ImagePath == null)
            {
                ModelState.AddModelError("ImagePath", "Please upload an image.");
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (ImagePath != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                string filePath = Path.Combine(wwwRootPath, @"Images");
                using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    ImagePath.CopyTo(fileStream);
                }
                post.Image = @"Images/" + fileName;
            }
            else
            {
                return NotFound();
            }

            _unitOfWork.Post.Add(post);
            _unitOfWork.Save();
            TempData["success"] = "Post created successfully";
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Index()
        {
            var posts = _unitOfWork.Post.GetAll(includeProperties: "SalesStaff").ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _unitOfWork.Post.Get(p => p.Id == id, includeProperties: "SalesStaff");
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        public IActionResult Edit(int id)
        {
            var post = _unitOfWork.Post.Get(p => p.Id == id, includeProperties: "SalesStaff");
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Edit(int id, string title, string content, string description, IFormFile ImagePath)
        {
            var post = _unitOfWork.Post.Get(p => p.Id == id, includeProperties: "SalesStaff");
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (ImagePath != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                    string filePath = Path.Combine(wwwRootPath, @"Images");
                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        ImagePath.CopyTo(fileStream);
                    }
                    post.Image = @"Images/" + fileName;
                }
                else
                {
                    return NotFound();
                }
                
                post.Title = title;
                post.Content = content;
                post.Description = description;

                _unitOfWork.Post.Update(post);
                _unitOfWork.Save();
                TempData["success"] = "Post updated successfully";
                return RedirectToAction("Index");
                
            }
            return View(post);
        }

        public IActionResult Delete(int id)
        {
            var post = _unitOfWork.Post.Get(p => p.Id == id, includeProperties: "SalesStaff");
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _unitOfWork.Post.Get(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(post.Image))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, post.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _unitOfWork.Post.Remove(post);
            _unitOfWork.Save();
            TempData["success"] = "Post deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
