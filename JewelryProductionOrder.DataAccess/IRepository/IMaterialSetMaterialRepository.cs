using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;


namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IMaterialSetMaterialRepository : IRepository<MaterialSetMaterial>
	{
		void Update(MaterialSetMaterial materialSetMaterial);
		void Save();
	}
}
