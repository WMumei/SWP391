namespace JewelryProductionOrder.Models
{
    public class ProductionRequestDetail
    {
        public int Id { get; set; }
        public int ProductionRequestId { get; set; }
        public ProductionRequest ProductionRequest { get; set; }
        public int Quantity { get; set; }
        public int BaseDesignId { get; set; }
        public BaseDesign BaseDesign { get; set; }
    }
}
