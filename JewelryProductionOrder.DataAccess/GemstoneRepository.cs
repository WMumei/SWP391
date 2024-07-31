using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace Models.Repositories.Repository
{
    public class GemstoneRepository : Repository<Gemstone>, IGemstoneRepository
    {
        private ApplicationDbContext _db;
        public GemstoneRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Gemstone gemstone)
        {
            _db.Gemstones.Update(gemstone);
        }
    }
}