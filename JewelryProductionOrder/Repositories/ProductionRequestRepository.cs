using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;
using System.Linq.Expressions;

namespace JewelryProductionOrder.Repositories
{
    public class ProductionRequestRepository : Repository<ProductionRequest>, IProductionRequestRepository
    {
        private ApplicationDbContext _db;
        public ProductionRequestRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ProductionRequest request)
        {
            _db.ProductionRequests.Update(request);
        }
    }
}
