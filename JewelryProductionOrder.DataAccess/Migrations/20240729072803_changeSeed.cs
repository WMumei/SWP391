using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Sleek and contemporary, this 4.50ct round brilliant cut diamond pops in a custom bezel set solitaire ring. This setting was custom made to allow for the large center stone to sit as close to the finger as possible.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Reiki symbols are used in alternative healing. After a major life upheaval, our client found meaning in the At Mata symbol, crafted using white gold and a trillion cut diamond, which is said to remove emotional blocks that prevent you from seeing clearly.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "We created a custom milgrain smile style necklace for a client's sentimental single cut diamonds. This same design can be modified for stones of any size, color, or shape!\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.");

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Swirls of platinum arc and curl around sparkling round brilliant cut diamonds to create this unique wedding band.\r\n\r\nThis piece can be replicated or modified for you. The stones can be similar or different types, sizes, or shapes, or even your stones. Therefore, please contact us for a quote.");

            migrationBuilder.InsertData(
                table: "Gemstones",
                columns: new[] { "Id", "Carat", "Clarity", "Color", "Cut", "MaterialSetId", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 51, 2.5m, "VS1", "White", "Round", null, "Diamond", 2100m, "Available" },
                    { 52, 3.2m, "VVS1", "White", "Oval", null, "Diamond", 2200m, "Available" },
                    { 53, 2.8m, "VS2", "White", "Princess", null, "Diamond", 2300m, "Available" },
                    { 54, 3.5m, "VS1", "White", "Emerald", null, "Diamond", 2400m, "Available" },
                    { 55, 4m, "VVS2", "White", "Marquise", null, "Diamond", 2500m, "Available" },
                    { 56, 3.1m, "VS1", "White", "Cushion", null, "Diamond", 2600m, "Available" },
                    { 57, 2.9m, "VS2", "White", "Heart", null, "Diamond", 2700m, "Available" },
                    { 58, 3.3m, "VS1", "White", "Oval", null, "Diamond", 2800m, "Available" },
                    { 59, 3.7m, "VVS1", "White", "Round", null, "Diamond", 2900m, "Available" },
                    { 60, 4.2m, "VS2", "White", "Princess", null, "Diamond", 3000m, "Available" },
                    { 61, 3.4m, "VS1", "White", "Emerald", null, "Diamond", 3100m, "Available" },
                    { 62, 3.6m, "VVS2", "White", "Marquise", null, "Diamond", 3200m, "Available" },
                    { 63, 3.8m, "VS1", "White", "Cushion", null, "Diamond", 3300m, "Available" },
                    { 64, 4.1m, "VS2", "White", "Heart", null, "Diamond", 3400m, "Available" },
                    { 65, 4.3m, "VS1", "White", "Oval", null, "Diamond", 3500m, "Available" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Gemstones",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);
        }
    }
}
