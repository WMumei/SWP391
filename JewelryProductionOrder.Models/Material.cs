using System.ComponentModel.DataAnnotations;

namespace JewelryProductionOrder.Models
{
	public class Material
	{
		public int Id { get; set; }
		[StringLength(100)]
		// Gold, Silver, Plat
		public string Type { get; set; }
		// 24K, 18K for Gold; 925 for Silver
		public string Purity { get; set; }
		// Rose Gold, White Gold, Yellow Gold
		public string Color { get; set; }
		[Range(0.01, double.MaxValue)]
		public decimal Price { get; set; }
		public List<MaterialSet> MaterialSets { get; } = [];
		public List<MaterialSetMaterial> MaterialSetMaterials { get; } = [];
	}
}
