using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class ProductionRequestRepository : Repository<ProductionRequest>, IProductionRequestRepository
    {
        private ApplicationDbContext _db;
        public ProductionRequestRepository(ApplicationDbContext db) : base(db)
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

		public void UpdateStatus(int id, string requestStatus, string? paymentStatus = null)
		{
			var requestFromDb = _db.ProductionRequests.FirstOrDefault(m => m.Id == id);
            if (requestFromDb != null)
			{
				requestFromDb.Status = requestStatus;
				if (!string.IsNullOrEmpty(requestStatus))
				{
					requestFromDb.Status = paymentStatus;
				}
			}
		}

		public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
		{
			var requestFromDb = _db.ProductionRequests.FirstOrDefault(m => m.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
			{
				requestFromDb.SessionId = sessionId;
			}
			if (!string.IsNullOrEmpty(paymentIntentId))
			{
				requestFromDb.PaymentIntentId = paymentIntentId;
			}
		}
	}
}
