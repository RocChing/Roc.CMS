using Microsoft.EntityFrameworkCore.Migrations;

namespace Roc.CMS.Migrations
{
    public partial class Category_Add_SortId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "AppCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortId",
                table: "AppCategory");
        }
    }
}
