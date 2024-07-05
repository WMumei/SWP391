using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IProductionRequestDetailRepository : IRepository<ProductionRequestDetail>
    {
        void Update(ProductionRequestDetail request);
        void Save();
    }
}
