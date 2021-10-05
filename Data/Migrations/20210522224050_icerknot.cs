using Microsoft.EntityFrameworkCore.Migrations;

namespace DenizWeb.Data.Migrations
{
    public partial class icerknot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icerikNot",
                table: "Icerik",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icerikNot",
                table: "Icerik");
        }
    }
}
