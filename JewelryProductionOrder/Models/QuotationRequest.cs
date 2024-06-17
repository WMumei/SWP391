using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JewelryProductionOrder.Models
{
    public class QuotationRequest
    {
        [Key]
        public int Id { get; set; }
        public string? Status {  get; set; }
        public string Name { get; set; }
        public decimal LaborPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }


        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry? Jewelry { get; set; }

        //public int ProductionRequestId { get; set; }
        //[ForeignKey("ProductionRequestId")]
        //public ProductionRequest ProductionRequest { get; set; }

        public int MaterialSetId { get; set; }
        [ForeignKey("MaterialSetId")]
        public MaterialSet? MaterialSet { get; set; }

        public int? SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }

        public int? CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		public User? Customer { get; set; }

		public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public User? Manager { get; set; }
    }
}
