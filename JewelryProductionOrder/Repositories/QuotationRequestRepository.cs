using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class QuotationRequestRepository : Repository<QuotationRequest>, IQuotationRequestRepository
    {
        private ApplicationDbContext _db;
        public QuotationRequestRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(QuotationRequest request)
        {
            _db.QuotationRequests.Update(request);
        }
    }
}
