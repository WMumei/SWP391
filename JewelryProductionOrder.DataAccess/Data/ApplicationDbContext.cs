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
				new BaseDesign { Id = 1, Image = @"\Images\Ring.webp", Name = "Bezel Solitarie Engagement Ring", Type = "Company" },
				new BaseDesign { Id = 2, Image = @"\Images\Pendant.jpg", Name = "Diamond Reiki Symbol Pendant", Type = "Company" },
				new BaseDesign { Id = 3, Image = @"\Images\Necklace.webp", Name = "Smile Necklace", Type = "Company" },
				new BaseDesign { Id = 4, Image = @"\Images\Band.webp", Name = "Swirl Diamond Wedding Band", Type = "Company" }
				);


			modelBuilder.Entity<Material>().HasData(
				new Material { Id = 1, Type = "Gold", Purity = "14K", Color = "White", Price = 100m },
				new Material { Id = 2, Type = "Gold", Purity = "10K", Color = "Rose", Price = 50m },
				new Material { Id = 3, Type = "Gold", Purity = "18K", Color = "Yellow", Price = 80m },
				new Material { Id = 4, Type = "Gold", Purity = "14K", Color = "Green", Price = 90m },
				new Material { Id = 5, Type = "Silver", Purity = "925", Color = "Silver", Price = 60m },
				new Material { Id = 6, Type = "Silver", Purity = "999", Color = "Silver", Price = 70m },
				new Material { Id = 7, Type = "Platinum", Purity = "950", Color = "White", Price = 120m },
				new Material { Id = 8, Type = "Copper", Purity = "99.9%", Color = "Red", Price = 30m },
				new Material { Id = 9, Type = "Brass", Purity = "60%", Color = "Golden", Price = 40m },
				new Material { Id = 10, Type = "Titanium", Purity = "99.9%", Color = "Grey", Price = 50m },
				new Material { Id = 11, Type = "Steel", Purity = "304", Color = "Silver", Price = 45m },
				new Material { Id = 12, Type = "Zinc", Purity = "99.9%", Color = "Grey", Price = 20m },
				new Material { Id = 13, Type = "Rhodium", Purity = "99.9%", Color = "White", Price = 150m },
				new Material { Id = 14, Type = "Palladium", Purity = "95%", Color = "White", Price = 100m },
				new Material { Id = 15, Type = "Iridium", Purity = "99.9%", Color = "Grey", Price = 180m }
			);

			modelBuilder.Entity<Gemstone>().HasData(
				new Gemstone { Id = 1, Name = "Diamond", Price = 2000, Carat = 3, Color = "White", Clarity = "VS1", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 2, Name = "Ruby", Price = 1500, Carat = 1.5M, Color = "Red", Clarity = "VVS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 3, Name = "Sapphire", Price = 1800, Carat = 1.8M, Color = "Blue", Clarity = "VS2", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 4, Name = "Diamond", Price = 1800, Carat = 2, Color = "White", Clarity = "VS2", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 5, Name = "Diamond", Price = 1000, Carat = 1, Color = "White", Clarity = "VVS2", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 6, Name = "Emerald", Price = 2500, Carat = 2.5M, Color = "Green", Clarity = "VS1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 7, Name = "Amethyst", Price = 600, Carat = 1.2M, Color = "Purple", Clarity = "SI1", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 8, Name = "Topaz", Price = 800, Carat = 1.8M, Color = "Yellow", Clarity = "VS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 9, Name = "Aquamarine", Price = 1100, Carat = 1.9M, Color = "Blue", Clarity = "VS2", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 10, Name = "Garnet", Price = 700, Carat = 1.4M, Color = "Red", Clarity = "VS1", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 11, Name = "Peridot", Price = 500, Carat = 1.5M, Color = "Green", Clarity = "SI1", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 12, Name = "Citrine", Price = 400, Carat = 1.3M, Color = "Yellow", Clarity = "VS2", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 13, Name = "Morganite", Price = 1200, Carat = 1.7M, Color = "Pink", Clarity = "VS1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 14, Name = "Opal", Price = 900, Carat = 1.6M, Color = "Multi", Clarity = "VS2", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 15, Name = "Spinel", Price = 950, Carat = 1.3M, Color = "Red", Clarity = "VS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 16, Name = "Tourmaline", Price = 1000, Carat = 2M, Color = "Green", Clarity = "VS2", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 17, Name = "Tanzanite", Price = 1300, Carat = 1.8M, Color = "Blue", Clarity = "VS1", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 18, Name = "Zircon", Price = 450, Carat = 1.2M, Color = "Blue", Clarity = "VS2", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 19, Name = "Jade", Price = 700, Carat = 1.5M, Color = "Green", Clarity = "SI1", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 20, Name = "Lapis", Price = 550, Carat = 1.4M, Color = "Blue", Clarity = "VS1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 21, Name = "Turquoise", Price = 600, Carat = 1.3M, Color = "Blue", Clarity = "VS2", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 22, Name = "Moonstone", Price = 400, Carat = 1.1M, Color = "White", Clarity = "VS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 23, Name = "Onyx", Price = 350, Carat = 1.2M, Color = "Black", Clarity = "SI1", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 24, Name = "Alexandrite", Price = 3000, Carat = 1.5M, Color = "Green", Clarity = "VS2", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 25, Name = "Carnelian", Price = 200, Carat = 1.0M, Color = "Orange", Clarity = "VS1", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 26, Name = "Kunzite", Price = 850, Carat = 1.7M, Color = "Pink", Clarity = "VS2", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 27, Name = "Larimar", Price = 400, Carat = 1.3M, Color = "Blue", Clarity = "VS1", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 28, Name = "Malachite", Price = 300, Carat = 1.2M, Color = "Green", Clarity = "SI1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 29, Name = "Obsidian", Price = 200, Carat = 1.1M, Color = "Black", Clarity = "VS2", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 30, Name = "Pearl", Price = 100, Carat = 1.0M, Color = "White", Clarity = "VS1", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 31, Name = "Beryl", Price = 1300, Carat = 2M, Color = "Green", Clarity = "VS2", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 32, Name = "Bloodstone", Price = 500, Carat = 1.3M, Color = "Green", Clarity = "SI1", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 33, Name = "Coral", Price = 400, Carat = 1.1M, Color = "Red", Clarity = "VS1", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 34, Name = "Hematite", Price = 300, Carat = 1.0M, Color = "Black", Clarity = "VS2", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 35, Name = "Iolite", Price = 700, Carat = 1.4M, Color = "Blue", Clarity = "VS1", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 36, Name = "Jasper", Price = 200, Carat = 1.0M, Color = "Red", Clarity = "SI1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 37, Name = "Kyanite", Price = 600, Carat = 1.5M, Color = "Blue", Clarity = "VS2", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 38, Name = "Labradorite", Price = 500, Carat = 1.2M, Color = "Grey", Clarity = "VS1", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 39, Name = "Rhodochrosite", Price = 450, Carat = 1.1M, Color = "Pink", Clarity = "VS2", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 40, Name = "Sodalite", Price = 300, Carat = 1.2M, Color = "Blue", Clarity = "VS1", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 41, Name = "Sugilite", Price = 350, Carat = 1.3M, Color = "Purple", Clarity = "SI1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 42, Name = "Sunstone", Price = 400, Carat = 1.4M, Color = "Orange", Clarity = "VS2", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 43, Name = "TigersEye", Price = 250, Carat = 1.1M, Color = "Brown", Clarity = "VS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 44, Name = "Turquoise", Price = 500, Carat = 1.2M, Color = "Blue", Clarity = "VS2", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 45, Name = "Unakite", Price = 200, Carat = 1.0M, Color = "Green", Clarity = "SI1", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 46, Name = "Variscite", Price = 600, Carat = 1.5M, Color = "Green", Clarity = "VS1", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 47, Name = "Zircon", Price = 700, Carat = 1.6M, Color = "Blue", Clarity = "VS2", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 48, Name = "Ametrine", Price = 1000, Carat = 1.7M, Color = "Purple", Clarity = "VS1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 49, Name = "Benitoite", Price = 3000, Carat = 1.8M, Color = "Blue", Clarity = "VS2", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 50, Name = "Chalcedony", Price = 450, Carat = 1.2M, Color = "Blue", Clarity = "VS1", Cut = "Oval", Status = "Available" }
			);

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
