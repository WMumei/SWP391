using JewelryProductionOrder.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryProductionOrder.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductionRequest> ProductionRequests { get; set; }
        public DbSet<QuotationRequest> QuotationRequests { get; set; }
        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<JewelryDesign> JewelryDesigns { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialSet> MaterialSets { get; set; }
        public DbSet<MaterialSetMaterial> MaterialSetsMaterials { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SalesStaffCustomer> SalesStaffCustomers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WarrantyCard> WarrantyCards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WarrantyCard>()
            //.HasRequired(c => c.SalesStaff)
            //.WithMany()
            //.WillCascadeOnDelete(false);
        }
    }
}
