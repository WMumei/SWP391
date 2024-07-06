using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JewelryProductionOrder.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WarrantyCard> WarrantyCards { get; set; }
        public DbSet<BaseDesign> BaseDesigns { get; set; }
        public DbSet<ProductionRequestDetail> ProductionRequestDetails { get; set; }
        public DbSet<Gemstone> Gemstones { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            //modelBuilder.Entity<JewelryDesign>()
            //    .HasOne(t => t.ProductionRequest)
            //    .WithMany()
            //    .HasForeignKey(t => t.ProductionRequestId)
            //    .OnDelete(DeleteBehavior.Restrict);

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
            modelBuilder.Entity<BaseDesign>().HasData(
                new BaseDesign { Id = 1, Image = @"\Images\Ring.webp", Name="Bezel Solitarie Engagement Ring", Type="Company" },
				new BaseDesign { Id = 2, Image = @"\Images\Pendant.jpg", Name = "Diamond Reiki Symbol Pendant", Type="Company" },
				new BaseDesign { Id = 3, Image = @"\Images\Necklace.webp", Name = "Smile Necklace", Type="Company" },
				new BaseDesign { Id = 4, Image = @"\Images\Band.webp", Name = "Swirl Diamond Wedding Band", Type="Company" }
				);     

            modelBuilder.Entity<ProductionRequest>().HasData(
                new ProductionRequest { Id = 1, CreatedAt = DateTime.Now, Address= "23 Phu Ky Quan 12", ContactName =" Le Hoang", PhoneNumber = "0123456769" },
                new ProductionRequest { Id = 2, CreatedAt = DateTime.Now, Address= "23 Phu Ky Quan 12", ContactName =" Le Hoang", PhoneNumber = "0123456769" }
                );
            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Gold", Price = 1000 },
                new Material { Id = 2, Name = "Silver", Price = 1 }
                );
            modelBuilder.Entity<Gemstone>().HasData(
                new Gemstone { Id = 1, Name = "Diamond", Price = 200000, Weight = 2 }
                );
            modelBuilder.Entity<Jewelry>().HasData(
                new Jewelry { Id = 1, Name = "Diamond Ring", Description = "9999 Gold for the material and 1 carat diamond for everyday wear", Status = "", CreatedAt = DateTime.Now, ProductionRequestId = 1, BaseDesignId = 1 });
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
