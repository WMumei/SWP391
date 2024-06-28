namespace JewelryProductionOrder.Models.ViewModels
{
    public class OrderVM
    {
        public ProductionRequest ProductionRequest { get; set; }
        public User Customer { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
