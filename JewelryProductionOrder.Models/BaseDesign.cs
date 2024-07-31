using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
    public class BaseDesign
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        //public string? DesignFile { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
