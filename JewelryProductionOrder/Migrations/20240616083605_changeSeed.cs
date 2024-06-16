using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class changeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Gemstones",
                columns: new[] { "Id", "Name", "Price", "Weight" },
                values: new object[] { 1, "Diamond", 200000m, 0m });

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8107));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 25, 22, 642, DateTimeKind.Local).AddTicks(573));

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "MaterialSetId", "Name", "Price" },
                values: new object[] { 3, null, "Diamond", 200000m });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 25, 22, 642, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 25, 22, 642, DateTimeKind.Local).AddTicks(396));
        }
    }
}
