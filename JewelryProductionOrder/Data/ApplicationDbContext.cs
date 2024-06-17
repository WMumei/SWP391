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

		public DbSet<Gemstone> Gemstones { get; set; }

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
			//modelBuilder.Entity<QuotationRequest>()
			//    .HasOne(t => t.Jewelry)
			//    .WithMany()
			//    .HasForeignKey(t => t.JewelryId)
			//    .OnDelete(DeleteBehavior.Restrict);
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
				new ProductionRequest { Id = 1, CreatedAt = DateTime.Now, Quantity = 1 },
				new ProductionRequest { Id = 2, CreatedAt = DateTime.Now, Quantity = 1 }
				);
			modelBuilder.Entity<Role>().HasData(
				new Role { Id = 1, Name = "Staff" },
				new Role { Id = 2, Name = "Customer" },
				new Role { Id = 3, Name = "Manager" }
				);
			modelBuilder.Entity<User>().HasData(
				new User { Id = 1, Name = "Staff 1", RoleId = 1 },
				new User { Id = 2, Name = "Customer 1", RoleId = 2 },
				new User { Id = 3, Name = "Manager 1", RoleId = 3 }
				);
			modelBuilder.Entity<Material>().HasData(
				new Material { Id = 1, Name = "Gold", Price = 1000 },
				new Material { Id = 2, Name = "Silver", Price = 1 }
				);
			modelBuilder.Entity<Gemstone>().HasData(
				new Gemstone { Id = 1, Name = "Diamond", Price = 200000, Weight=2 }
				);
			modelBuilder.Entity<Jewelry>().HasData(
				new Jewelry { Id = 1, Name = "Diamond Necklace", Description="9999 Gold for the material and 1 carat diamond for everyday wear", Status = "", CreatedAt = DateTime.Now, ProductionRequestId = 1 });
			//modelBuilder.Entity<QuotationRequest>().HasData(
			//        new QuotationRequest { Id = 1, Name = "abc", Status = "", CreatedAt = DateTime.Now, LaborPrice = 1000000, TotalPrice = 200000 },
			//        new QuotationRequest { Id = 2, Name = "abc", Status = "", CreatedAt = DateTime.Now, LaborPrice = 1000000, TotalPrice = 200000 }
			//    );
			#endregion

			#region OneToOne
			//modelBuilder.Entity<Jewelry>()
			//        .HasOne(e => e.WarrantyCard)
			//        .WithOne(e => e.Jewelry)
			//        .HasForeignKey<WarrantyCard>(e => e.JewelryId)
			//        .IsRequired();

			#endregion
			#region ManyToMany
			modelBuilder.Entity<MaterialSet>()
				.HasMany(e => e.Materials)
				.WithMany(e => e.MaterialSets)
				.UsingEntity<MaterialSetMaterial>(j => j.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP"));
			#endregion
		}

	}
}
