using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class changeSeedPR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ProductionRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "ProductionRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ProductionRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 15, 34, 35, 737, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ContactName", "CreatedAt", "PhoneNumber" },
                values: new object[] { "23 Phu Ky Quan 12", " Le Hoang", new DateTime(2024, 7, 6, 15, 34, 35, 737, DateTimeKind.Local).AddTicks(6885), "0123456769" });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "ContactName", "CreatedAt", "PhoneNumber" },
                values: new object[] { "23 Phu Ky Quan 12", " Le Hoang", new DateTime(2024, 7, 6, 15, 34, 35, 737, DateTimeKind.Local).AddTicks(6943), "0123456769" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "ProductionRequests");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ProductionRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ProductionRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 14, 47, 51, 619, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt" },
                values: new object[] { null, new DateTime(2024, 7, 6, 14, 47, 51, 619, DateTimeKind.Local).AddTicks(2317) });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedAt" },
                values: new object[] { null, new DateTime(2024, 7, 6, 14, 47, 51, 619, DateTimeKind.Local).AddTicks(2329) });
        }
    }
}
