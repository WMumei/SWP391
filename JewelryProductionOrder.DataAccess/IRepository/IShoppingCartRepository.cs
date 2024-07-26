using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IShoppingCartRepository : IRepository<ShoppingCart>
	{
		void Update(ShoppingCart obj);
	}
}
