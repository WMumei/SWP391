using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IWarrantyCardRepository : IRepository<WarrantyCard>

    {
       
        void Update(WarrantyCard obj);
        void Save();
    }
}
