using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
    public class JewelryDesign
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string DesignFile { get; set; }
        public string Status { get; set; }

        //public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public User User { get; set; }

        //public int DesignStaffId { get; set; }
        //[ForeignKey("DesignStaffId")]
        //public User user { get; set; }

        //public int ProductionStaffId { get; set; }
        //[ForeignKey("ProductionStaffId")]
        //public User user { get; set; }
        public int ProductionRequestId { get; set; }
        [ForeignKey("ProductionRequestId")]
        public ProductionRequest ProductionRequest { get; set; }
    }
}
