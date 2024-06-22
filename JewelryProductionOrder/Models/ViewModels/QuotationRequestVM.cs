using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace JewelryProductionOrder.Models.ViewModels
{
	public class QuotationRequestVM
	{
		public Jewelry Jewelry { get; set; }
		public QuotationRequest QuotationRequest { get; set; }
		public MaterialSet MaterialSet { get; set; }
	}
}
