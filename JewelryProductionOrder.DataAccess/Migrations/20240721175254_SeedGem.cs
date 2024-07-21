using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedGem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Weight",
                value: 3m);

            migrationBuilder.InsertData(
                table: "Gemstones",
                columns: new[] { "Id", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 4, "2 carat Diamond", 1800m, 2m },
                    { 5, "1 carat Diamond", 1000m, 1m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Weight",
                value: 2m);
        }
    }
}
