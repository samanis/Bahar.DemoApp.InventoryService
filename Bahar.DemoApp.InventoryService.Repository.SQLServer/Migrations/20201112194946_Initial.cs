using Microsoft.EntityFrameworkCore.Migrations;

namespace Bahar.DemoApp.InventoryService.Repository.SQLServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CurrentAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventoryItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    UOM = table.Column<int>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    Inventoryid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventoryItem_Inventory_Inventoryid",
                        column: x => x.Inventoryid,
                        principalTable: "Inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventoryItem_Inventoryid",
                table: "inventoryItem",
                column: "Inventoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventoryItem");

            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
