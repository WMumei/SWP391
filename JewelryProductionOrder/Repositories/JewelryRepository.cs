using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class JewelryRepository : Repository<Jewelry>, IJewelryRepository
    {
        private ApplicationDbContext _db;
        public JewelryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Jewelry jewelry)
        {
            _db.Jewelries.Update(jewelry);
        }
    } 
}
