using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInfrestructure.Migrations
{
    public partial class initializedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemAbility",
                columns: table => new
                {
                    ItemAbilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAbility", x => x.ItemAbilityId);
                });

            migrationBuilder.InsertData(
                table: "ItemAbility",
                columns: new[] { "ItemAbilityId", "AbilityId", "ItemId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "RuleSets",
                columns: new[] { "RuleSetId", "Name" },
                values: new object[] { 1, "Test" });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "AbilityId", "Description", "Duration", "Name", "Range", "RuleSetId" },
                values: new object[] { 1, "", 0, "Shoot Arrow", 0, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Name", "RuleSetId", "Weight" },
                values: new object[] { 1, "Bow", 1, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAbility");

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RuleSets",
                keyColumn: "RuleSetId",
                keyValue: 1);
        }
    }
}
