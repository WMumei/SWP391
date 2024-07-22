using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IBaseDesignRepository : IRepository<BaseDesign>
	{
		void Update(BaseDesign design);
		void Save();
	}
}
