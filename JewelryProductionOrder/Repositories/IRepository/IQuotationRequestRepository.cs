using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IQuotationRequestRepository : IRepository<QuotationRequest>
    {
        IEnumerable<QuotationRequest> GetAllWithSaleStaffs();
        void Update(QuotationRequest request);
        void Save();
       // void Find(int id);
    }
}
