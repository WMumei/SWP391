using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JewelryProductionOrder.Models
{
	public class MaterialSet
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		[Range(0, double.MaxValue)]
		public decimal TotalPrice { get; set; }
        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; } = null!;
        public List<Material> Materials { get; } = [];
		public List<Gemstone> Gemstones { get; } = [];
		public List<MaterialSetMaterial> MaterialSetMaterials { get; } = [];
	}
}
