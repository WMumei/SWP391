namespace JewelryProductionOrder.Models.ViewModels
{
    public class QuotationVM
    {
        public QuotationRequest QuotationRequest { get; set; }
        public User SaleStaff { get; set; }
        public Jewelry Jewelry { get; set; }
        public Material Material { get; set; }
        public MaterialSet MaterialSet { get; set; }
    }
}
