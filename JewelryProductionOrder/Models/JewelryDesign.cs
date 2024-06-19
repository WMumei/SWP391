using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
    public class JewelryDesign
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? DesignFile { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public string? DesignStaffId { get; set; }
        [ForeignKey("DesignStaffId")]
        public User? DesignStaff { get; set; }

        public string? ProductionStaffId { get; set; }
        [ForeignKey("ProductionStaffId")]
        public User? ProductionStaff { get; set; }
        public int? ProductionRequestId { get; set; }
        [ForeignKey("ProductionRequestId")]
        public ProductionRequest ProductionRequest { get; set; }

        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }
    }
}
