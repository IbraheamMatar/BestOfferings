using Microsoft.EntityFrameworkCore.Migrations;

namespace BestOfferings.Data.Migrations
{
    public partial class CtgMrkt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryName",
                table: "Markets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Markets");
        }
    }
}
