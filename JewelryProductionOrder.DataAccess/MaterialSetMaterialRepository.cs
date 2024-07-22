using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
	public class MaterialSetMaterialRepository : Repository<MaterialSetMaterial>, IMaterialSetMaterialRepository
	{
		private ApplicationDbContext _db;
		public MaterialSetMaterialRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(MaterialSetMaterial materialSetMaterial)
		{
			_db.MaterialSetsMaterials.Update(materialSetMaterial);
		}
	}
}
