using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Repository;
using System.Linq.Expressions;

namespace JewelryProductionOrder.Repositories
{
    public class QuotationRequestRepository : Repository<QuotationRequest>, IQuotationRequestRepository
    {
        private ApplicationDbContext _db;
        public QuotationRequestRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<QuotationRequest> GetAllWithSaleStaffs()
        {
            return dbSet.Include(x => x.SalesStaff).ToList();
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

