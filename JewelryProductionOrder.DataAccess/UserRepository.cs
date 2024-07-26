using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private ApplicationDbContext _db;
		public UserRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(User user)
		{
			_db.Users.Update(user);
		}
	}
}
