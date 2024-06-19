using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IProductionRequestRepository : IRepository<ProductionRequest>
    {
        void Update(ProductionRequest request);
        void Save();
    }
}
