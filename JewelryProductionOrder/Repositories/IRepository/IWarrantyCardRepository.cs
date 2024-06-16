using System.ComponentModel;
using JewelryProductionOrder.Models;
using Models.Repositories.IRepository;

namespace JewelryProductionOrder.Repositories.IRepository
{
    public interface IWarrantyCardRepository : IRepository<WarrantyCard>

    {
        IEnumerable<WarrantyCard> GetAllWithSaleStaffs(); //usecase của salestaff
        void Update(WarrantyCard obj);
        void Save();
    }
}
