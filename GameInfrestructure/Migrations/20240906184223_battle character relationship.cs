using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInfrestructure.Migrations
{
    public partial class battlecharacterrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Batttles",
                columns: table => new
                {
                    BattleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batttles", x => x.BattleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_BattleId",
                table: "Character",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Batttles_BattleId",
                table: "Character",
                column: "BattleId",
                principalTable: "Batttles",
                principalColumn: "BattleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Batttles_BattleId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "Batttles");

            migrationBuilder.DropIndex(
                name: "IX_Character_BattleId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Character");
        }
    }
}
