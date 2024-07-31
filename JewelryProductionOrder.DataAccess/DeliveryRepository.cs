using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repository;

namespace JewelryProductionOrder.Repositories
{
    public class DeliveryRepository : Repository<Delivery>, IDeliveryRepository
    {
        private ApplicationDbContext _db;
        public DeliveryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Delivery delivery)
        {
            _db.Deliveries.Update(delivery);
        }
    }
}
