﻿using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models.ViewModels
{
	public class WarrantyCardVM
	{
		public Jewelry Jewelry { get; set; }
		public WarrantyCard WarrantyCard { get; set; }

		//public string? CustomerId { get; set; }
		//[ForeignKey("CustomerId")]
		public User Customer { get; set; }
    }
}
