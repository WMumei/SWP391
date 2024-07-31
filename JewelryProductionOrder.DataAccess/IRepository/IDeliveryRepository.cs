using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        void Update(Delivery delivery);
        void Save();
    }
}
