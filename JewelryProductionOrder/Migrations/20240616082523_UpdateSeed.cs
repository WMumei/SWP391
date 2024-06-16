using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GemstoneMaterialSet_Gemstone_GemstonesId",
                table: "GemstoneMaterialSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gemstone",
                table: "Gemstone");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Gemstone",
                newName: "Gemstones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gemstones",
                table: "Gemstones",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Jewelries",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "Image", "MaterialSetId", "Name", "ProductionRequestId", "ProductionStaffId", "SalesStaffId", "Status" },
                values: new object[] { 1, new DateTime(2024, 6, 16, 15, 25, 22, 642, DateTimeKind.Local).AddTicks(573), null, "9999Gold for the material and 1 carat diamond for everyday where", null, null, "Diamond Necklace", 1, null, null, "" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_GemstoneMaterialSet_Gemstones_GemstonesId",
                table: "GemstoneMaterialSet",
                column: "GemstonesId",
                principalTable: "Gemstones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GemstoneMaterialSet_Gemstones_GemstonesId",
                table: "GemstoneMaterialSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gemstones",
                table: "Gemstones");

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Gemstones",
                newName: "Gemstone");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gemstone",
                table: "Gemstone",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Metal");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Metal");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Gemstone");

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 2, 31, 4, 395, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 2, 31, 4, 395, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.AddForeignKey(
                name: "FK_GemstoneMaterialSet_Gemstone_GemstonesId",
                table: "GemstoneMaterialSet",
                column: "GemstonesId",
                principalTable: "Gemstone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
