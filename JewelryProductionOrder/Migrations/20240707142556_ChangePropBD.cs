using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 7, 21, 25, 55, 428, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 7, 21, 25, 55, 428, DateTimeKind.Local).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 7, 21, 25, 55, 428, DateTimeKind.Local).AddTicks(6882));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
