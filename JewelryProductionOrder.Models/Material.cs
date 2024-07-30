using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelryProductionOrder.Models
{
    public class Material
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        [Range(0.01, 100.0)]
        public decimal Purity { get; set; }

        public string Color { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [JsonIgnore]
        public List<MaterialSet> MaterialSets { get; } = new List<MaterialSet>();

        [JsonIgnore]
        public List<MaterialSetMaterial> MaterialSetMaterials { get; } = new List<MaterialSetMaterial>();
    }
}