using Microsoft.EntityFrameworkCore.Migrations;

namespace LagerSystem.Migrations
{
    public partial class init267 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RackPosition",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RackPosition",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
