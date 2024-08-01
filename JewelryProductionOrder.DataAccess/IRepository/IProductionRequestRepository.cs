using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IProductionRequestRepository : IRepository<ProductionRequest>
    {
        void Update(ProductionRequest request);
        void Save();

        void UpdateStatus(int id, string requestStatus, string? paymentStatus = null);
        void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);
    }
}
