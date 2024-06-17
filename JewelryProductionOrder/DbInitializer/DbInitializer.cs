using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProductionOrder.DbInitializer
{
    public class DbInitializer : IDbInitializer {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db) {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize() {


            //migrations if they are not applied
            try {
                if (_db.Database.GetPendingMigrations().Count() > 0) {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex) { }

            // Create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult()) {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Sales)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Production)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Design)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User {
                    UserName = "sales@example.com",
                    Email = "sales@example.com",
                    Name = "S01",
                    PhoneNumber = "1112223333",
                }, "Sales123*").GetAwaiter().GetResult();

                User sales = _db.Users.FirstOrDefault(u => u.Email == "sales@example.com");
                _userManager.AddToRoleAsync(sales, SD.Role_Sales).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "customer@example.com",
                    Email = "customer@example.com",
                    Name = "S01",
                    PhoneNumber = "1112223333",
                }, "Customer123*").GetAwaiter().GetResult();

                User customer = _db.Users.FirstOrDefault(u => u.Email == "customer@example.com");
                _userManager.AddToRoleAsync(customer, SD.Role_Customer).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "production@example.com",
                    Email = "production@example.com",
                    Name = "S01",
                    PhoneNumber = "1112223333",
                }, "Production123*").GetAwaiter().GetResult();

                User production = _db.Users.FirstOrDefault(u => u.Email == "production@example.com");
                _userManager.AddToRoleAsync(production, SD.Role_Production).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    Name = "S01",
                    PhoneNumber = "1112223333",
                }, "Admin123*").GetAwaiter().GetResult();

                User admin = _db.Users.FirstOrDefault(u => u.Email == "admin@example.com");
                _userManager.AddToRoleAsync(admin, SD.Role_Admin).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "design@example.com",
                    Email = "design@example.com",
                    Name = "S01",
                    PhoneNumber = "1112223333",
                }, "Design123*").GetAwaiter().GetResult();

                User design = _db.Users.FirstOrDefault(u => u.Email == "design@example.com");
                _userManager.AddToRoleAsync(design, SD.Role_Design).GetAwaiter().GetResult();

            }

            return;
        }
    }
}
