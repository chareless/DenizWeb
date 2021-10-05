using Microsoft.EntityFrameworkCore.Migrations;

namespace DenizWeb.Data.Migrations
{
    public partial class deletefoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    fotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fotoAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoWidth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.fotoId);
                });
        }
    }
}
