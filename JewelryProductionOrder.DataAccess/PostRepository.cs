using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
	public class PostRepository : Repository<Post>, IPostRepository
	{
		private ApplicationDbContext _db;
		public PostRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Post post)
		{
			_db.Posts.Update(post);
		}
	}
}
