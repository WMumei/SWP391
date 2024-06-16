using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialSets_MaterialSetId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MaterialSetId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialSetId",
                table: "Materials");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 16, 43, 8, 911, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 16, 43, 8, 911, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 16, 43, 8, 911, DateTimeKind.Local).AddTicks(3309));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialSetId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaterialSetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaterialSetId",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialSetId",
                table: "Materials",
                column: "MaterialSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialSets_MaterialSetId",
                table: "Materials",
                column: "MaterialSetId",
                principalTable: "MaterialSets",
                principalColumn: "Id");
        }
    }
}
