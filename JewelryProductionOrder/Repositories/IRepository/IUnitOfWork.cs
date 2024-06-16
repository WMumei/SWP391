using JewelryProductionOrder.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.Repository.IRepository
{
    public interface IUnitOfWork
    {   
        IProductionRequestRepository ProductionRequest { get; }
        IUserRepository User { get; }
        IJewelryRepository Jewelry { get; }
        IQuotationRequestRepository QuotationRequest { get; }
        void Save();
       // void Get();
        //void Find(int id);
    }
}
