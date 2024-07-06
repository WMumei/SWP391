using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntityBaseDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelries_BaseDesign_BaseDesignId",
                table: "Jewelries");

            migrationBuilder.DropForeignKey(
                name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId",
                table: "JewelryDesigns");

            migrationBuilder.DropForeignKey(
                name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId1",
                table: "JewelryDesigns");

            migrationBuilder.DropIndex(
                name: "IX_JewelryDesigns_ProductionRequestId",
                table: "JewelryDesigns");

            migrationBuilder.DropIndex(
                name: "IX_JewelryDesigns_ProductionRequestId1",
                table: "JewelryDesigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseDesign",
                table: "BaseDesign");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductionRequests");

            migrationBuilder.DropColumn(
                name: "ProductionRequestId",
                table: "JewelryDesigns");

            migrationBuilder.DropColumn(
                name: "ProductionRequestId1",
                table: "JewelryDesigns");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "JewelryDesigns");

            migrationBuilder.RenameTable(
                name: "BaseDesign",
                newName: "BaseDesigns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseDesigns",
                table: "BaseDesigns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductionRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionRequestId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BaseDesignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRequestDetails_BaseDesigns_BaseDesignId",
                        column: x => x.BaseDesignId,
                        principalTable: "BaseDesigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionRequestDetails_ProductionRequests_ProductionRequestId",
                        column: x => x.ProductionRequestId,
                        principalTable: "ProductionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseDesignId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_BaseDesigns_BaseDesignId",
                        column: x => x.BaseDesignId,
                        principalTable: "BaseDesigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequestDetails_BaseDesignId",
                table: "ProductionRequestDetails",
                column: "BaseDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRequestDetails_ProductionRequestId",
                table: "ProductionRequestDetails",
                column: "ProductionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_BaseDesignId",
                table: "ShoppingCarts",
                column: "BaseDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelries_BaseDesigns_BaseDesignId",
                table: "Jewelries",
                column: "BaseDesignId",
                principalTable: "BaseDesigns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelries_BaseDesigns_BaseDesignId",
                table: "Jewelries");

            migrationBuilder.DropTable(
                name: "ProductionRequestDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseDesigns",
                table: "BaseDesigns");

            migrationBuilder.RenameTable(
                name: "BaseDesigns",
                newName: "BaseDesign");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRequestId",
                table: "JewelryDesigns",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseDesign",
                table: "BaseDesign",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 28, 13, 43, 58, 65, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Quantity" },
                values: new object[] { new DateTime(2024, 6, 28, 13, 43, 58, 65, DateTimeKind.Local).AddTicks(7677), 1 });

            migrationBuilder.UpdateData(
                table: "ProductionRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Quantity" },
                values: new object[] { new DateTime(2024, 6, 28, 13, 43, 58, 65, DateTimeKind.Local).AddTicks(7714), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_ProductionRequestId",
                table: "JewelryDesigns",
                column: "ProductionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryDesigns_ProductionRequestId1",
                table: "JewelryDesigns",
                column: "ProductionRequestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelries_BaseDesign_BaseDesignId",
                table: "Jewelries",
                column: "BaseDesignId",
                principalTable: "BaseDesign",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId",
                table: "JewelryDesigns",
                column: "ProductionRequestId",
                principalTable: "ProductionRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryDesigns_ProductionRequests_ProductionRequestId1",
                table: "JewelryDesigns",
                column: "ProductionRequestId1",
                principalTable: "ProductionRequests",
                principalColumn: "Id");
        }
    }
}
