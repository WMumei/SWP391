﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JewelryProductionOrder.Models.ViewModels
{

    public class UserVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string Role { get; set; }
	}

}