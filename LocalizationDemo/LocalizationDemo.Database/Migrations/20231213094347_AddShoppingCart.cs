using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizationDemo.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartProducts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProducts", x => new { x.ShoppingCartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_ProductId",
                table: "ShoppingCartProducts",
                column: "ProductId");

            migrationBuilder.Sql(@"
                INSERT INTO [ShoppingCarts]([Id])
                VALUES
                ('9e18d87b-1e9b-4242-b369-e06cbc1c45a6'),
                ('580d1e60-8916-44d8-bb92-5e2426e93306'),
                ('65b6cb93-c59f-4f67-87b8-496e6452f8f7')
            ");

            migrationBuilder.Sql(@"
                INSERT INTO [ShoppingCartProducts]([ShoppingCartId], [ProductId])
                VALUES
                ('9e18d87b-1e9b-4242-b369-e06cbc1c45a6', 1),
                ('9e18d87b-1e9b-4242-b369-e06cbc1c45a6', 6),
                ('580d1e60-8916-44d8-bb92-5e2426e93306', 5),
                ('580d1e60-8916-44d8-bb92-5e2426e93306', 4),
                ('580d1e60-8916-44d8-bb92-5e2426e93306', 3)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartProducts");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
