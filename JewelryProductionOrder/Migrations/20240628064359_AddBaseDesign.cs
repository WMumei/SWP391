using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionRequestId1",
                table: "JewelryDesigns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "JewelryDesigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BaseDesignId",
                table: "Jewelries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseDesign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDesign", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BaseDesign",
                columns: new[] { "Id", "Image", "Name", "Status" },
                values: new object[] { 1, "\\Images\\Ring.webp", null, null });

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BaseDesignId", "CreatedAt", "Name" },
                values: new object[] { 1, new DateTime(2024, 6, 28, 13, 43, 58, 65, DateTimeKind.Local).AddTicks(7833), "Diamond Ring" });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 28, 13, 43, 58, 65, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 28, 13, 43, 58, 65, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_ProductionRequestId1",
                table: "JewelryDesigns",
                column: "ProductionRequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_BaseDesignId",
                table: "Jewelries",
                column: "BaseDesignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelries_BaseDesign_BaseDesignId",
                table: "Jewelries",
                column: "BaseDesignId",
                principalTable: "BaseDesign",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId1",
                table: "JewelryDesigns",
                column: "ProductionRequestId1",
                principalTable: "ProductionRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelries_BaseDesign_BaseDesignId",
                table: "Jewelries");

            migrationBuilder.DropForeignKey(
                name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId1",
                table: "JewelryDesigns");

            migrationBuilder.DropTable(
                name: "BaseDesign");

            migrationBuilder.DropIndex(
                name: "IX_JewelryDesigns_ProductionRequestId1",
                table: "JewelryDesigns");

            migrationBuilder.DropIndex(
                name: "IX_Jewelries_BaseDesignId",
                table: "Jewelries");

            migrationBuilder.DropColumn(
                name: "ProductionRequestId1",
                table: "JewelryDesigns");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "JewelryDesigns");

            migrationBuilder.DropColumn(
                name: "BaseDesignId",
                table: "Jewelries");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 46, 10, 878, DateTimeKind.Local).AddTicks(5755), "Diamond Necklace" });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 20, 12, 46, 10, 878, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 20, 12, 46, 10, 878, DateTimeKind.Local).AddTicks(5528));
        }
    }
}
