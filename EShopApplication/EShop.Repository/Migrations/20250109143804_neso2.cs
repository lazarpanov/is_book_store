using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    /// <inheritdoc />
    public partial class neso2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCarts_PartnerBooks_PartnerBookId",
                table: "BookInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrders_PartnerBooks_PartnerBookId",
                table: "ProductInOrders");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
