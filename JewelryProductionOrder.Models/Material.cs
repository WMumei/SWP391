using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelryProductionOrder.Models
{
	public class Material
	{
		public int Id { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		[Range(0, double.MaxValue)]
		public decimal Price { get; set; }
		[JsonIgnore]
		public List<MaterialSet> MaterialSets { get; } = [];
		[JsonIgnore]
		public List<MaterialSetMaterial> MaterialSetMaterials { get; } = [];
	}
}
