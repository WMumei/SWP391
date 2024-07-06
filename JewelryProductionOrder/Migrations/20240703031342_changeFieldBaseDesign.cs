using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class changeFieldBaseDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "BaseDesigns",
                newName: "Type");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Company");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Company");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Company");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Company");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "BaseDesigns",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 7, 11, 413, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 7, 11, 413, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 7, 11, 413, DateTimeKind.Local).AddTicks(8799));
        }
    }
}
