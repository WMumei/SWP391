using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
    public class Material
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public List<MaterialSet> MaterialSets { get; } = [];
        public List<MaterialSetMaterial> MaterialSetMaterials { get; } = [];
    }
}
