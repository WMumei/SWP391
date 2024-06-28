using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class ProductionRequestDetailRepository : Repository<ProductionRequest>, IProductionRequestDetailRepository
    {
        private ApplicationDbContext _db;
        public ProductionRequestDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<ProductionRequest> GetAllWithCustomers()
        {
            return dbSet.Include(x => x.Customer).ToList();
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
