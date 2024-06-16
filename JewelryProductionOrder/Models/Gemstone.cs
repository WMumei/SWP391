namespace JewelryProductionOrder.Models
{
    public class Gemstone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public List<MaterialSet> MaterialSets { get; } = [];
    }
}
