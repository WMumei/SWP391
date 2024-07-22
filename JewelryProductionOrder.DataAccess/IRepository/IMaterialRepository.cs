using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IMaterialRepository : IRepository<Material>
	{
		void Update(Material material);
		void Save();
	}
}

