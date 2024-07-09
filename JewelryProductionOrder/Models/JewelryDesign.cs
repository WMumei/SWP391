using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class JewelryDesign
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? DesignFile { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Company, Customer, Final
        //public string Type { get; set; }
		public string? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public string? DesignStaffId { get; set; }
        [ForeignKey("DesignStaffId")]
        public User? DesignStaff { get; set; }

        public string? ProductionStaffId { get; set; }
        [ForeignKey("ProductionStaffId")]
        public User? ProductionStaff { get; set; }

        //public int? ProductionRequestId { get; set; }
        //[ForeignKey("ProductionRequestId")]
        //public ProductionRequest ProductionRequest { get; set; }

        //public int? BaseDesignId { get; set; }
        //public BaseDesign BaseDesign { get; set; }

        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }
    }
}
