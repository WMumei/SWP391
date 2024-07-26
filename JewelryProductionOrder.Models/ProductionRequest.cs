using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
	public class ProductionRequest
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public String Address { get; set; } = null!;
		public String PhoneNumber { get; set; } = null!;
		public String ContactName { get; set; } = null!;
		public String Email { get; set; } = null!;
		public String? Note { get; set; }
		public String? Status { get; set; }
		// Quantity of whole request
		public int? Quantity { get; set; }
		public String? SessionId { get; set; }
		public String? PaymentIntentId { get; set; }

		public string? CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		public User? Customer { get; set; }
		public string? DesignStaffId { get; set; }
		[ForeignKey("DesignStaffId")]
		public User? DesignStaff { get; set; }
		public string? ProductionStaffId { get; set; }
		[ForeignKey("ProductionStaffId")]
		public User? ProductionStaff { get; set; }

		public string? SalesStaffId { get; set; }
		[ForeignKey("SalesStaffId")]
		public User? SalesStaff { get; set; }

		public List<Jewelry> Jewelries { get; } = [];
		public List<ProductionRequestDetail> ProductionRequestDetails { get; } = [];

	}
}
