using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class schemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSetsMaterials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: false)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DesignStaffId = table.Column<int>(type: "int", nullable: false),
                    ProductionStaffId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_Users_DesignStaffId",
                        column: x => x.DesignStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_Users_ProductionStaffId",
                        column: x => x.ProductionStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRequests_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesStaffCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesStaffCustomers", x => new { x.CustomerId, x.SalesStaffId });
                    table.ForeignKey(
                        name: "FK_SalesStaffCustomers_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesStaffCustomers_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantyCards_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarrantyCards_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jewelries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: false),
                    WarrantyCardId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false),
                    ProductionStaffId = table.Column<int>(type: "int", nullable: false),
                    ProductionRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewelries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jewelries_MaterialSets_MaterialSetId",
                        column: x => x.MaterialSetId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jewelries_ProductionRequests_ProductionRequestId",
                        column: x => x.ProductionRequestId,
                        principalTable: "ProductionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jewelries_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jewelries_Users_ProductionStaffId",
                        column: x => x.ProductionStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jewelries_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jewelries_WarrantyCards_WarrantyCardId",
                        column: x => x.WarrantyCardId,
                        principalTable: "WarrantyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JewelryDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DesignStaffId = table.Column<int>(type: "int", nullable: false),
                    ProductionStaffId = table.Column<int>(type: "int", nullable: false),
                    ProductionRequestId = table.Column<int>(type: "int", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryDesigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId",
                        column: x => x.ProductionRequestId,
                        principalTable: "ProductionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_Users_DesignStaffId",
                        column: x => x.DesignStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelryDesigns_Users_ProductionStaffId",
                        column: x => x.ProductionStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaborPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    MaterialSetId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_MaterialSets_MaterialSetId",
                        column: x => x.MaterialSetId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationRequests_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Jewelries_WarrantyCardId",
                table: "Jewelries",
                column: "WarrantyCardId");

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
                name: "IX_JewelryDesigns_ProductionRequestId",
                table: "JewelryDesigns",
                column: "ProductionRequestId");

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
                name: "IX_SalesStaffCustomers_SalesStaffId",
                table: "SalesStaffCustomers",
                column: "SalesStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyCards_CustomerId",
                table: "WarrantyCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyCards_SalesStaffId",
                table: "WarrantyCards",
                column: "SalesStaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JewelryDesigns");

            migrationBuilder.DropTable(
                name: "MaterialSetsMaterials");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "QuotationRequests");

            migrationBuilder.DropTable(
                name: "SalesStaffCustomers");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Jewelries");

            migrationBuilder.DropTable(
                name: "MaterialSets");

            migrationBuilder.DropTable(
                name: "ProductionRequests");

            migrationBuilder.DropTable(
                name: "WarrantyCards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
