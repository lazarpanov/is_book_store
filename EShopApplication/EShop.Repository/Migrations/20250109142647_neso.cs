using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    /// <inheritdoc />
    public partial class neso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "PartnerBooks");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "PartnerBooks");

            migrationBuilder.AlterColumn<string>(
                name: "publisher",
                table: "PartnerBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "publisher",
                table: "PartnerBooks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "PartnerBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId",
                table: "PartnerBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
