using Models.Repositories.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryProductionOrder.Repositories.IRepository;
using JewelryProductionOrder.Models;
using JewelryProductionOrder.Repositories;
using JewelryProductionOrder.Data;

namespace Models.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IProductionRequestRepository ProductionRequest { get; private set; }
        public IUserRepository User { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ProductionRequest = new ProductionRequestRepository(_db);
            User = new UserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
