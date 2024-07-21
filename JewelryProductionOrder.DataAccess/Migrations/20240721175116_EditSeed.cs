using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductionRequests",
                columns: new[] { "Id", "Address", "ContactName", "CreatedAt", "CustomerId", "DesignStaffId", "Email", "Note", "PaymentIntentId", "PhoneNumber", "ProductionStaffId", "Quantity", "SalesStaffId", "SessionId", "Status" },
                values: new object[,]
                {
                    { 1, "23 Phu Ky Quan 12", " Le Hoang", new DateTime(2024, 7, 22, 0, 47, 46, 780, DateTimeKind.Local).AddTicks(3388), null, null, "test@gmail.com", null, null, "0123456769", null, null, null, null, null },
                    { 2, "23 Phu Ky Quan 12", " Le Hoang", new DateTime(2024, 7, 22, 0, 47, 46, 780, DateTimeKind.Local).AddTicks(3401), null, null, "test@gmail.com", null, null, "0123456769", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Jewelries",
                columns: new[] { "Id", "BaseDesignId", "CreatedAt", "CustomerId", "Description", "Image", "MaterialSetId", "Name", "ProductionRequestId", "ProductionStaffId", "SalesStaffId", "Status" },
                values: new object[] { 1, 1, new DateTime(2024, 7, 22, 0, 47, 46, 780, DateTimeKind.Local).AddTicks(3525), null, "9999 Gold for the material and 1 carat diamond for everyday wear", null, null, "Diamond Ring", 1, null, null, "" });
        }
    }
}
