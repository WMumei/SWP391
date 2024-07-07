using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IProductionRequestRepository : IRepository<ProductionRequest>
    {
        void Update(ProductionRequest request);
        void Save();

        void UpdateStatus(int id, string reqStatus, string? paymentStatus = null);
        void updateStripePaymentId(int id, string sessionId, string paymentIntentId);
    }
}
