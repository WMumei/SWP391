using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class WarrantyCardRepository : Repository<WarrantyCard>, IWarrantyCardRepository
    {
        private ApplicationDbContext _db;
        public WarrantyCardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(WarrantyCard card)
        {
            _db.WarrantyCards.Update(card);

        }
    }
}
