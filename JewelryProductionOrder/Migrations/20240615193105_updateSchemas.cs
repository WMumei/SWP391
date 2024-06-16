using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class updateSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationRequests_ProductionRequests_ProductionRequestId",
                table: "QuotationRequests");

            migrationBuilder.DropIndex(
                name: "IX_QuotationRequests_ProductionRequestId",
                table: "QuotationRequests");

            migrationBuilder.RenameColumn(
                name: "ProductionRequestId",
                table: "QuotationRequests",
                newName: "JewelryId");

            migrationBuilder.AddColumn<int>(
                name: "QuotationRequestId",
                table: "ProductionRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gemstone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemstone", x => x.Id);
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
                        name: "FK_GemstoneMaterialSet_Gemstone_GemstonesId",
                        column: x => x.GemstonesId,
                        principalTable: "Gemstone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GemstoneMaterialSet_MaterialSets_MaterialSetsId",
                        column: x => x.MaterialSetsId,
                        principalTable: "MaterialSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "QuotationRequestId" },
                values: new object[] { new DateTime(2024, 6, 16, 2, 31, 4, 395, DateTimeKind.Local).AddTicks(7737), null });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "QuotationRequestId" },
                values: new object[] { new DateTime(2024, 6, 16, 2, 31, 4, 395, DateTimeKind.Local).AddTicks(7755), null });

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequests_QuotationRequestId",
                table: "ProductionRequests",
                column: "QuotationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_GemstoneMaterialSet_MaterialSetsId",
                table: "GemstoneMaterialSet",
                column: "MaterialSetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionRequests_QuotationRequests_QuotationRequestId",
                table: "ProductionRequests",
                column: "QuotationRequestId",
                principalTable: "QuotationRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationRequests_Jewelries_JewelryId",
                table: "QuotationRequests",
                column: "JewelryId",
                principalTable: "Jewelries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionRequests_QuotationRequests_QuotationRequestId",
                table: "ProductionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationRequests_Jewelries_JewelryId",
                table: "QuotationRequests");

            migrationBuilder.DropTable(
                name: "GemstoneMaterialSet");

            migrationBuilder.DropTable(
                name: "Gemstone");

            migrationBuilder.DropIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProductionRequests_QuotationRequestId",
                table: "ProductionRequests");

            migrationBuilder.DropColumn(
                name: "QuotationRequestId",
                table: "ProductionRequests");

            migrationBuilder.RenameColumn(
                name: "JewelryId",
                table: "QuotationRequests",
                newName: "ProductionRequestId");

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 2, 11, 46, 410, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 2, 11, 46, 410, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_ProductionRequestId",
                table: "QuotationRequests",
                column: "ProductionRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationRequests_ProductionRequests_ProductionRequestId",
                table: "QuotationRequests",
                column: "ProductionRequestId",
                principalTable: "ProductionRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
