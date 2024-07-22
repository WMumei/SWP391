namespace JewelryProductionOrder.Models.ViewModels
{
	public class ShoppingCartVM
	{
		public ProductionRequest ProductionRequest { get; set; }
		//public User Customer { get; set; }
		public List<ShoppingCart> ShoppingCartList { get; set; }
	}
}
