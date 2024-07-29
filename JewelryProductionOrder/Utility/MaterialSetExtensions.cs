//using JewelryProductionOrder.Models;

//namespace JewelryProductionOrder.Utility
//{
//	public static class MaterialSetExtensions
//	{
//		public static MaterialSet DeepCopy(this MaterialSet original)
//		{
//			var newMaterialSet = new MaterialSet
//			{
//				CreatedAt = DateTime.Now,
//				TotalPrice = original.TotalPrice,
//				JewelryId = original.JewelryId
//			};

//			foreach (var materialSetMaterial in original.MaterialSetMaterials)
//			{
//				newMaterialSet.MaterialSetMaterials.Add(new MaterialSetMaterial
//				{
//					MaterialId = materialSetMaterial.MaterialId,
//					Weight = materialSetMaterial.Weight,
//					CreatedAt = materialSetMaterial.CreatedAt
//				});
//			}

//			foreach (var gemstone in original.Gemstones)
//			{
//				// Change to getting from DB
//				newMaterialSet.Gemstones.Add(new Gemstone
//				{
//					Name = gemstone.Name,
//					Price = gemstone.Price,
//					Carat = gemstone.Carat,
//					Color = gemstone.Color,
//					Clarity = gemstone.Clarity,
//					Cut = gemstone.Cut,
//					Status = gemstone.Status,
//					MaterialSetId = gemstone.MaterialSetId
//				});
//			}

//			return newMaterialSet;
//		}
//	}

//}
