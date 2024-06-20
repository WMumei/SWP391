using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 20, 12, 46, 10, 878, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 20, 12, 46, 10, 878, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 20, 12, 46, 10, 878, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests",
                column: "JewelryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 23, 19, 46, 236, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 23, 19, 46, 236, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 23, 19, 46, 236, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRequests_JewelryId",
                table: "QuotationRequests",
                column: "JewelryId",
                unique: true);
        }
    }
}
