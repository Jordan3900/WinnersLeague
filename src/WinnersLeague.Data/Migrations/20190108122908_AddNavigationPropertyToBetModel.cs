using Microsoft.EntityFrameworkCore.Migrations;

namespace WinnersLeague.Data.Migrations
{
    public partial class AddNavigationPropertyToBetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_WinnersLeagueUserId",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "WinnersLeagueUserId",
                table: "Bets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_WinnersLeagueUserId",
                table: "Bets",
                newName: "IX_Bets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bets",
                newName: "WinnersLeagueUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                newName: "IX_Bets_WinnersLeagueUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_WinnersLeagueUserId",
                table: "Bets",
                column: "WinnersLeagueUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
