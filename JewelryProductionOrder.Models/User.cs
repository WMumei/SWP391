using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
	public class User : IdentityUser
	{
		[StringLength(100)]
		public string? Name { get; set; }
		//public string? Email { get; set; }
		//public string? PhoneNumber { get; set; }
		[StringLength(200)]
		public string? Address { get; set; }

		//public int RoleId { get; set; }
		//[ForeignKey("RoleId")]
		//public Role? Role { get; set; }


	}
}
