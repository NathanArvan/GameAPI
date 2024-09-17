using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInfrestructure.Migrations
{
    public partial class createuserentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Batttles_BattleId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Tokens_TokenId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItems_Character_CharacterIds",
                table: "CharacterItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_Character_TokenId",
                table: "Characters",
                newName: "IX_Characters_TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_BattleId",
                table: "Characters",
                newName: "IX_Characters_BattleId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItems_Characters_CharacterIds",
                table: "CharacterItems",
                column: "CharacterIds",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Batttles_BattleId",
                table: "Characters",
                column: "BattleId",
                principalTable: "Batttles",
                principalColumn: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Tokens_TokenId",
                table: "Characters",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItems_Characters_CharacterIds",
                table: "CharacterItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Batttles_BattleId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Tokens_TokenId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_UserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_TokenId",
                table: "Character",
                newName: "IX_Character_TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_BattleId",
                table: "Character",
                newName: "IX_Character_BattleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Batttles_BattleId",
                table: "Character",
                column: "BattleId",
                principalTable: "Batttles",
                principalColumn: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Tokens_TokenId",
                table: "Character",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItems_Character_CharacterIds",
                table: "CharacterItems",
                column: "CharacterIds",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
