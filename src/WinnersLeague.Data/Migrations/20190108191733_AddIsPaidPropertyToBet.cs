using Microsoft.EntityFrameworkCore.Migrations;

namespace WinnersLeague.Data.Migrations
{
    public partial class AddIsPaidPropertyToBet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Bets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Bets");
        }
    }
}
