using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInfrestructure.Migrations
{
    public partial class itemabilitiestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemAbilities_Abilities_AbilityIds",
                table: "ItemAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAbilities_Items_ItemIds",
                table: "ItemAbilities");

            migrationBuilder.DropTable(
                name: "ItemAbility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemAbilities",
                table: "ItemAbilities");

            migrationBuilder.RenameColumn(
                name: "ItemIds",
                table: "ItemAbilities",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "AbilityIds",
                table: "ItemAbilities",
                newName: "AbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemAbilities_ItemIds",
                table: "ItemAbilities",
                newName: "IX_ItemAbilities_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "ItemAbilityId",
                table: "ItemAbilities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemAbilities",
                table: "ItemAbilities",
                column: "ItemAbilityId");

            migrationBuilder.InsertData(
                table: "ItemAbilities",
                columns: new[] { "ItemAbilityId", "AbilityId", "ItemId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ItemAbilities_AbilityId",
                table: "ItemAbilities",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAbilities_Abilities_AbilityId",
                table: "ItemAbilities",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAbilities_Items_ItemId",
                table: "ItemAbilities",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemAbilities_Abilities_AbilityId",
                table: "ItemAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAbilities_Items_ItemId",
                table: "ItemAbilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemAbilities",
                table: "ItemAbilities");

            migrationBuilder.DropIndex(
                name: "IX_ItemAbilities_AbilityId",
                table: "ItemAbilities");

            migrationBuilder.DeleteData(
                table: "ItemAbilities",
                keyColumn: "ItemAbilityId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ItemAbilityId",
                table: "ItemAbilities");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemAbilities",
                newName: "ItemIds");

            migrationBuilder.RenameColumn(
                name: "AbilityId",
                table: "ItemAbilities",
                newName: "AbilityIds");

            migrationBuilder.RenameIndex(
                name: "IX_ItemAbilities_ItemId",
                table: "ItemAbilities",
                newName: "IX_ItemAbilities_ItemIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemAbilities",
                table: "ItemAbilities",
                columns: new[] { "AbilityIds", "ItemIds" });

            migrationBuilder.CreateTable(
                name: "ItemAbility",
                columns: table => new
                {
                    ItemAbilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAbility", x => x.ItemAbilityId);
                });

            migrationBuilder.InsertData(
                table: "ItemAbility",
                columns: new[] { "ItemAbilityId", "AbilityId", "ItemId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAbilities_Abilities_AbilityIds",
                table: "ItemAbilities",
                column: "AbilityIds",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAbilities_Items_ItemIds",
                table: "ItemAbilities",
                column: "ItemIds",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
