namespace JewelryProductionOrder.Models
{
    public class MaterialSet
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Material> Materials { get; } = [];
        public List<Gemstone> Gemstones { get; } = [];
        public List<MaterialSetMaterial> MaterialSetMaterials { get; } = [];
    }
}
