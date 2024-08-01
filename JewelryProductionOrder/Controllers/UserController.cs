using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Repositories.Repository.IRepository;

namespace JewelryProductionOrder.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserController(IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var model = new UserVM
            {
                RoleSelectList = new SelectList(roles, "Name", "Name")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = userVM.Name,
                    UserName = userVM.Email,
                    Email = userVM.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(userVM.Role))
                    {
                        await _userManager.AddToRoleAsync(user, userVM.Role);
                    }
                    TempData["success"] = "Account created";
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            TempData["error"] = "An account with this email has already existed";
            var roles = await _roleManager.Roles.ToListAsync();
            userVM.RoleSelectList = new SelectList(roles, "Name", "Name");
            return View(userVM);
        }

        //public async Task<IActionResult> RoleManagement(string userId)
        //{
        //	var user = _unitOfWork.User.Get(u => u.Id == userId);
        //	var userRoles = await _userManager.GetRolesAsync(user);
        //	var allRoles = await _roleManager.Roles.ToListAsync();
        //	var userVM = new UserVM
        //	{
        //		Id = user.Id,
        //		Name = user.Name,
        //		UserName = user.UserName,
        //		Email = user.Email,
        //		LockoutEnd = user.LockoutEnd,
        //		Role = string.Join(", ", userRoles),
        //		RoleSelectList = new SelectList(allRoles, "Name", "Name")
        //	};
        //	return View(userVM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RoleManagement(UserVM userVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _unitOfWork.User.Get(u => u.Id == userVM.Id);
        //        var userRoles = await _userManager.GetRolesAsync(user);

        //        // Remove old roles
        //        foreach (var oldRole in userRoles)
        //        {
        //            await _userManager.RemoveFromRoleAsync(user, oldRole);
        //        }

        //        // Add new role
        //        await _userManager.AddToRoleAsync(user, userVM.Role);

        //        TempData["success"] = "Permission updated";
        //        return RedirectToAction("Index");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        //        {
        //                Debug.WriteLine(error.ErrorMessage);
        //        }
        //        // ...
        //    }
        //    return View();
        //}

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = _unitOfWork.User.GetAll().ToList();
            List<UserVM> usersWithRoles = new List<UserVM>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var roleName = string.Join(", ", userRoles);
                usersWithRoles.Add(new UserVM
                {
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = roleName,
                    LockoutEnd = user.LockoutEnd,
                    Id = user.Id
                });
            }

            return Json(new { data = usersWithRoles });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _unitOfWork.User.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddDays(7);
            }
            _unitOfWork.User.Update(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Operation successful" });
        }
        #endregion
    }
}
