using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
	public interface IPostRepository : IRepository<Post>
	{
		void Update(Post obj);
		void Save();
	}
}
