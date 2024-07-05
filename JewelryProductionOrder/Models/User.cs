﻿using Microsoft.AspNetCore.Identity;

namespace JewelryProductionOrder.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        //public string? Email { get; set; }
        //public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        //public int RoleId { get; set; }
        //[ForeignKey("RoleId")]
        //public Role? Role { get; set; }


    }
}
