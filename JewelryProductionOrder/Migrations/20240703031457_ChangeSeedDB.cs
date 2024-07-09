using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "\\Images\\Pendant.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 14, 56, 793, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 14, 56, 793, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 14, 56, 793, DateTimeKind.Local).AddTicks(3516));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "\\Images\\Pendant.webp");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 13, 41, 698, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 13, 41, 698, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 13, 41, 698, DateTimeKind.Local).AddTicks(4457));
        }
    }
}
