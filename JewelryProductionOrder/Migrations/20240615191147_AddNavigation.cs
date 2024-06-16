using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelries_MaterialSets_MaterialSetId",
                table: "Jewelries");

            migrationBuilder.AddColumn<int>(
                name: "MaterialSetId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Jewelries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SalesStaffId",
                table: "Jewelries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionStaffId",
                table: "Jewelries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialSetId",
                table: "Jewelries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Jewelries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Jewelries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "MaterialSetId", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, null, "Gold", 1000m, "Metal" },
                    { 2, null, "Silver", 200m, "Metal" },
                    { 3, null, "Diamond", 200000m, "Gemstone" }
                });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 2, 11, 46, 410, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 2, 11, 46, 410, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialSetId",
                table: "Materials",
                column: "MaterialSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelries_MaterialSets_MaterialSetId",
                table: "Jewelries",
                column: "MaterialSetId",
                principalTable: "MaterialSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialSets_MaterialSetId",
                table: "Materials",
                column: "MaterialSetId",
                principalTable: "MaterialSets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelries_MaterialSets_MaterialSetId",
                table: "Jewelries");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialSets_MaterialSetId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MaterialSetId",
                table: "Materials");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "MaterialSetId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Materials");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Jewelries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesStaffId",
                table: "Jewelries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionStaffId",
                table: "Jewelries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialSetId",
                table: "Jewelries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Jewelries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Jewelries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 17, 19, 30, 120, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 17, 19, 30, 120, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelries_MaterialSets_MaterialSetId",
                table: "Jewelries",
                column: "MaterialSetId",
                principalTable: "MaterialSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
