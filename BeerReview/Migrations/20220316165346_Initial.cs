using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerDrinker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                });

            migrationBuilder.CreateTable(
                name: "Drinkers",
                columns: table => new
                {
                    DrinkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinkers", x => x.DrinkerId);
                });

            migrationBuilder.CreateTable(
                name: "BeerDrinker",
                columns: table => new
                {
                    BeerDrinkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    DrinkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerDrinker", x => x.BeerDrinkerId);
                    table.ForeignKey(
                        name: "FK_BeerDrinker_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerDrinker_Drinkers_DrinkerId",
                        column: x => x.DrinkerId,
                        principalTable: "Drinkers",
                        principalColumn: "DrinkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerDrinker_BeerId",
                table: "BeerDrinker",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_BeerDrinker_DrinkerId",
                table: "BeerDrinker",
                column: "DrinkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerDrinker");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Drinkers");
        }
    }
}
