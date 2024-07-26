using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IJewelryDesignRepository : IRepository<JewelryDesign>
    {
        void Update(JewelryDesign design);
        void Save();
    }
}
