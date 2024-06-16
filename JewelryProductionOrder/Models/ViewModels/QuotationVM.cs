namespace JewelryProductionOrder.Models.ViewModels
{
    public class QuotationVM
    {
        public QuotationRequest QuotationRequest { get; set; }
        //public User SaleStaff { get; set; } //Checkoutform
        public Jewelry Jewelry { get; set; }
		
		//public List<Jewelry> jewelries { get; } = [];
		public MaterialSet MaterialSet { get; set; }
    }
}
