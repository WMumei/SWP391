using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 4, 14, 44, 47, 698, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 4, 14, 44, 47, 698, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 4, 14, 44, 47, 698, DateTimeKind.Local).AddTicks(6483));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 4, 14, 39, 58, 389, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 4, 14, 39, 58, 389, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 4, 14, 39, 58, 389, DateTimeKind.Local).AddTicks(9184));
        }
    }
}
