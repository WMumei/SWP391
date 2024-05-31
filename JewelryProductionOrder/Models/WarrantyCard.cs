using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class WarrantyCard
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        //Changed FK to the Jewelry side for this 1-1 relationship
        //public int JewelryId { get; set; }
        //[ForeignKey("JewelryId")]
        //public Jewelry Jewelry { get; set; }

        [Required]
        public int SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }
    }
}
