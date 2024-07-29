using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class databaseOfCRUDGemstoneAfterMergingWithMaterialSet : Migration
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
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Purity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
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
                name: "MaterialSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSets_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemstones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gemstones_MaterialSets_MaterialSetId",
                        column: x => x.MaterialSetId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialSetsMaterials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
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
                name: "Deliveries",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalesStaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    WarrantyCardId = table.Column<int>(type: "int", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { 1, null, "Sleek and contemporary, this 4.50ct round brilliant cut diamond pops in a custom bezel set solitaire ring. This setting was custom made to allow for the large center stone to sit as close to the finger as possible.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.", "\\Images\\Ring.webp", "Bezel Solitarie Engagement Ring", "Company" },
                    { 2, null, "Reiki symbols are used in alternative healing. After a major life upheaval, our client found meaning in the At Mata symbol, crafted using white gold and a trillion cut diamond, which is said to remove emotional blocks that prevent you from seeing clearly.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.", "\\Images\\Pendant.jpg", "Diamond Reiki Symbol Pendant", "Company" },
                    { 3, null, "We created a custom milgrain smile style necklace for a client's sentimental single cut diamonds. This same design can be modified for stones of any size, color, or shape!\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.", "\\Images\\Necklace.webp", "Smile Necklace", "Company" },
                    { 4, null, "Swirls of platinum arc and curl around sparkling round brilliant cut diamonds to create this unique wedding band.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.", "\\Images\\Band.webp", "Swirl Diamond Wedding Band", "Company" },
                    { 5, null, "The perfect blend of classic and modern, this custom ring has a major wow factor: a 1.5ct oval pink diamond, surrounded by a classic halo of ideally cut Hearts and Arrows diamonds. Set in rose gold, this ring is feminine and romantic.", "\\Images\\7979-image-1612583658_1440x.jpg", "Pink Oval Diamond Halo Engagement Ring", "Company" },
                    { 6, null, "Our client wanted a symbolic heart necklace for his wife. We added two big diamonds, for the two of them, and seven accent diamonds to represent everyone in their family.", "\\Images\\87a248f457f2f0977135becb26dc43ce-img-1.webp", "Family Heart Pendant", "Company" },
                    { 7, null, "This custom engagement ring features a bi-colored blue and purple sapphire, and color enhanced purple diamonds, set into a five petal lotus design with black rhodium detailing. The shank is two intertwining stems, terminating in delicate leaves.", "\\Images\\0e225f328c462698e949123a76f73fd3-img-1_97a7a112-f7bf-4449-bfb5-4e1329e805dc.webp", "Lotus Purple Diamond & Sapphire Ring", "Company" },
                    { 8, null, "Ribbons of platinum twist around a round brilliant cut blue diamond and swirl around your finger, for a wonderfully unique solitaire design.", "\\Images\\Custom_Blue_Diamond_Swirl_Engagement_Ring_Platinum_Bezel_Set_C109875_1.webp", "Bezel Set Swirl Blue Diamond Engagement Ring", "Company" },
                    { 9, null, "A petite drop, these earrings feature trillion cut diamonds that point to round bezel set alexandrites, for a bold, geometric design.", "\\Images\\Custom_Trillion_Diamond_Alexandrite_Earrings_White_Gold_C111970-003_1.webp", "Diamond & Alexandrite Stud Earrings", "Company" },
                    { 10, null, "This three stone ring makes a statement, with a jawdropping bezel set emerald cut amethyst at its center. A diamond is set on either side in the yellow gold split shank.", "\\Images\\Custom_Yellow_Gold_Bezel_Set_Amethyst_Ring_C109170_2.webp", "Bezel Set Amethyst Ring", "Company" },
                    { 11, null, "This is a fun, modern fashion ring with a geometric design that can double as a mother's ring! It's a mother's ring with a twist - definitely not your typical mother's ring style. Stack them in any order, adding more rings to mix and match. This ring can be made in any metal with your choice of gemstones or diamonds.", "\\Images\\FR105-ladies-custom-mothers-ring-stackable-with-sapphire-and-emerald-yellow-gold_e24f839f-d6fd-4304-bd59-c17e12e871b3.webp", "Stackable fashion ring or mother's ring", "Company" },
                    { 12, null, "Looking for longer pearl earrings and finding a bunch of studs and short drops? You're not alone! Here's a pair of distinctive Tahitian pearl earring drops with an elegant, organic design.", "\\Images\\ER101-tahitian-pearls-trillion-sapphires-diamond-drop-earrings_09b1a9b1-0d3d-421c-af9a-029ca1ecb008.webp", "Tahitian Pearl and Sapphire Earrings", "Company" },
                    { 13, null, "With custom, you get to include multiple elements that mean something to you. This ring guard features an anchor and wings, set with a diamond and a ruby for a look that gleams with meaning.", "\\Images\\8067-image-1580068996_e1f67302-b0d6-43d9-9399-472e090e120d.webp", "Anchor and Wings Ring Guard", "Company" },
                    { 14, null, "This ring is a bold band with black diamonds that perfectly complement the white diamonds. A simple statement on its own, this ring is a unisex design.", "\\Images\\BAND103-Black-and-white-diamond-band_64789a11-0a58-48a4-90a9-46b2f10e850c.webp", "White and Black Diamond Band", "Company" },
                    { 15, null, "Branches of high polished yellow gold weave and overlap. Matte finished leaves are accented with milgrain, creating this organic wedding band.", "\\Images\\Custom_Yellow_Gold_Leaf_Woven_Wedding_Band_C108630_1_3540f942-ad41-4aa7-bc6e-1e1355167da8.webp", "Woven Leaf Wedding Band", "Company" },
                    { 16, null, "Lovely and dainty, these scalloped white gold wedding bands have tapered round diamonds set all the way around.", "\\Images\\Custom_Scalloped_Dainty_Eternity_Diamond_Wedding_Band_C115153_1_fb567c30-10ac-479f-bf34-600ae9d4af9a.webp", "Dainty Scalloped Diamond Eternity Wedding Band", "Company" },
                    { 17, null, "This delicate constellation inspired pearl and diamond chevron-style band was created to flank either side of a client's ring.", "\\Images\\3d045b12c6cc607bfd55bb60c91fe076-img-1_22ebbc37-1a14-4122-a6ca-e661d952b838.webp", "Diamond and Pearl Chevron Ring", "Company" },
                    { 18, null, "This custom ring features scattered flush set Hearts and Arrows diamonds, which are ideally cut to maximize sparkle. It's made out of our special heat treated platinum, which is a client favorite due to its extreme durability and natural white appearance.", "\\Images\\63874425ac7e06ac9bd4167b6d2cffb5-img-1_38bb76f1-aa9d-4a74-9ac6-d2a401feae4c.webp", "Platinum Etoile Style Diamond Band", "Company" },
                    { 19, null, "Perfectly matched princess cut diamonds fill out the channel setting flawlessly, framed by double milgrain details and scrolling filigree cutouts on the side. All topped off with an adorable yellow side diamond!", "\\Images\\BAND110-Channel-Set-Band-Yellow-Side-Diamond_8b9e4895-270f-4d13-9287-287258fb4ff3.webp", "Channel Set Band with Yellow Side Diamond", "Company" },
                    { 20, null, "Simple and elegant, this diamond band is timeless. Customizable with whatever color gold or stones you like, wear this band with your engagement ring or as a stackable ring that goes with everything!", "\\Images\\BAND102-rose_de568f71-762f-4de6-9d2d-93318ad72bbb.webp", "Rose gold diamond eternity band", "Company" },
                    { 21, null, "A swish of diamonds creates an open, asymmetrical chevron shape in yellow gold for this custom wedding band.", "\\Images\\Custom_Yellow_Gold_Diamond_Open_Chevron_Wedding_Band_C113156_2.webp", "Open Chevron Diamond Wedding Band", "Company" },
                    { 22, null, "A pear shaped diamond and sapphire come together at the center of this stunning Toi Et Moi ring. The band is open twists of yellow gold that shines beneath the center stones.", "\\Images\\Custom_Toi_Et_Moi_Sapphire___Diamond_Twist_Ring_C111202_1_2026636c-3f7e-4b2c-815a-83f9ed37e499.webp", "Pear Shaped Sapphire & Diamond Twist Toi Et Moi Ring", "Company" },
                    { 23, null, "This 14kt yellow gold family ring features colored diamond birthstones set in a fun and unique \"coil\" design that wraps around the finger. Make it yours by setting the birthstones of everyone in the family, or set it with clear white diamonds for a beautiful statement ring.", "\\Images\\89f7ed814c7ccd1af32d09d63cf03150-img-1_4ffe6193-4311-47f5-b54b-49afcb602d1d.webp", "Coiled Mother's Ring", "Company" },
                    { 24, null, "This custom geometric 14k yellow gold engagement ring features a bezel set diamond, surrounded by a hexagonal onyx, set on-point.", "\\Images\\da795683c5c20a96f7243c2d53b55bce-img-1_75211d5b-9e26-4605-865b-abd2a76436f8.webp", "Onyx and Diamond Hexagon Ring", "Company" },
                    { 25, null, "These custom white gold sparkling earrings feature Hearts and Arrows diamonds, pave set into crescent moon and star studs.", "\\Images\\1cc052e03723f9d206b59aa9ed7548d1-img-1_d7de0c8b-ded6-48e7-8626-84ea7255c192.webp", "Celestial Star and Moon Stud Earrings", "Company" },
                    { 26, null, "This captivating men's ring features a yellow gold fish against white gold mountains, bezel set with a garnet and a moonstone.", "\\Images\\Custom_Garnet___Moonstone_Mountain_Fish_Ring_C114994_1_dc85e0d6-ab1d-4dac-8d54-16daf7d79a64.webp", "Garnet & Moonstone Mountain Fish Ring", "Company" },
                    { 27, null, "We hand engraved a pattern on this yellow gold band based on our client's drawing: an ocean nightscape with rolling waves and twinkling stars.", "\\Images\\adc394e3ef66788c3ee5f53eb4727713-img-1_b063ac0b-af0c-4215-9969-5469ecd5e82c.webp", "Sea and Stars Ocean Nightscape Band", "Company" },
                    { 28, null, "Three round brilliant cut diamonds, all set in platinum with six prongs, make light glitter and dance.", "\\Images\\Custom_Three_Stone_Diamond_Engagement_Ring_Platinum_C106809_1.webp", "Platinum Three Stone Diamond Engagement Ring", "Company" },
                    { 29, null, "A 1.80ct trillion cut teal sapphire steals the show in this contemporary bypass wave ring with diamond accents.", "\\Images\\14493-image-1609295068_e14c0264-9533-429a-ac6c-6fafc3f4a184.webp", "Modern Teal Sapphire Trillion Engagement Ring", "Company" },
                    { 30, null, "Graduated pink, purple, and blue sapphire wrap around star sapphires, accented with pearls and diamonds to create a spectacular, one of a kind pendant. The backside features beautiful waves and swirls in rose gold.", "\\Images\\Custom_Graduated_Sapphire_Pearl___Diamond_Pendant_C113044_1_30550cf7-b8c1-4255-9f08-807cd25da78b.webp", "Graduated Star Sapphire Pendant", "Company" },
                    { 31, null, "A stunning emerald cut Brazilian alexandrite weighing 1.00ct, takes center stage in this one of a kind geometric pendant, accented with a trillion cut white diamond and three round teal diamonds.", "\\Images\\9371ce3f3abde2b5cb55d46361fda4f5-img-1.webp", "Geometric Alexandrite Necklace", "Company" },
                    { 32, null, "A classic style with a bold look, this three stone platinum ring features a princess cut Mozambique garnet  between two princess cut diamonds, all tied together with a euroshank!", "\\Images\\bbe2560e1ec98dd6962daab21429d47d-img-1_7b2fb8a6-6d85-4197-90c6-d91558c68280.webp", "Garnet Platinum Ring", "Company" },
                    { 33, null, "These beautiful earrings are part of a set with a matching pendant! Made using the client's stones, we designed this unique, freeform set in white gold. These earrings can be set with any gemstones or diamonds.", "\\Images\\ER104-Ruby-and-diamond-water-drop-earrings_00318228-da35-4d89-b817-f0d74c9f8bb9.webp", "Ruby and diamond water drop earrings", "Company" },
                    { 34, null, "This 14k white gold bypass swirl ring features a round blue star sapphire and heirloom diamonds.", "\\Images\\b4d5613ae690104bf388af17964be9a2-img-1_e13c8c38-1b59-42ae-a4a5-12ade79002cc.webp", "Star Sapphire Swirl Ring", "Company" }
                });

            migrationBuilder.InsertData(
                table: "Gemstones",
                columns: new[] { "Id", "Carat", "Clarity", "Color", "Cut", "MaterialSetId", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, 3m, "VS1", "White", "Round", null, "Diamond", 2000m, "Available" },
                    { 2, 1.5m, "VVS1", "Red", "Oval", null, "Ruby", 1500m, "Available" },
                    { 3, 1.8m, "VS2", "Blue", "Princess", null, "Sapphire", 1800m, "Available" },
                    { 4, 2m, "VS2", "White", "Emerald", null, "Diamond", 1800m, "Available" },
                    { 5, 1m, "VVS2", "White", "Marquise", null, "Diamond", 1000m, "Available" },
                    { 6, 2.5m, "VS1", "Green", "Cushion", null, "Emerald", 2500m, "Available" },
                    { 7, 1.2m, "SI1", "Purple", "Heart", null, "Amethyst", 600m, "Available" },
                    { 8, 1.8m, "VS1", "Yellow", "Oval", null, "Topaz", 800m, "Available" },
                    { 9, 1.9m, "VS2", "Blue", "Marquise", null, "Aquamarine", 1100m, "Available" },
                    { 10, 1.4m, "VS1", "Red", "Round", null, "Garnet", 700m, "Available" },
                    { 11, 1.5m, "SI1", "Green", "Princess", null, "Peridot", 500m, "Available" },
                    { 12, 1.3m, "VS2", "Yellow", "Emerald", null, "Citrine", 400m, "Available" },
                    { 13, 1.7m, "VS1", "Pink", "Cushion", null, "Morganite", 1200m, "Available" },
                    { 14, 1.6m, "VS2", "Multi", "Heart", null, "Opal", 900m, "Available" },
                    { 15, 1.3m, "VS1", "Red", "Oval", null, "Spinel", 950m, "Available" },
                    { 16, 2m, "VS2", "Green", "Round", null, "Tourmaline", 1000m, "Available" },
                    { 17, 1.8m, "VS1", "Blue", "Marquise", null, "Tanzanite", 1300m, "Available" },
                    { 18, 1.2m, "VS2", "Blue", "Princess", null, "Zircon", 450m, "Available" },
                    { 19, 1.5m, "SI1", "Green", "Emerald", null, "Jade", 700m, "Available" },
                    { 20, 1.4m, "VS1", "Blue", "Cushion", null, "Lapis", 550m, "Available" },
                    { 21, 1.3m, "VS2", "Blue", "Heart", null, "Turquoise", 600m, "Available" },
                    { 22, 1.1m, "VS1", "White", "Oval", null, "Moonstone", 400m, "Available" },
                    { 23, 1.2m, "SI1", "Black", "Round", null, "Onyx", 350m, "Available" },
                    { 24, 1.5m, "VS2", "Green", "Princess", null, "Alexandrite", 3000m, "Available" },
                    { 25, 1.0m, "VS1", "Orange", "Emerald", null, "Carnelian", 200m, "Available" },
                    { 26, 1.7m, "VS2", "Pink", "Cushion", null, "Kunzite", 850m, "Available" },
                    { 27, 1.3m, "VS1", "Blue", "Heart", null, "Larimar", 400m, "Available" },
                    { 28, 1.2m, "SI1", "Green", "Oval", null, "Malachite", 300m, "Available" },
                    { 29, 1.1m, "VS2", "Black", "Round", null, "Obsidian", 200m, "Available" },
                    { 30, 1.0m, "VS1", "White", "Round", null, "Pearl", 100m, "Available" },
                    { 31, 2m, "VS2", "Green", "Marquise", null, "Beryl", 1300m, "Available" },
                    { 32, 1.3m, "SI1", "Green", "Princess", null, "Bloodstone", 500m, "Available" },
                    { 33, 1.1m, "VS1", "Red", "Emerald", null, "Coral", 400m, "Available" },
                    { 34, 1.0m, "VS2", "Black", "Cushion", null, "Hematite", 300m, "Available" },
                    { 35, 1.4m, "VS1", "Blue", "Heart", null, "Iolite", 700m, "Available" },
                    { 36, 1.0m, "SI1", "Red", "Oval", null, "Jasper", 200m, "Available" },
                    { 37, 1.5m, "VS2", "Blue", "Round", null, "Kyanite", 600m, "Available" },
                    { 38, 1.2m, "VS1", "Grey", "Marquise", null, "Labradorite", 500m, "Available" },
                    { 39, 1.1m, "VS2", "Pink", "Princess", null, "Rhodochrosite", 450m, "Available" },
                    { 40, 1.2m, "VS1", "Blue", "Emerald", null, "Sodalite", 300m, "Available" },
                    { 41, 1.3m, "SI1", "Purple", "Cushion", null, "Sugilite", 350m, "Available" },
                    { 42, 1.4m, "VS2", "Orange", "Heart", null, "Sunstone", 400m, "Available" },
                    { 43, 1.1m, "VS1", "Brown", "Oval", null, "TigersEye", 250m, "Available" },
                    { 44, 1.2m, "VS2", "Blue", "Round", null, "Turquoise", 500m, "Available" },
                    { 45, 1.0m, "SI1", "Green", "Marquise", null, "Unakite", 200m, "Available" },
                    { 46, 1.5m, "VS1", "Green", "Princess", null, "Variscite", 600m, "Available" },
                    { 47, 1.6m, "VS2", "Blue", "Emerald", null, "Zircon", 700m, "Available" },
                    { 48, 1.7m, "VS1", "Purple", "Cushion", null, "Ametrine", 1000m, "Available" },
                    { 49, 1.8m, "VS2", "Blue", "Heart", null, "Benitoite", 3000m, "Available" },
                    { 50, 1.2m, "VS1", "Blue", "Oval", null, "Chalcedony", 450m, "Available" },
                    { 51, 2.5m, "VS1", "White", "Round", null, "Diamond", 2100m, "Available" },
                    { 52, 3.2m, "VVS1", "White", "Oval", null, "Diamond", 2200m, "Available" },
                    { 53, 2.8m, "VS2", "White", "Princess", null, "Diamond", 2300m, "Available" },
                    { 54, 3.5m, "VS1", "White", "Emerald", null, "Diamond", 2400m, "Available" },
                    { 55, 4m, "VVS2", "White", "Marquise", null, "Diamond", 2500m, "Available" },
                    { 56, 3.1m, "VS1", "White", "Cushion", null, "Diamond", 2600m, "Available" },
                    { 57, 2.9m, "VS2", "White", "Heart", null, "Diamond", 2700m, "Available" },
                    { 58, 3.3m, "VS1", "White", "Oval", null, "Diamond", 2800m, "Available" },
                    { 59, 3.7m, "VVS1", "White", "Round", null, "Diamond", 2900m, "Available" },
                    { 60, 4.2m, "VS2", "White", "Princess", null, "Diamond", 3000m, "Available" },
                    { 61, 3.4m, "VS1", "White", "Emerald", null, "Diamond", 3100m, "Available" },
                    { 62, 3.6m, "VVS2", "White", "Marquise", null, "Diamond", 3200m, "Available" },
                    { 63, 3.8m, "VS1", "White", "Cushion", null, "Diamond", 3300m, "Available" },
                    { 64, 4.1m, "VS2", "White", "Heart", null, "Diamond", 3400m, "Available" },
                    { 65, 4.3m, "VS1", "White", "Oval", null, "Diamond", 3500m, "Available" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Color", "Price", "Purity", "Type" },
                values: new object[,]
                {
                    { 1, "White", 100m, 58.5m, "Gold" },
                    { 2, "Rose", 50m, 41.7m, "Gold" },
                    { 3, "Yellow", 80m, 75.0m, "Gold" },
                    { 4, "Green", 90m, 58.5m, "Gold" },
                    { 5, "Silver", 60m, 92.5m, "Silver" },
                    { 6, "Silver", 70m, 99.9m, "Silver" },
                    { 7, "White", 120m, 95.0m, "Platinum" },
                    { 8, "Red", 30m, 99.9m, "Copper" },
                    { 9, "Golden", 40m, 60.0m, "Brass" },
                    { 10, "Grey", 50m, 99.9m, "Titanium" },
                    { 11, "Silver", 45m, 30.0m, "Steel" },
                    { 12, "Grey", 20m, 69.0m, "Zinc" },
                    { 13, "White", 150m, 42.0m, "Rhodium" },
                    { 14, "White", 100m, 0.95m, "Palladium" },
                    { 15, "Grey", 180m, 0.01m, "Iridium" }
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
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

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
                name: "IX_Gemstones_MaterialSetId",
                table: "Gemstones",
                column: "MaterialSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_BaseDesignId",
                table: "Jewelries",
                column: "BaseDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_CustomerId",
                table: "Jewelries",
                column: "CustomerId");

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
                name: "IX_MaterialSets_JewelryId",
                table: "MaterialSets",
                column: "JewelryId",
                unique: true);

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Gemstones");

            migrationBuilder.DropTable(
                name: "JewelryDesigns");

            migrationBuilder.DropTable(
                name: "MaterialSetsMaterials");

            migrationBuilder.DropTable(
                name: "ProductionRequestDetails");

            migrationBuilder.DropTable(
                name: "QuotationRequests");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "WarrantyCards");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "MaterialSets");

            migrationBuilder.DropTable(
                name: "Jewelries");

            migrationBuilder.DropTable(
                name: "BaseDesigns");

            migrationBuilder.DropTable(
                name: "ProductionRequests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
