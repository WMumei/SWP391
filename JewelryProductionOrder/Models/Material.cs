namespace JewelryProductionOrder.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<MaterialSet> MaterialSets { get; } = [];
        public List<MaterialSetMaterial> MaterialSetMaterials { get; } = [];
    }
}
