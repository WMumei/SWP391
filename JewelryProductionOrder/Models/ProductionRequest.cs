using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
	public class ProductionRequest
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public int DesignStaffId { get; set; }
        [ForeignKey("DesignStaffId")]
        public User? DesignStaff { get; set; }

        public int ProductionStaffId { get; set; }
        [ForeignKey("ProductionStaffId")]
        public User? ProductionStaff { get; set; }

        public int SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }




    }
}
