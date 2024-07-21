using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class MaterialSetRepository : Repository<MaterialSet>, IMaterialSetRepository
    {
        private ApplicationDbContext _db;
        public MaterialSetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(MaterialSet materialSet)
        {
            _db.MaterialSets.Update(materialSet);
        }

        //public MaterialSet GetNested(int id)
        //{
        //    _db.MaterialSets.Where(s => s.Id == id).Include("MaterialSetMaterials").ThenInclude("Material");
        //}
    }
}
