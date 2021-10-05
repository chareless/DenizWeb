using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DenizWeb.Data.Migrations
{
    public partial class firstdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cinsiyet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dogumTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "isim",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Beceriler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    beceri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beceriler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blogTur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    altBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eklemeTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degistirmeTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    boyut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    fotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoWidth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.fotoId);
                });

            migrationBuilder.CreateTable(
                name: "Okul",
                columns: table => new
                {
                    okulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    okulAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    okulTarih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    okulTur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    okulInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okul", x => x.okulId);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    MyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meslek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profileFotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backFotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hakkımda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    egitimDurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    egitimBolumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sliderFotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sliderFotoBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sliderFotoAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    formUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.MyId);
                });

            migrationBuilder.CreateTable(
                name: "SliderFoto",
                columns: table => new
                {
                    sliderFotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotoAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderFoto", x => x.sliderFotoId);
                });

            migrationBuilder.CreateTable(
                name: "Sosyal",
                columns: table => new
                {
                    sosyalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sosyalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sosyalTur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sosyalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sosyalFooter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sosyal", x => x.sosyalId);
                });

            migrationBuilder.CreateTable(
                name: "Icerik",
                columns: table => new
                {
                    icerikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eklemeTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icerik", x => x.icerikId);
                    table.ForeignKey(
                        name: "FK_Icerik_Blog_blogId",
                        column: x => x.blogId,
                        principalTable: "Blog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    blogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yorum_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yorum_Blog_blogId",
                        column: x => x.blogId,
                        principalTable: "Blog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Icerik_blogId",
                table: "Icerik",
                column: "blogId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_blogId",
                table: "Yorum",
                column: "blogId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_userId",
                table: "Yorum",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beceriler");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Icerik");

            migrationBuilder.DropTable(
                name: "Okul");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "SliderFoto");

            migrationBuilder.DropTable(
                name: "Sosyal");

            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropColumn(
                name: "cinsiyet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "dogumTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isim",
                table: "AspNetUsers");
        }
    }
}
