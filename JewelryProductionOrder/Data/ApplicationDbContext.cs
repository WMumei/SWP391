using JewelryProductionOrder.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WarrantyCard> WarrantyCards { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MultipleCascade
            modelBuilder.Entity<WarrantyCard>()
                .HasOne(t => t.SalesStaff)
                .WithMany()
                .HasForeignKey(t => t.SalesStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<WarrantyCard>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductionRequest>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductionRequest>()
                .HasOne(t => t.DesignStaff)
                .WithMany()
                .HasForeignKey(t => t.DesignStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductionRequest>()
                .HasOne(t => t.ProductionStaff)
                .WithMany()
                .HasForeignKey(t => t.ProductionStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductionRequest>()
                .HasOne(t => t.SalesStaff)
                .WithMany()
                .HasForeignKey(t => t.SalesStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuotationRequest>()
                .HasOne(t => t.Manager)
                .WithMany()
                .HasForeignKey(t => t.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuotationRequest>()
                .HasOne(t => t.SalesStaff)
                .WithMany()
                .HasForeignKey(t => t.SalesStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuotationRequest>()
                .HasOne(t => t.Jewelry)
                .WithMany()
                .HasForeignKey(t => t.JewelryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuotationRequest>()
                .HasOne(t => t.MaterialSet)
                .WithMany()
                .HasForeignKey(t => t.MaterialSetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Delivery>()
                .HasOne(t => t.SalesStaff)
                .WithMany()
                .HasForeignKey(t => t.SalesStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Delivery>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Delivery>()
                .HasOne(t => t.Jewelry)
                .WithMany()
                .HasForeignKey(t => t.JewelryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Delivery>()
                .HasOne(t => t.WarrantyCard)
                .WithMany()
                .HasForeignKey(t => t.WarrantyCardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JewelryDesign>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<JewelryDesign>()
                .HasOne(t => t.DesignStaff)
                .WithMany()
                .HasForeignKey(t => t.DesignStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<JewelryDesign>()
                .HasOne(t => t.ProductionStaff)
                .WithMany()
                .HasForeignKey(t => t.ProductionStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<JewelryDesign>()
                .HasOne(t => t.ProductionRequest)
                .WithMany()
                .HasForeignKey(t => t.ProductionRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jewelry>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Jewelry>()
                .HasOne(t => t.SalesStaff)
                .WithMany()
                .HasForeignKey(t => t.SalesStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Jewelry>()
                .HasOne(t => t.ProductionStaff)
                .WithMany()
                .HasForeignKey(t => t.ProductionStaffId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region SeedDatabase
            modelBuilder.Entity<ProductionRequest>().HasData(
                    new ProductionRequest { Id = 1, CreatedAt = DateTime.Now, Quantity=1 },
                    new ProductionRequest { Id = 2, CreatedAt = DateTime.Now, Quantity=1 }
                );
            modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, Name = "Staff" },
                    new Role { Id = 2, Name = "Customer" }
                );
            modelBuilder.Entity<User>().HasData(
                                   new User { Id = 1, Name = "Staff", RoleId = 1 },
                                   new User { Id = 2, Name = "Customer", RoleId = 2 }
                );
			modelBuilder.Entity<QuotationRequest>().HasData(
		            new QuotationRequest { Id = 1, Name = "abc", Status = "", CreatedAt = DateTime.Now, LaborPrice = 1000000, TotalPrice = 200000 },
		            new QuotationRequest { Id = 2, Name = "abc", Status = "", CreatedAt = DateTime.Now, LaborPrice = 1000000, TotalPrice = 200000 }
	            );
			#endregion

			#region OneToOne
			//modelBuilder.Entity<Jewelry>()
			//        .HasOne(e => e.WarrantyCard)
			//        .WithOne(e => e.Jewelry)
			//        .HasForeignKey<WarrantyCard>(e => e.JewelryId)
			//        .IsRequired();

			#endregion
		}

    }
}
