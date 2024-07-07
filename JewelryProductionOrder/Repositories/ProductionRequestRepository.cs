using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
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

        public void UpdateStatus(int id, string reqStatus, string? paymentStatus = null)
        {
            var req = _db.ProductionRequests.FirstOrDefault(x => x.Id == id);
            if (req != null) {
                req.Status = reqStatus;
                if (!string.IsNullOrEmpty(paymentStatus)) {
                    req.Status = paymentStatus;
                }
            }
        }

        public void updateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {
            var req = _db.ProductionRequests.FirstOrDefault(x => x.Id == id);
            if (!string.IsNullOrEmpty(sessionId)) 
            {
                req.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                req.PaymentIntentId = paymentIntentId;
            }
        }

        public void UpdateStatus(int id, string reqStatus, string? paymentStatus = null)
        {
            var req = _db.ProductionRequests.FirstOrDefault(x => x.Id == id);
            if (req != null) {
                req.Status = reqStatus;
                if (!string.IsNullOrEmpty(paymentStatus)) {
                    req.Status = paymentStatus;
                }
            }
        }

        public void updateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {
            var req = _db.ProductionRequests.FirstOrDefault(x => x.Id == id);
            if (!string.IsNullOrEmpty(sessionId)) 
            {
                req.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                req.PaymentIntentId = paymentIntentId;
            }
        }
    }
}
