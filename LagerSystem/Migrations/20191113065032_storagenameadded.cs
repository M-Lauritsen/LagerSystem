using Microsoft.EntityFrameworkCore.Migrations;

namespace LagerSystem.Migrations
{
    public partial class storagenameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageName",
                table: "Storages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageName",
                table: "Storages");
        }
    }
}
