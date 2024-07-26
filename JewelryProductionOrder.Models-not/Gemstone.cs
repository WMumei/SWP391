using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
    public class Gemstone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Weight { get; set; }
        public List<MaterialSet> MaterialSets { get; } = [];
    }
}
