using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class BaseDesignRepository : Repository<BaseDesign>, IBaseDesignRepository
    {
        private ApplicationDbContext _db;
        public BaseDesignRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(BaseDesign design)
        {
            _db.BaseDesigns.Update(design);
        }
    }
}
