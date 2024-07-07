using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class addSessionIdToProductionRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "ProductionRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "ProductionRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 5, 16, 3, 25, 169, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentIntentId", "SessionId" },
                values: new object[] { new DateTime(2024, 7, 5, 16, 3, 25, 169, DateTimeKind.Local).AddTicks(1723), null, null });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentIntentId", "SessionId" },
                values: new object[] { new DateTime(2024, 7, 5, 16, 3, 25, 169, DateTimeKind.Local).AddTicks(1761), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "ProductionRequests");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "ProductionRequests");

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
        }
    }
}
