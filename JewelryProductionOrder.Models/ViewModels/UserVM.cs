using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models.ViewModels
{
    public class UserVM
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,100}$", ErrorMessage = "Password must contain at least 1 lowercase letter, 1 uppercase letter, 1 digit, 1 non-alphanumeric character, and be between 6 and 100 characters long")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^[0-9]{8,15}$",
               ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string Role { get; set; }
        public SelectList? RoleSelectList { get; set; }
    }
}