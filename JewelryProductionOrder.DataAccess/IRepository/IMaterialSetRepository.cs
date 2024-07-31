using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;


namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IMaterialSetRepository : IRepository<MaterialSet>
    {
        void Update(MaterialSet materialSet);
        void Save();

        decimal GetTotalPrice(int id);
    }
}
