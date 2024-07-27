using AutoMapper;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Models.ViewModels;

namespace JewelryProductionOrder.Utility
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<MaterialSet, MaterialSetVM>().ReverseMap();
		}
	}
}
