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
        public string Image {  get; set; }
        public string Status { get; set; }

        public int MaterialSetId { get; set; }
        [ForeignKey("MaterialSetId")]
        public MaterialSet MaterialSet { get; set; }
        public int WarrantyCardId { get; set; }
        [ForeignKey("WarrantyCardId")]
        public WarrantyCard WarrantyCard { get; set; }
        //public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public User User { get; set; }
        //public int SalesStaffId { get; set; }
        //[ForeignKey("SalesStaffId")]
        //public User user { get; set; }
        //public int ProductionStaffId { get; set; }
        //[ForeignKey("ProductionStaffId")]
        //public User user { get; set; }
        public int ProductionRequestId { get; set; }
        [ForeignKey("ProductionRequestId")]
        public ProductionRequest ProductionRequest { get; set; }
        public int QuotationRequestId { get; set; }
        [ForeignKey("QuotationRequestId")]
        public QuotationRequest QuotationRequest { get; set; }
    }
}
