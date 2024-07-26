using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDesigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gemstones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemstones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Purity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DesignStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductionStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_AspNetUsers_DesignStaffId",
                        column: x => x.DesignStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_AspNetUsers_ProductionStaffId",
                        column: x => x.ProductionStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_AspNetUsers_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseDesignId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_BaseDesigns_BaseDesignId",
                        column: x => x.BaseDesignId,
                        principalTable: "BaseDesigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GemstoneMaterialSet",
                columns: table => new
                {
                    GemstonesId = table.Column<int>(type: "int", nullable: false),
                    MaterialSetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemstoneMaterialSet", x => new { x.GemstonesId, x.MaterialSetsId });
                    table.ForeignKey(
                        name: "FK_GemstoneMaterialSet_Gemstones_GemstonesId",
                        column: x => x.GemstonesId,
                        principalTable: "Gemstones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GemstoneMaterialSet_MaterialSets_MaterialSetsId",
                        column: x => x.MaterialSetsId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSetsMaterials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSetsMaterials", x => new { x.MaterialId, x.MaterialSetId });
                    table.ForeignKey(
                        name: "FK_MaterialSetsMaterials_MaterialSets_MaterialSetId",
                        column: x => x.MaterialSetId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialSetsMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jewelries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductionStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductionRequestId = table.Column<int>(type: "int", nullable: false),
                    BaseDesignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewelries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jewelries_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jewelries_AspNetUsers_ProductionStaffId",
                        column: x => x.ProductionStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jewelries_AspNetUsers_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jewelries_BaseDesigns_BaseDesignId",
                        column: x => x.BaseDesignId,
                        principalTable: "BaseDesigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jewelries_MaterialSets_MaterialSetId",
                        column: x => x.MaterialSetId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jewelries_ProductionRequests_ProductionRequestId",
                        column: x => x.ProductionRequestId,
                        principalTable: "ProductionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionRequestId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BaseDesignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRequestDetails_BaseDesigns_BaseDesignId",
                        column: x => x.BaseDesignId,
                        principalTable: "BaseDesigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionRequestDetails_ProductionRequests_ProductionRequestId",
                        column: x => x.ProductionRequestId,
                        principalTable: "ProductionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JewelryDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DesignStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductionStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryDesigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_AspNetUsers_DesignStaffId",
                        column: x => x.DesignStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_AspNetUsers_ProductionStaffId",
                        column: x => x.ProductionStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LaborPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationRequests_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_AspNetUsers_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_MaterialSets_MaterialSetId",
                        column: x => x.MaterialSetId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantyCards_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarrantyCards_AspNetUsers_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarrantyCards_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    WarrantyCardId = table.Column<int>(type: "int", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => new { x.CustomerId, x.SalesStaffId, x.JewelryId, x.WarrantyCardId });
                    table.ForeignKey(
                        name: "FK_Deliveries_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_AspNetUsers_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_WarrantyCards_WarrantyCardId",
                        column: x => x.WarrantyCardId,
                        principalTable: "WarrantyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BaseDesigns",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, null, "\\Images\\Ring.webp", "Bezel Solitarie Engagement Ring", "Company" },
                    { 2, null, null, "\\Images\\Pendant.jpg", "Diamond Reiki Symbol Pendant", "Company" },
                    { 3, null, null, "\\Images\\Necklace.webp", "Smile Necklace", "Company" },
                    { 4, null, null, "\\Images\\Band.webp", "Swirl Diamond Wedding Band", "Company" }
                });

            migrationBuilder.InsertData(
                table: "Gemstones",
                columns: new[] { "Id", "Carat", "Clarity", "Color", "Cut", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, 3m, "VS1", "White", "Round", "Diamond", 2000m, "Available" },
                    { 2, 1.5m, "VVS1", "Red", "Oval", "Ruby", 1500m, "Available" },
                    { 3, 1.8m, "VS2", "Blue", "Princess", "Sapphire", 1800m, "Available" },
                    { 4, 2m, "VS2", "White", "Emerald", "Diamond", 1800m, "Available" },
                    { 5, 1m, "VVS2", "White", "Marquise", "Diamond", 1000m, "Available" },
                    { 6, 2.5m, "VS1", "Green", "Cushion", "Emerald", 2500m, "Available" },
                    { 7, 1.2m, "SI1", "Purple", "Heart", "Amethyst", 600m, "Available" },
                    { 8, 1.8m, "VS1", "Yellow", "Oval", "Topaz", 800m, "Available" },
                    { 9, 1.9m, "VS2", "Blue", "Marquise", "Aquamarine", 1100m, "Available" },
                    { 10, 1.4m, "VS1", "Red", "Round", "Garnet", 700m, "Available" },
                    { 11, 1.5m, "SI1", "Green", "Princess", "Peridot", 500m, "Available" },
                    { 12, 1.3m, "VS2", "Yellow", "Emerald", "Citrine", 400m, "Available" },
                    { 13, 1.7m, "VS1", "Pink", "Cushion", "Morganite", 1200m, "Available" },
                    { 14, 1.6m, "VS2", "Multi", "Heart", "Opal", 900m, "Available" },
                    { 15, 1.3m, "VS1", "Red", "Oval", "Spinel", 950m, "Available" },
                    { 16, 2m, "VS2", "Green", "Round", "Tourmaline", 1000m, "Available" },
                    { 17, 1.8m, "VS1", "Blue", "Marquise", "Tanzanite", 1300m, "Available" },
                    { 18, 1.2m, "VS2", "Blue", "Princess", "Zircon", 450m, "Available" },
                    { 19, 1.5m, "SI1", "Green", "Emerald", "Jade", 700m, "Available" },
                    { 20, 1.4m, "VS1", "Blue", "Cushion", "Lapis", 550m, "Available" },
                    { 21, 1.3m, "VS2", "Blue", "Heart", "Turquoise", 600m, "Available" },
                    { 22, 1.1m, "VS1", "White", "Oval", "Moonstone", 400m, "Available" },
                    { 23, 1.2m, "SI1", "Black", "Round", "Onyx", 350m, "Available" },
                    { 24, 1.5m, "VS2", "Green", "Princess", "Alexandrite", 3000m, "Available" },
                    { 25, 1.0m, "VS1", "Orange", "Emerald", "Carnelian", 200m, "Available" },
                    { 26, 1.7m, "VS2", "Pink", "Cushion", "Kunzite", 850m, "Available" },
                    { 27, 1.3m, "VS1", "Blue", "Heart", "Larimar", 400m, "Available" },
                    { 28, 1.2m, "SI1", "Green", "Oval", "Malachite", 300m, "Available" },
                    { 29, 1.1m, "VS2", "Black", "Round", "Obsidian", 200m, "Available" },
                    { 30, 1.0m, "VS1", "White", "Round", "Pearl", 100m, "Available" },
                    { 31, 2m, "VS2", "Green", "Marquise", "Beryl", 1300m, "Available" },
                    { 32, 1.3m, "SI1", "Green", "Princess", "Bloodstone", 500m, "Available" },
                    { 33, 1.1m, "VS1", "Red", "Emerald", "Coral", 400m, "Available" },
                    { 34, 1.0m, "VS2", "Black", "Cushion", "Hematite", 300m, "Available" },
                    { 35, 1.4m, "VS1", "Blue", "Heart", "Iolite", 700m, "Available" },
                    { 36, 1.0m, "SI1", "Red", "Oval", "Jasper", 200m, "Available" },
                    { 37, 1.5m, "VS2", "Blue", "Round", "Kyanite", 600m, "Available" },
                    { 38, 1.2m, "VS1", "Grey", "Marquise", "Labradorite", 500m, "Available" },
                    { 39, 1.1m, "VS2", "Pink", "Princess", "Rhodochrosite", 450m, "Available" },
                    { 40, 1.2m, "VS1", "Blue", "Emerald", "Sodalite", 300m, "Available" },
                    { 41, 1.3m, "SI1", "Purple", "Cushion", "Sugilite", 350m, "Available" },
                    { 42, 1.4m, "VS2", "Orange", "Heart", "Sunstone", 400m, "Available" },
                    { 43, 1.1m, "VS1", "Brown", "Oval", "TigersEye", 250m, "Available" },
                    { 44, 1.2m, "VS2", "Blue", "Round", "Turquoise", 500m, "Available" },
                    { 45, 1.0m, "SI1", "Green", "Marquise", "Unakite", 200m, "Available" },
                    { 46, 1.5m, "VS1", "Green", "Princess", "Variscite", 600m, "Available" },
                    { 47, 1.6m, "VS2", "Blue", "Emerald", "Zircon", 700m, "Available" },
                    { 48, 1.7m, "VS1", "Purple", "Cushion", "Ametrine", 1000m, "Available" },
                    { 49, 1.8m, "VS2", "Blue", "Heart", "Benitoite", 3000m, "Available" },
                    { 50, 1.2m, "VS1", "Blue", "Oval", "Chalcedony", 450m, "Available" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Color", "Price", "Purity", "Type" },
                values: new object[,]
                {
                    { 1, "White", 100m, "14K", "Gold" },
                    { 2, "Rose", 50m, "10K", "Gold" },
                    { 3, "Yellow", 80m, "18K", "Gold" },
                    { 4, "Green", 90m, "14K", "Gold" },
                    { 5, "Silver", 60m, "925", "Silver" },
                    { 6, "Silver", 70m, "999", "Silver" },
                    { 7, "White", 120m, "950", "Platinum" },
                    { 8, "Red", 30m, "99.9%", "Copper" },
                    { 9, "Golden", 40m, "60%", "Brass" },
                    { 10, "Grey", 50m, "99.9%", "Titanium" },
                    { 11, "Silver", 45m, "304", "Steel" },
                    { 12, "Grey", 20m, "99.9%", "Zinc" },
                    { 13, "White", 150m, "99.9%", "Rhodium" },
                    { 14, "White", 100m, "95%", "Palladium" },
                    { 15, "Grey", 180m, "99.9%", "Iridium" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_JewelryId",
                table: "Deliveries",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_SalesStaffId",
                table: "Deliveries",
                column: "SalesStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_WarrantyCardId",
                table: "Deliveries",
                column: "WarrantyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_GemstoneMaterialSet_MaterialSetsId",
                table: "GemstoneMaterialSet",
                column: "MaterialSetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_BaseDesignId",
                table: "Jewelries",
                column: "BaseDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_CustomerId",
                table: "Jewelries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_MaterialSetId",
                table: "Jewelries",
                column: "MaterialSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_ProductionRequestId",
                table: "Jewelries",
                column: "ProductionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_ProductionStaffId",
                table: "Jewelries",
                column: "ProductionStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_SalesStaffId",
                table: "Jewelries",
                column: "SalesStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_CustomerId",
                table: "JewelryDesigns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_DesignStaffId",
                table: "JewelryDesigns",
                column: "DesignStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_JewelryId",
                table: "JewelryDesigns",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_ProductionStaffId",
                table: "JewelryDesigns",
                column: "ProductionStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSetsMaterials_MaterialSetId",
                table: "MaterialSetsMaterials",
                column: "MaterialSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SalesStaffId",
                table: "Posts",
                column: "SalesStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequestDetails_BaseDesignId",
                table: "ProductionRequestDetails",
                column: "BaseDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequestDetails_ProductionRequestId",
                table: "ProductionRequestDetails",
                column: "ProductionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequests_CustomerId",
                table: "ProductionRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequests_DesignStaffId",
                table: "ProductionRequests",
                column: "DesignStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequests_ProductionStaffId",
                table: "ProductionRequests",
                column: "ProductionStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequests_SalesStaffId",
                table: "ProductionRequests",
                column: "SalesStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_CustomerId",
                table: "QuotationRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_ManagerId",
                table: "QuotationRequests",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_MaterialSetId",
                table: "QuotationRequests",
                column: "MaterialSetId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_SalesStaffId",
                table: "QuotationRequests",
                column: "SalesStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_BaseDesignId",
                table: "ShoppingCarts",
                column: "BaseDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyCards_CustomerId",
                table: "WarrantyCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyCards_JewelryId",
                table: "WarrantyCards",
                column: "JewelryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyCards_SalesStaffId",
                table: "WarrantyCards",
                column: "SalesStaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "GemstoneMaterialSet");

            migrationBuilder.DropTable(
                name: "JewelryDesigns");

            migrationBuilder.DropTable(
                name: "MaterialSetsMaterials");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProductionRequestDetails");

            migrationBuilder.DropTable(
                name: "QuotationRequests");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WarrantyCards");

            migrationBuilder.DropTable(
                name: "Gemstones");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Jewelries");

            migrationBuilder.DropTable(
                name: "BaseDesigns");

            migrationBuilder.DropTable(
                name: "MaterialSets");

            migrationBuilder.DropTable(
                name: "ProductionRequests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
