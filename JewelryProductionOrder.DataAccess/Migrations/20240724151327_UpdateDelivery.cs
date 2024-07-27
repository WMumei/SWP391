using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveredAt",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JewelryId1",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_JewelryId1",
                table: "Deliveries",
                column: "JewelryId1",
                unique: true,
                filter: "[JewelryId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Jewelries_JewelryId1",
                table: "Deliveries",
                column: "JewelryId1",
                principalTable: "Jewelries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Jewelries_JewelryId1",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_JewelryId1",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "JewelryId1",
                table: "Deliveries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveredAt",
                table: "Deliveries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
