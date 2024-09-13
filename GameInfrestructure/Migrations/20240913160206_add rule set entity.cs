using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInfrestructure.Migrations
{
    public partial class addrulesetentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RuleSetId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleSetId",
                table: "Batttles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleSetId",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RuleSets",
                columns: table => new
                {
                    RuleSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSets", x => x.RuleSetId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_RuleSetId",
                table: "Items",
                column: "RuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Batttles_RuleSetId",
                table: "Batttles",
                column: "RuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_RuleSetId",
                table: "Abilities",
                column: "RuleSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_RuleSets_RuleSetId",
                table: "Abilities",
                column: "RuleSetId",
                principalTable: "RuleSets",
                principalColumn: "RuleSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batttles_RuleSets_RuleSetId",
                table: "Batttles",
                column: "RuleSetId",
                principalTable: "RuleSets",
                principalColumn: "RuleSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_RuleSets_RuleSetId",
                table: "Items",
                column: "RuleSetId",
                principalTable: "RuleSets",
                principalColumn: "RuleSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_RuleSets_RuleSetId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Batttles_RuleSets_RuleSetId",
                table: "Batttles");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_RuleSets_RuleSetId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "RuleSets");

            migrationBuilder.DropIndex(
                name: "IX_Items_RuleSetId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Batttles_RuleSetId",
                table: "Batttles");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_RuleSetId",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "RuleSetId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RuleSetId",
                table: "Batttles");

            migrationBuilder.DropColumn(
                name: "RuleSetId",
                table: "Abilities");
        }
    }
}
