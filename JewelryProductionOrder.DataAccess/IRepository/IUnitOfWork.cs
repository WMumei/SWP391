using JewelryProductionOrder.Repositories.IRepository;

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
		IShoppingCartRepository ShoppingCart { get; }
		IProductionRequestDetailRepository ProductionRequestDetail { get; }
		IBaseDesignRepository BaseDesign { get; }
		IPostRepository Post { get; }
		IDeliveryRepository Delivery { get; }
		IWarrantyCardRepository WarrantyCard { get; }

		void Save();


		// void Get();
		//void Find(int id);
	}
}
