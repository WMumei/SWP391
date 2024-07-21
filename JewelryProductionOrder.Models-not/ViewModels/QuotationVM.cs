using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JewelryProductionOrder.Models.ViewModels
{
    public class QuotationVM
    {
        public QuotationRequest QuotationRequest { get; set; }
        //public User SaleStaff { get; set; } //Checkoutform
        public Jewelry Jewelry { get; set; }
		
		//public List<Jewelry> jewelries { get; } = [];
		public MaterialSet MaterialSet { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> JewelryList { get; set; }
	}
}
