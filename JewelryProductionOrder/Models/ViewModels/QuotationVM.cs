namespace JewelryProductionOrder.Models.ViewModels
{
    public class QuotationVM
    {
        public QuotationRequest QuotationRequest { get; set; }
        public User SaleStaff { get; set; } //Checkoutform
        public Jewelry Jewelry { get; set; }
        public Gemstone Gemstone { get; set; }
		public MaterialSetMaterial MaterialSetMaterial { get; set; }
		public Material Material { get; set; }
        public MaterialSet MaterialSet { get; set; }
    }
}
