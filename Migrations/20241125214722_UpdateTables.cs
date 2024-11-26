using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ClothesItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ClothesTypeId",
                table: "ClothesItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ClothesItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ClothesTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TotalSpent = table.Column<decimal>(type: "numeric", nullable: false),
                    HasDiscount = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

        migrationBuilder.CreateTable(
            name: "JoiningOrderClothesItems",
            columns: table => new
            {
                OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                ClothesItemId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_JoiningOrderClothesItems", x => new { x.OrderId, x.ClothesItemId });
                table.ForeignKey(
                    name: "FK_JoiningOrderClothesItems_ClothesItems_ClothesItemId",
                    column: x => x.ClothesItemId,
                    principalTable: "ClothesItems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_JoiningOrderClothesItems_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

            // Insert a default ClothesType
            migrationBuilder.Sql("INSERT INTO \"ClothesTypes\" (\"Id\", \"Type\") VALUES ('11111111-1111-1111-1111-111111111111', 'Default Type');");

            // Assign all existing ClothesItems to the default ClothesType
            migrationBuilder.Sql("UPDATE \"ClothesItems\" SET \"ClothesTypeId\" = '11111111-1111-1111-1111-111111111111';");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesItems_ClothesTypeId",
                table: "ClothesItems",
                column: "ClothesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JoiningOrderClothesItems_ClothesItemId",
                table: "JoiningOrderClothesItems",
                column: "ClothesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesItems_ClothesTypes_ClothesTypeId",
                table: "ClothesItems",
                column: "ClothesTypeId",
                principalTable: "ClothesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            }
    }
}
