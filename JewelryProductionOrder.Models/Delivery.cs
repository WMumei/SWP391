using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
	[PrimaryKey(nameof(CustomerId), nameof(SalesStaffId), nameof(JewelryId), nameof(WarrantyCardId))]
	public class Delivery
	{
		public string CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		public User? Customer { get; set; }

		public string SalesStaffId { get; set; }
		[ForeignKey("SalesStaffId")]
		public User? SalesStaff { get; set; }

		public int JewelryId { get; set; }
		[ForeignKey("JewelryId")]
		public Jewelry Jewelry { get; set; }

		public int WarrantyCardId { get; set; }
		[ForeignKey("WarrantyCardId")]
		public WarrantyCard WarrantyCard { get; set; }

		public DateTime DeliveredAt { get; set; }
	}
}
