	using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelryProductionOrder.Models
	{
		public class Gemstone
		{
			public int Id { get; set; }
			public string Name { get; set; }
			[Range(0.01, 100000000)]
			public decimal Price { get; set; }

			// TODO : DELETE Weight, there is a carat field already
			[Range(0.01, 100000000)]
			public decimal Weight { get; set; }
	        [Range(0.000001, 100000000)]
		    public decimal Carat { get; set; }
			public string Color { get; set; }
			public string Clarity { get; set; }
			public string Cut { get; set; }
			public string Status { get; set; }
			public int? MaterialSetId { get; set; }
			public MaterialSet MaterialSet { get; set; } = null!;
    }
	}
