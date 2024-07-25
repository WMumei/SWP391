using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Repositories.Repository.IRepository;

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
                    Name = user.UserName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = roleName,
                    Id = user.Id
                });
            }

            return Json(new { data = usersWithRoles });
        }

        //[HttpPost]
        //public IActionResult LockUnlock([FromBody]string id)
        //{
        //    var objFromDb = _userManager.Users.

        //    return Json(new { success = true, message = "Delete successful" });
        //}
        #endregion
    }
}
