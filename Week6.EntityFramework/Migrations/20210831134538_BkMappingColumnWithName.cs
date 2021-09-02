using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.EntityFramework.Migrations
{
    public partial class BkMappingColumnWithName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleKnight_Battles_BattleId",
                table: "BattleKnight");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleKnight_Knights_KnightId",
                table: "BattleKnight");

            migrationBuilder.RenameColumn(
                name: "KnightId",
                table: "BattleKnight",
                newName: "KnightsId");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "BattleKnight",
                newName: "BattlesBattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleKnight_KnightId",
                table: "BattleKnight",
                newName: "IX_BattleKnight_KnightsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleKnight_Battles_BattlesBattleId",
                table: "BattleKnight",
                column: "BattlesBattleId",
                principalTable: "Battles",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleKnight_Knights_KnightsId",
                table: "BattleKnight",
                column: "KnightsId",
                principalTable: "Knights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleKnight_Battles_BattlesBattleId",
                table: "BattleKnight");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleKnight_Knights_KnightsId",
                table: "BattleKnight");

            migrationBuilder.RenameColumn(
                name: "KnightsId",
                table: "BattleKnight",
                newName: "KnightId");

            migrationBuilder.RenameColumn(
                name: "BattlesBattleId",
                table: "BattleKnight",
                newName: "BattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleKnight_KnightsId",
                table: "BattleKnight",
                newName: "IX_BattleKnight_KnightId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleKnight_Battles_BattleId",
                table: "BattleKnight",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleKnight_Knights_KnightId",
                table: "BattleKnight",
                column: "KnightId",
                principalTable: "Knights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
