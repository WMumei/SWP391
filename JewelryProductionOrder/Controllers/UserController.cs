using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Repositories.Repository.IRepository;
using NuGet.Protocol.Plugins;

namespace JewelryProductionOrder.Controllers
{
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

        public IActionResult RoleManagement(string userId)
        {
            return View();
        }

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

            if (objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd= DateTime.Now.AddDays(7);
            }
            _unitOfWork.User.Update(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Operation successful" });
        }
        #endregion
    }
}
