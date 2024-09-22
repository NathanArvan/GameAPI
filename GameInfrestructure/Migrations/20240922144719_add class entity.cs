using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInfrestructure.Migrations
{
    public partial class addclassentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.CharacterClassId);
                    table.ForeignKey(
                        name: "FK_CharacterClass_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "CharacterId", "Name" },
                values: new object[] { 1, null, "Warrior" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "CharacterId", "Name" },
                values: new object[] { 2, null, "Sage" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "CharacterId", "Name" },
                values: new object[] { 3, null, "Thief" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_CharacterId",
                table: "CharacterClass",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_ClassId",
                table: "CharacterClass",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClass");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Characters");
        }
    }
}
