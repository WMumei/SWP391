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
		public DbSet<Comment> Comments { get; set; }
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
			modelBuilder.Entity<Comment>()
				.HasOne(t => t.Owner)
				.WithMany()
				.HasForeignKey(t => t.OwnerId)
				.OnDelete(DeleteBehavior.Restrict);
			#endregion

			#region SeedDatabase
			modelBuilder.Entity<BaseDesign>().HasData(
				new BaseDesign { Id = 1, Image = @"\Images\Ring.webp", Name = "Bezel Solitairie Engagement Ring", Type = "Company", Description = "Sleek and contemporary, this 4.50ct round brilliant cut diamond pops in a custom bezel set solitaire ring. This setting was custom made to allow for the large center stone to sit as close to the finger as possible.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote." },
				new BaseDesign { Id = 2, Image = @"\Images\Pendant.jpg", Name = "Diamond Reiki Symbol Pendant", Type = "Company", Description = "Reiki symbols are used in alternative healing. After a major life upheaval, our client found meaning in the At Mata symbol, crafted using white gold and a trillion cut diamond, which is said to remove emotional blocks that prevent you from seeing clearly.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote." },
				new BaseDesign { Id = 3, Image = @"\Images\Necklace.webp", Name = "Smile Necklace", Type = "Company", Description = "We created a custom milgrain smile style necklace for a client's sentimental single cut diamonds. This same design can be modified for stones of any size, color, or shape!\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote." },
				new BaseDesign { Id = 4, Image = @"\Images\Band.webp", Name = "Swirl Diamond Wedding Band", Type = "Company", Description = "Swirls of platinum arc and curl around sparkling round brilliant cut diamonds to create this unique wedding band.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote." },
				new BaseDesign { Id = 5, Image = @"\Images\7979-image-1612583658_1440x.jpg", Name = "Pink Oval Diamond Halo Engagement Ring", Type = "Company", Description = "The perfect blend of classic and modern, this custom ring has a major wow factor: a 1.5ct oval pink diamond, surrounded by a classic halo of ideally cut Hearts and Arrows diamonds. Set in rose gold, this ring is feminine and romantic." },
				new BaseDesign { Id = 6, Image = @"\Images\87a248f457f2f0977135becb26dc43ce-img-1.webp", Name = "Family Heart Pendant", Type = "Company", Description = "Our client wanted a symbolic heart necklace for his wife. We added two big diamonds, for the two of them, and seven accent diamonds to represent everyone in their family." },
				new BaseDesign { Id = 7, Image = @"\Images\0e225f328c462698e949123a76f73fd3-img-1_97a7a112-f7bf-4449-bfb5-4e1329e805dc.webp", Name = "Lotus Purple Diamond & Sapphire Ring", Type = "Company", Description = "This custom engagement ring features a bi-colored blue and purple sapphire, and color enhanced purple diamonds, set into a five petal lotus design with black rhodium detailing. The shank is two intertwining stems, terminating in delicate leaves." },
				new BaseDesign { Id = 8, Image = @"\Images\Custom_Blue_Diamond_Swirl_Engagement_Ring_Platinum_Bezel_Set_C109875_1.webp", Name = "Bezel Set Swirl Blue Diamond Engagement Ring", Type = "Company", Description = "Ribbons of platinum twist around a round brilliant cut blue diamond and swirl around your finger, for a wonderfully unique solitaire design." },
				new BaseDesign { Id = 9, Image = @"\Images\Custom_Trillion_Diamond_Alexandrite_Earrings_White_Gold_C111970-003_1.webp", Name = "Diamond & Alexandrite Stud Earrings", Type = "Company", Description = "A petite drop, these earrings feature trillion cut diamonds that point to round bezel set alexandrites, for a bold, geometric design." },
				new BaseDesign { Id = 10, Image = @"\Images\Custom_Yellow_Gold_Bezel_Set_Amethyst_Ring_C109170_2.webp", Name = "Bezel Set Amethyst Ring", Type = "Company", Description = "This three stone ring makes a statement, with a jawdropping bezel set emerald cut amethyst at its center. A diamond is set on either side in the yellow gold split shank." },
				new BaseDesign { Id = 11, Image = @"\Images\FR105-ladies-custom-mothers-ring-stackable-with-sapphire-and-emerald-yellow-gold_e24f839f-d6fd-4304-bd59-c17e12e871b3.webp", Name = "Stackable fashion ring or mother's ring", Type = "Company", Description = "This is a fun, modern fashion ring with a geometric design that can double as a mother's ring! It's a mother's ring with a twist - definitely not your typical mother's ring style. Stack them in any order, adding more rings to mix and match. This ring can be made in any metal with your choice of gemstones or diamonds." },
				new BaseDesign { Id = 12, Image = @"\Images\ER101-tahitian-pearls-trillion-sapphires-diamond-drop-earrings_09b1a9b1-0d3d-421c-af9a-029ca1ecb008.webp", Name = "Tahitian Pearl and Sapphire Earrings", Type = "Company", Description = "Looking for longer pearl earrings and finding a bunch of studs and short drops? You're not alone! Here's a pair of distinctive Tahitian pearl earring drops with an elegant, organic design." },
				new BaseDesign { Id = 13, Image = @"\Images\8067-image-1580068996_e1f67302-b0d6-43d9-9399-472e090e120d.webp", Name = "Anchor and Wings Ring Guard", Type = "Company", Description = "With custom, you get to include multiple elements that mean something to you. This ring guard features an anchor and wings, set with a diamond and a ruby for a look that gleams with meaning." },
				new BaseDesign { Id = 14, Image = @"\Images\BAND103-Black-and-white-diamond-band_64789a11-0a58-48a4-90a9-46b2f10e850c.webp", Name = "White and Black Diamond Band", Type = "Company", Description = "This ring is a bold band with black diamonds that perfectly complement the white diamonds. A simple statement on its own, this ring is a unisex design." },
				new BaseDesign { Id = 15, Image = @"\Images\Custom_Yellow_Gold_Leaf_Woven_Wedding_Band_C108630_1_3540f942-ad41-4aa7-bc6e-1e1355167da8.webp", Name = "Woven Leaf Wedding Band", Type = "Company", Description = "Branches of high polished yellow gold weave and overlap. Matte finished leaves are accented with milgrain, creating this organic wedding band." },
				new BaseDesign { Id = 16, Image = @"\Images\Custom_Scalloped_Dainty_Eternity_Diamond_Wedding_Band_C115153_1_fb567c30-10ac-479f-bf34-600ae9d4af9a.webp", Name = "Dainty Scalloped Diamond Eternity Wedding Band", Type = "Company", Description = "Lovely and dainty, these scalloped white gold wedding bands have tapered round diamonds set all the way around." },
				new BaseDesign { Id = 17, Image = @"\Images\3d045b12c6cc607bfd55bb60c91fe076-img-1_22ebbc37-1a14-4122-a6ca-e661d952b838.webp", Name = "Diamond and Pearl Chevron Ring", Type = "Company", Description = "This delicate constellation inspired pearl and diamond chevron-style band was created to flank either side of a client's ring." },
				new BaseDesign { Id = 18, Image = @"\Images\63874425ac7e06ac9bd4167b6d2cffb5-img-1_38bb76f1-aa9d-4a74-9ac6-d2a401feae4c.webp", Name = "Platinum Etoile Style Diamond Band", Type = "Company", Description = "This custom ring features scattered flush set Hearts and Arrows diamonds, which are ideally cut to maximize sparkle. It's made out of our special heat treated platinum, which is a client favorite due to its extreme durability and natural white appearance." },
				new BaseDesign { Id = 19, Image = @"\Images\BAND110-Channel-Set-Band-Yellow-Side-Diamond_8b9e4895-270f-4d13-9287-287258fb4ff3.webp", Name = "Channel Set Band with Yellow Side Diamond", Type = "Company", Description = "Perfectly matched princess cut diamonds fill out the channel setting flawlessly, framed by double milgrain details and scrolling filigree cutouts on the side. All topped off with an adorable yellow side diamond!" },
				new BaseDesign { Id = 20, Image = @"\Images\BAND102-rose_de568f71-762f-4de6-9d2d-93318ad72bbb.webp", Name = "Rose gold diamond eternity band", Type = "Company", Description = "Simple and elegant, this diamond band is timeless. Customizable with whatever color gold or stones you like, wear this band with your engagement ring or as a stackable ring that goes with everything!" },
				new BaseDesign { Id = 21, Image = @"\Images\Custom_Yellow_Gold_Diamond_Open_Chevron_Wedding_Band_C113156_2.webp", Name = "Open Chevron Diamond Wedding Band", Type = "Company", Description = "A swish of diamonds creates an open, asymmetrical chevron shape in yellow gold for this custom wedding band." },
				new BaseDesign { Id = 22, Image = @"\Images\Custom_Toi_Et_Moi_Sapphire___Diamond_Twist_Ring_C111202_1_2026636c-3f7e-4b2c-815a-83f9ed37e499.webp", Name = "Pear Shaped Sapphire & Diamond Twist Toi Et Moi Ring", Type = "Company", Description = "A pear shaped diamond and sapphire come together at the center of this stunning Toi Et Moi ring. The band is open twists of yellow gold that shines beneath the center stones." },
				new BaseDesign { Id = 23, Image = @"\Images\89f7ed814c7ccd1af32d09d63cf03150-img-1_4ffe6193-4311-47f5-b54b-49afcb602d1d.webp", Name = "Coiled Mother's Ring", Type = "Company", Description = "This 14kt yellow gold family ring features colored diamond birthstones set in a fun and unique \"coil\" design that wraps around the finger. Make it yours by setting the birthstones of everyone in the family, or set it with clear white diamonds for a beautiful statement ring." },
				new BaseDesign { Id = 24, Image = @"\Images\da795683c5c20a96f7243c2d53b55bce-img-1_75211d5b-9e26-4605-865b-abd2a76436f8.webp", Name = "Onyx and Diamond Hexagon Ring", Type = "Company", Description = "This custom geometric 14k yellow gold engagement ring features a bezel set diamond, surrounded by a hexagonal onyx, set on-point." },
				new BaseDesign { Id = 25, Image = @"\Images\1cc052e03723f9d206b59aa9ed7548d1-img-1_d7de0c8b-ded6-48e7-8626-84ea7255c192.webp", Name = "Celestial Star and Moon Stud Earrings", Type = "Company", Description = "These custom white gold sparkling earrings feature Hearts and Arrows diamonds, pave set into crescent moon and star studs." },
				new BaseDesign { Id = 26, Image = @"\Images\Custom_Garnet___Moonstone_Mountain_Fish_Ring_C114994_1_dc85e0d6-ab1d-4dac-8d54-16daf7d79a64.webp", Name = "Garnet & Moonstone Mountain Fish Ring", Type = "Company", Description = "This captivating men's ring features a yellow gold fish against white gold mountains, bezel set with a garnet and a moonstone." },
				new BaseDesign { Id = 27, Image = @"\Images\adc394e3ef66788c3ee5f53eb4727713-img-1_b063ac0b-af0c-4215-9969-5469ecd5e82c.webp", Name = "Sea and Stars Ocean Nightscape Band", Type = "Company", Description = "We hand engraved a pattern on this yellow gold band based on our client's drawing: an ocean nightscape with rolling waves and twinkling stars." },
				new BaseDesign { Id = 28, Image = @"\Images\Custom_Three_Stone_Diamond_Engagement_Ring_Platinum_C106809_1.webp", Name = "Platinum Three Stone Diamond Engagement Ring", Type = "Company", Description = "Three round brilliant cut diamonds, all set in platinum with six prongs, make light glitter and dance." },
				new BaseDesign { Id = 29, Image = @"\Images\14493-image-1609295068_e14c0264-9533-429a-ac6c-6fafc3f4a184.webp", Name = "Modern Teal Sapphire Trillion Engagement Ring", Type = "Company", Description = "A 1.80ct trillion cut teal sapphire steals the show in this contemporary bypass wave ring with diamond accents." },
				new BaseDesign { Id = 30, Image = @"\Images\Custom_Graduated_Sapphire_Pearl___Diamond_Pendant_C113044_1_30550cf7-b8c1-4255-9f08-807cd25da78b.webp", Name = "Graduated Star Sapphire Pendant", Type = "Company", Description = "Graduated pink, purple, and blue sapphire wrap around star sapphires, accented with pearls and diamonds to create a spectacular, one of a kind pendant. The backside features beautiful waves and swirls in rose gold." },
				new BaseDesign { Id = 31, Image = @"\Images\9371ce3f3abde2b5cb55d46361fda4f5-img-1.webp", Name = "Geometric Alexandrite Necklace", Type = "Company", Description = "A stunning emerald cut Brazilian alexandrite weighing 1.00ct, takes center stage in this one of a kind geometric pendant, accented with a trillion cut white diamond and three round teal diamonds." },
				new BaseDesign { Id = 32, Image = @"\Images\bbe2560e1ec98dd6962daab21429d47d-img-1_7b2fb8a6-6d85-4197-90c6-d91558c68280.webp", Name = "Garnet Platinum Ring", Type = "Company", Description = "A classic style with a bold look, this three stone platinum ring features a princess cut Mozambique garnet  between two princess cut diamonds, all tied together with a euroshank!" },
				new BaseDesign { Id = 33, Image = @"\Images\ER104-Ruby-and-diamond-water-drop-earrings_00318228-da35-4d89-b817-f0d74c9f8bb9.webp", Name = "Ruby and diamond water drop earrings", Type = "Company", Description = "These beautiful earrings are part of a set with a matching pendant! Made using the client's stones, we designed this unique, freeform set in white gold. These earrings can be set with any gemstones or diamonds." },
				new BaseDesign { Id = 34, Image = @"\Images\b4d5613ae690104bf388af17964be9a2-img-1_e13c8c38-1b59-42ae-a4a5-12ade79002cc.webp", Name = "Star Sapphire Swirl Ring", Type = "Company", Description = "This 14k white gold bypass swirl ring features a round blue star sapphire and heirloom diamonds." }
				);

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Type = "Gold", Purity = 58.5m, Color = "White", Price = 100m },
                new Material { Id = 2, Type = "Gold", Purity = 41.7m, Color = "Rose", Price = 50m }, 
                new Material { Id = 3, Type = "Gold", Purity = 75.0m, Color = "Yellow", Price = 80m },
                new Material { Id = 4, Type = "Gold", Purity = 58.5m, Color = "Green", Price = 90m },
                new Material { Id = 5, Type = "Silver", Purity = 92.5m, Color = "Silver", Price = 60m },
                new Material { Id = 6, Type = "Silver", Purity = 99.9m, Color = "Silver", Price = 70m },
                new Material { Id = 7, Type = "Platinum", Purity = 95.0m, Color = "White", Price = 120m },
                new Material { Id = 8, Type = "Copper", Purity = 99.9m, Color = "Red", Price = 30m },
                new Material { Id = 9, Type = "Brass", Purity = 60.0m, Color = "Golden", Price = 40m },
                new Material { Id = 10, Type = "Titanium", Purity = 99.9m, Color = "Grey", Price = 50m },
				new Material { Id = 11, Type = "Steel", Purity = 30.0m, Color = "Silver", Price = 45m },
				new Material { Id = 12, Type = "Zinc", Purity = 69.0m, Color = "Grey", Price = 20m },
				new Material { Id = 13, Type = "Rhodium", Purity = 42.0m, Color = "White", Price = 150m },
				new Material { Id = 14, Type = "Palladium", Purity = 0.95m, Color = "White", Price = 100m },
				new Material { Id = 15, Type = "Iridium", Purity = 0.01m, Color = "Grey", Price = 180m }
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
				new Gemstone { Id = 50, Name = "Chalcedony", Price = 450, Carat = 1.2M, Color = "Blue", Clarity = "VS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 51, Name = "Diamond", Price = 2100, Carat = 2.5M, Color = "White", Clarity = "VS1", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 52, Name = "Diamond", Price = 2200, Carat = 3.2M, Color = "White", Clarity = "VVS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 53, Name = "Diamond", Price = 2300, Carat = 2.8M, Color = "White", Clarity = "VS2", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 54, Name = "Diamond", Price = 2400, Carat = 3.5M, Color = "White", Clarity = "VS1", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 55, Name = "Diamond", Price = 2500, Carat = 4M, Color = "White", Clarity = "VVS2", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 56, Name = "Diamond", Price = 2600, Carat = 3.1M, Color = "White", Clarity = "VS1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 57, Name = "Diamond", Price = 2700, Carat = 2.9M, Color = "White", Clarity = "VS2", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 58, Name = "Diamond", Price = 2800, Carat = 3.3M, Color = "White", Clarity = "VS1", Cut = "Oval", Status = "Available" },
				new Gemstone { Id = 59, Name = "Diamond", Price = 2900, Carat = 3.7M, Color = "White", Clarity = "VVS1", Cut = "Round", Status = "Available" },
				new Gemstone { Id = 60, Name = "Diamond", Price = 3000, Carat = 4.2M, Color = "White", Clarity = "VS2", Cut = "Princess", Status = "Available" },
				new Gemstone { Id = 61, Name = "Diamond", Price = 3100, Carat = 3.4M, Color = "White", Clarity = "VS1", Cut = "Emerald", Status = "Available" },
				new Gemstone { Id = 62, Name = "Diamond", Price = 3200, Carat = 3.6M, Color = "White", Clarity = "VVS2", Cut = "Marquise", Status = "Available" },
				new Gemstone { Id = 63, Name = "Diamond", Price = 3300, Carat = 3.8M, Color = "White", Clarity = "VS1", Cut = "Cushion", Status = "Available" },
				new Gemstone { Id = 64, Name = "Diamond", Price = 3400, Carat = 4.1M, Color = "White", Clarity = "VS2", Cut = "Heart", Status = "Available" },
				new Gemstone { Id = 65, Name = "Diamond", Price = 3500, Carat = 4.3M, Color = "White", Clarity = "VS1", Cut = "Oval", Status = "Available" }

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
