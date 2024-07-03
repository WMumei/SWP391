using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace JewelryProductionOrder.Models.ViewModels
{
    public class ManufactureVM
	{
		public JewelryDesign JewelryDesign { get; set; }
		//public MaterialSet MaterialSet { get; set; }
		public MaterialSet MaterialSet { get; set; }
		public Jewelry Jewelry { get; set; }
	}
}
