using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Identity;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

namespace JewelryProductionOrder.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Create(Post post)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            post.CreatedAt = DateTime.Now;
            post.SalesStaffId = userId;

            _unitOfWork.Post.Add(post);
            _unitOfWork.Save();
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
            var post = _unitOfWork.Post.Get(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Sales)]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Post.Update(post);
                _unitOfWork.Save();
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
            _unitOfWork.Post.Remove(post);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
