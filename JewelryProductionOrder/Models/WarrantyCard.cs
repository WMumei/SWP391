using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class WarrantyCard
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }

        //public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public User User { get; set; }

        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }

        //public int SalesStaffId { get; set; }
        //[ForeignKey("SalesStaffId")]
        //public User user { get; set; }
    }
}
