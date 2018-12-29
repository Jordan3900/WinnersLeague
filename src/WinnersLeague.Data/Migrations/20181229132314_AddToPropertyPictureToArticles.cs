using Microsoft.EntityFrameworkCore.Migrations;

namespace WinnersLeague.Data.Migrations
{
    public partial class AddToPropertyPictureToArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Articles");
        }
    }
}
