using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IProductionRequestRepository : IRepository<ProductionRequest>
    {
        IEnumerable<ProductionRequest> GetAllWithCustomers();
        void Update(ProductionRequest request);
        void Save();
    }
}
