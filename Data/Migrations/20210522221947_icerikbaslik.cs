using Microsoft.EntityFrameworkCore.Migrations;

namespace DenizWeb.Data.Migrations
{
    public partial class icerikbaslik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "baslik",
                table: "Icerik",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "baslik",
                table: "Icerik");
        }
    }
}
