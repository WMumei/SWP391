using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IJewelryRepository : IRepository<Jewelry>
	{
		void Update(Jewelry jewelry);
		void Save();
	}
}
