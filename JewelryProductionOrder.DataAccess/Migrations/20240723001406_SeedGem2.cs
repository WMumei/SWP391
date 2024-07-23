using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedGem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Carat",
                table: "Gemstones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Clarity",
                table: "Gemstones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Gemstones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cut",
                table: "Gemstones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Gemstones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Carat", "Clarity", "Color", "Cut", "Status" },
                values: new object[] { 3m, "VS1", "White", "Round", "Available" });

            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Carat", "Clarity", "Color", "Cut", "Status" },
                values: new object[] { 1.5m, "VVS1", "Red", "Oval", "Available" });

            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Carat", "Clarity", "Color", "Cut", "Status" },
                values: new object[] { 1.8m, "VS2", "Blue", "Princess", "Available" });

            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Carat", "Clarity", "Color", "Cut", "Status" },
                values: new object[] { 2m, "VS2", "White", "Emerald", "Available" });

            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Carat", "Clarity", "Color", "Cut", "Status" },
                values: new object[] { 1m, "VVS2", "White", "Marquise", "Available" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carat",
                table: "Gemstones");

            migrationBuilder.DropColumn(
                name: "Clarity",
                table: "Gemstones");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Gemstones");

            migrationBuilder.DropColumn(
                name: "Cut",
                table: "Gemstones");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Gemstones");
        }
    }
}
