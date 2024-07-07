using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class seedBaseDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bezel Solitarie Engagement Ring");

            migrationBuilder.InsertData(
                table: "BaseDesigns",
                columns: new[] { "Id", "Image", "Name", "Status" },
                values: new object[,]
                {
                    { 2, "\\Images\\Pendant.webp", "Diamond Reiki Symbol Pendant", null },
                    { 3, "\\Images\\Necklace.webp", "Smile Necklace", null },
                    { 4, "\\Images\\Band.webp", "Swirl Diamond Wedding Band", null }
                });

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 7, 11, 413, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 7, 11, 413, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 10, 7, 11, 413, DateTimeKind.Local).AddTicks(8799));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 9, 44, 53, 855, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 9, 44, 53, 855, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 3, 9, 44, 53, 855, DateTimeKind.Local).AddTicks(7977));
        }
    }
}
