using Microsoft.EntityFrameworkCore.Migrations;

namespace LagerSystem.Migrations
{
    public partial class palletsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Storages");

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Storages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Pallets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_StorageId",
                table: "Pallets",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Storages_StorageId",
                table: "Pallets",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Storages_StorageId",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_StorageId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Pallets");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Storages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Storages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
