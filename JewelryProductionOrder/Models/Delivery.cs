using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    [PrimaryKey(nameof(CustomerId), nameof(SalesStaffId), nameof(JewelryId), nameof(WarrantyCardId))]
    public class Delivery
    {
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public int SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }

        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }

        public int WarrantyCardId { get; set; }
        [ForeignKey("WarrantyCardId")]
        public WarrantyCard WarrantyCard { get; set; }
    }
}
