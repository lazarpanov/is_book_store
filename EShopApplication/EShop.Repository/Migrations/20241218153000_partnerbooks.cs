using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    /// <inheritdoc />
    public partial class partnerbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PartnerBookId",
                table: "ProductInOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartnerBookId",
                table: "BookInShoppingCarts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartnerBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalPages = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<double>(type: "float", nullable: true),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerBooks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInOrders_PartnerBookId",
                table: "ProductInOrders",
                column: "PartnerBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInShoppingCarts_PartnerBookId",
                table: "BookInShoppingCarts",
                column: "PartnerBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCarts_PartnerBooks_PartnerBookId",
                table: "BookInShoppingCarts",
                column: "PartnerBookId",
                principalTable: "PartnerBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrders_PartnerBooks_PartnerBookId",
                table: "ProductInOrders",
                column: "PartnerBookId",
                principalTable: "PartnerBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCarts_PartnerBooks_PartnerBookId",
                table: "BookInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrders_PartnerBooks_PartnerBookId",
                table: "ProductInOrders");

            migrationBuilder.DropTable(
                name: "PartnerBooks");

            migrationBuilder.DropIndex(
                name: "IX_ProductInOrders_PartnerBookId",
                table: "ProductInOrders");

            migrationBuilder.DropIndex(
                name: "IX_BookInShoppingCarts_PartnerBookId",
                table: "BookInShoppingCarts");

            migrationBuilder.DropColumn(
                name: "PartnerBookId",
                table: "ProductInOrders");

            migrationBuilder.DropColumn(
                name: "PartnerBookId",
                table: "BookInShoppingCarts");
        }
    }
}
