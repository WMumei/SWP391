using JewelryProductionOrder.Data;
using JewelryProductionOrder.Repositories;
using JewelryProductionOrder.Repositories.IRepository;
using Models.Repositories.Repository.IRepository;

namespace Models.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IProductionRequestRepository ProductionRequest { get; private set; }
		public IQuotationRequestRepository QuotationRequest { get; private set; }
		public IUserRepository User { get; private set; }
        public IJewelryRepository Jewelry { get; private set; }
        public IMaterialRepository Material { get; private set; }
        public IMaterialSetRepository MaterialSet { get; private set; }
        public IGemstoneRepository Gemstone { get; private set; }
        public IQuotationRequestRepository QuotationRequest { get; private set; }
        public IMaterialSetMaterialRepository MaterialSetMaterial { get; private set; }
        public IJewelryDesignRepository JewelryDesign { get; private set; }
        public IProductionRequestDetailRepository ProductionRequestDetail { get; private set; }
		public IShoppingCartRepository ShoppingCart { get; private set; }
        public IBaseDesignRepository BaseDesign { get; private set; }
        public IPostRepository Post { get; private set; }
        public IWarrantyCardRepository WarrantyCard { get; private set; }
        public IDeliveryRepository Delivery { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ProductionRequest = new ProductionRequestRepository(_db);
            QuotationRequest = new QuotationRequestRepository(_db);
            User = new UserRepository(_db);
            Jewelry = new JewelryRepository(_db);
            Material = new MaterialRepository(_db);
            MaterialSet = new MaterialSetRepository(_db);
            Gemstone = new GemstoneRepository(_db);
            MaterialSetMaterial = new MaterialSetMaterialRepository(_db);
            QuotationRequest = new QuotationRequestRepository(_db);
            JewelryDesign = new JewelryDesignRepository(_db);
			ProductionRequestDetail = new ProductionRequestDetailRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db);
			BaseDesign = new BaseDesignRepository(_db);
            Post = new PostRepository(_db);
            WarrantyCard = new WarrantyCardRepository(_db);
            Delivery = new DeliveryRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
