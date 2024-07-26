using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IGemstoneRepository : IRepository<Gemstone>
	{
		void Update(Gemstone gemstone);
		void Save();
	}
}

