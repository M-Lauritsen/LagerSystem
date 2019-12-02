using Microsoft.EntityFrameworkCore.Migrations;

namespace LagerSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RackPosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageName = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PalletItems",
                columns: table => new
                {
                    PalletId = table.Column<int>(nullable: false),
                    StockItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletItems", x => new { x.StockItemId, x.PalletId });
                    table.ForeignKey(
                        name: "FK_PalletItems_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalletItems_StockItems_StockItemId",
                        column: x => x.StockItemId,
                        principalTable: "StockItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racks_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Available = table.Column<bool>(nullable: false),
                    PalletId = table.Column<int>(nullable: true),
                    RackId = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    RackPosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Positions_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PalletItems_PalletId",
                table: "PalletItems",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PalletId",
                table: "Positions",
                column: "PalletId",
                unique: true,
                filter: "[PalletId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RackId",
                table: "Positions",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_StorageId",
                table: "Racks",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalletItems");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
