using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestOfferings.Data.Migrations
{
    public partial class add_ctgModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Markets_MarketId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MarketId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Markets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Markets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Markets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Markets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Markets_CategoryId",
                table: "Markets",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_Categories_CategoryId",
                table: "Markets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markets_Categories_CategoryId",
                table: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_Markets_CategoryId",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Markets");

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MarketId",
                table: "Categories",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Markets_MarketId",
                table: "Categories",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
