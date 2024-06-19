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
		IMaterialRepository Material { get; }
        IMaterialSetRepository MaterialSet { get; }
		IGemstoneRepository Gemstone { get; }
		IMaterialSetMaterialRepository MaterialSetMaterial { get; }
		IQuotationRequestRepository QuotationRequest { get; }
        IJewelryDesignRepository JewelryDesign { get; }
		void Save();
    }
}
