using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipJW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelries_WarrantyCards_WarrantyCardId",
                table: "Jewelries");

            migrationBuilder.DropIndex(
                name: "IX_Jewelries_WarrantyCardId",
                table: "Jewelries");

            migrationBuilder.DropColumn(
                name: "WarrantyCardId",
                table: "Jewelries");

            migrationBuilder.AddColumn<int>(
                name: "JewelryId",
                table: "WarrantyCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "MaterialSetsMaterials",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyCards_JewelryId",
                table: "WarrantyCards",
                column: "JewelryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyCards_Jewelries_JewelryId",
                table: "WarrantyCards",
                column: "JewelryId",
                principalTable: "Jewelries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyCards_Jewelries_JewelryId",
                table: "WarrantyCards");

            migrationBuilder.DropIndex(
                name: "IX_WarrantyCards_JewelryId",
                table: "WarrantyCards");

            migrationBuilder.DropColumn(
                name: "JewelryId",
                table: "WarrantyCards");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "MaterialSetsMaterials");

            migrationBuilder.AddColumn<int>(
                name: "WarrantyCardId",
                table: "Jewelries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_WarrantyCardId",
                table: "Jewelries",
                column: "WarrantyCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelries_WarrantyCards_WarrantyCardId",
                table: "Jewelries",
                column: "WarrantyCardId",
                principalTable: "WarrantyCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
