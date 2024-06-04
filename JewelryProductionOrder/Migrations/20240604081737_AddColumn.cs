using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiredDate",
                table: "WarrantyCards",
                newName: "ExpiredAt");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "WarrantyCards",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiredAt",
                table: "WarrantyCards",
                newName: "ExpiredDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "WarrantyCards",
                newName: "CreatedDate");
        }
    }
}
