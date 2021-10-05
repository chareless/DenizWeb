using Microsoft.EntityFrameworkCore.Migrations;

namespace DenizWeb.Data.Migrations
{
    public partial class eklenenduzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icerikNot",
                table: "Icerik");

            migrationBuilder.CreateTable(
                name: "Eklenenler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarih = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eklenenler", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eklenenler");

            migrationBuilder.AddColumn<string>(
                name: "icerikNot",
                table: "Icerik",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
