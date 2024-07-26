using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User SalesStaff { get; set; }
    }
}
