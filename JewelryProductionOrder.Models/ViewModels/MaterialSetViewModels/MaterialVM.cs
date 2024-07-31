using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProductionOrder.Models.ViewModels.MaterialSetViewModels
{
	public class MaterialVM
	{
		public Material Material { get; set; }
		//public int MaterialSetId { get; set; }
		public decimal Weight { get; set; }
		public decimal Price { get; set; }
	}
}
