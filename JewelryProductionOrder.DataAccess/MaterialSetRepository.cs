using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
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

        public decimal GetTotalPrice(int id)
        {
            MaterialSet materialSet = Get(m => m.Id == id, includeProperties: "Materials,MaterialSetMaterials,Gemstones", tracked: true);
            var materMaterialSetMaterials = materialSet.MaterialSetMaterials;
            var materials = materialSet.Materials;
            decimal total = 0;
            foreach (MaterialSetMaterial join in materMaterialSetMaterials)
            {
                var material = materials.FirstOrDefault(m => m.Id == join.MaterialId);
                total += material.Price * join.Weight;
            }
            foreach (Gemstone gemstone in materialSet.Gemstones)
            {
                total += gemstone.Price;
            }
            return total;
        }
    }
}
