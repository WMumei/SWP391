using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class Jewelry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image {  get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? MaterialSetId { get; set; }
        [ForeignKey("MaterialSetId")]
        public MaterialSet? MaterialSet { get; set; }
        public WarrantyCard? WarrantyCard { get; set; }

        public string? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public string? SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }

        public string? ProductionStaffId { get; set; }
        [ForeignKey("ProductionStaffId")]
        public User? ProductionStaff { get; set; }
        public int ProductionRequestId { get; set; }
        [ForeignKey("ProductionRequestId")]
        public ProductionRequest ProductionRequest { get; set; }
        public QuotationRequest? QuotationRequest { get; set; }

    }
}
