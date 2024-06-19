using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IQuotationRequestRepository : IRepository<QuotationRequest>
    {
        void Update(QuotationRequest request);
        void Save();
    }
}
