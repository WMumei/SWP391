using System.Linq.Expressions;
using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;
using NuGet.Protocol.Core.Types;

namespace JewelryProductionOrder.Repositories
{
    public class WarrantyCardRepository : Repository<WarrantyCard>, IWarrantyCardRepository
    {
        private ApplicationDbContext _db;
        public WarrantyCardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public void Add(WarrantyCard entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public WarrantyCard Get(Expression<Func<WarrantyCard, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<WarrantyCard> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Remove(WarrantyCard entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveRange(IEnumerable<WarrantyCard> entity)
        //{
        //    throw new NotImplementedException();
        //}

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(WarrantyCard obj)
        {
            _db.WarrantyCards.Update(obj);
        }
    }
}
