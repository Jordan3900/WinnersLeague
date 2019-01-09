using Microsoft.EntityFrameworkCore.Migrations;

namespace WinnersLeague.Data.Migrations
{
    public partial class MatchCheckedPropertyToMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMatchChecked",
                table: "Matches",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMatchChecked",
                table: "Matches");
        }
    }
}
