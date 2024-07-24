using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
	public class ProductionRequestDetailRepository : Repository<ProductionRequestDetail>, IProductionRequestDetailRepository
	{
		private ApplicationDbContext _db;
		public ProductionRequestDetailRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(ProductionRequestDetail request)
		{
			_db.ProductionRequestDetails.Update(request);
		}
	}
}
