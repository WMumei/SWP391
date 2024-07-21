using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private ApplicationDbContext _db;
        public MaterialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Material material)
        {
            _db.Materials.Update(material);
        }
    }
}
