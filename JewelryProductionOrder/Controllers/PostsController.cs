using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Repositories.Repository.IRepository;
using System.Security.Claims;

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

            if (post.Content == null)
            {
                TempData["error"] = "The post's content is empty";
                return RedirectToAction("Index");
            }

            if (ImagePath == null)
            {
                TempData["error"] = "Image upload failed. Please select an image.";
                return RedirectToAction("Index");
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

            post.Content = post.Content.Replace("../Images/", "/Images/");
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
            var post = _unitOfWork.Post.Get(p => p.Id == id, includeProperties: "SalesStaff,Comments,Comments.Owner,Comments.Replies,Comments.Replies.Owner");
            if (post == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewData["CurrentUserId"] = userId;

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
            if (post == null)
            {
                return NotFound();
            }

            if (content == null)
            {
                TempData["error"] = "The post's content is empty";
                return RedirectToAction("Index");
            }

            if (ImagePath == null)
            {
                TempData["error"] = "Image upload failed. Please select an image.";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (ImagePath != null)
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, post.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                    string filePath = Path.Combine(wwwRootPath, @"Images");
                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        ImagePath.CopyTo(fileStream);
                    }
                    post.Image = @"Images/" + fileName;
                }

                post.Title = title;
                post.Content = content;
                post.Description = description;

                _unitOfWork.Post.Update(post);
                _unitOfWork.Save();
                TempData["success"] = "Post updated successfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Model is invalid.";
                return RedirectToAction("Index");
            }
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

            foreach (var comment in post.Comments)
            {
                _unitOfWork.Comment.Remove(comment);
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

        [HttpPost]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { location = "" });
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(wwwRootPath, "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string fileUrl = Url.Content($"~/Images/{fileName}");
            return Json(new { location = fileUrl });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(int PostId, string Content)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var comment = new Comment
            {
                Content = Content,
                CreatedAt = DateTime.Now,
                OwnerId = userId,
                PostId = PostId
            };

            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Save();
            return RedirectToAction("Details", new { id = PostId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteComment(int CommentId, int PostId)
        {
            var comment = _unitOfWork.Comment.Get(c => c.Id == CommentId, includeProperties: "Replies");
            if (comment == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (comment.OwnerId != userId)
            {
                return Forbid();
            }

            DeleteCommentAndReplies(comment);

            _unitOfWork.Save();

            return RedirectToAction("Details", new { id = PostId });
        }

        private void DeleteCommentAndReplies(Comment comment)
        {
            foreach (var reply in comment.Replies.ToList())
            {
                DeleteCommentAndReplies(reply);
            }
            _unitOfWork.Comment.Remove(comment);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddReply(int PostId, int CommentId, string Content)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _unitOfWork.User.Get(u => u.Id == userId);

            var reply = new Comment
            {
                Content = "Reply to " + user.Name + ":<br />" + Content,
                CreatedAt = DateTime.Now,
                OwnerId = userId,
                PostId = PostId,
            };

            var parentComment = _unitOfWork.Comment.Get(c => c.Id == CommentId);

            if (parentComment != null)
            {
                parentComment.Replies.Add(reply);
                _unitOfWork.Comment.Update(parentComment);
            }

            _unitOfWork.Comment.Add(reply);
            _unitOfWork.Save();
            return RedirectToAction("Details", new { id = PostId });
        }
    }

}
