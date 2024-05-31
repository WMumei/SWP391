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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionRequest>().HasData(
                new ProductionRequest { Id = 1, CreatedDate = DateTime.Now },
                new ProductionRequest { Id = 2, CreatedDate = DateTime.Now },
                new ProductionRequest { Id = 3, CreatedDate = DateTime.Now }
                );
        }
        
    }
}
