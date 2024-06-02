using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDeliveryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesStaffCustomers");

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesStaffId = table.Column<int>(type: "int", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    WarrantyCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => new { x.CustomerId, x.SalesStaffId, x.JewelryId, x.WarrantyCardId });
                    table.ForeignKey(
                        name: "FK_Deliveries_Jewelries_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_WarrantyCards_WarrantyCardId",
                        column: x => x.WarrantyCardId,
                        principalTable: "WarrantyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

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

            migrationBuilder.CreateIndex(
                name: "IX_SalesStaffCustomers_SalesStaffId",
                table: "SalesStaffCustomers",
                column: "SalesStaffId");
        }
    }
}
