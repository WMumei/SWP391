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
                value: new DateTime(2024, 7, 8, 11, 20, 46, 454, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentIntentId", "SessionId" },
                values: new object[] { new DateTime(2024, 7, 8, 11, 20, 46, 454, DateTimeKind.Local).AddTicks(3317), null, null });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentIntentId", "SessionId" },
                values: new object[] { new DateTime(2024, 7, 8, 11, 20, 46, 454, DateTimeKind.Local).AddTicks(3345), null, null });
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
                value: new DateTime(2024, 7, 7, 13, 45, 36, 179, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 7, 13, 45, 36, 179, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 7, 13, 45, 36, 179, DateTimeKind.Local).AddTicks(2909));
        }
    }
}
