using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class JewelryDesignRepository : Repository<JewelryDesign>, IJewelryDesignRepository
    {
        private ApplicationDbContext _db;
        public JewelryDesignRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(JewelryDesign design)
        {
            _db.JewelryDesigns.Update(design);
        }
    }
}
