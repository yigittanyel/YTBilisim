using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeBilisim.Web.Migrations
{
    public partial class initial_create_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnasayfaModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SloganAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    GovdeMetinBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovdeMetinAciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovdeMetinAciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizMetin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSol1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSol2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSol3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSag1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSag2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSag3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NedenBizSag4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnasayfaModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnasayfaMusteriYorumlariModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yorum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusteriAdi = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    MusteriTitle = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnasayfaMusteriYorumlariModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnaSayfaSliderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaSayfaSliderModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BizeUlasinModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(144)", maxLength: 144, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(144)", maxLength: 144, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(144)", maxLength: 144, nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GonderilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BizeUlasinModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    GonderilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Captcha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HakkimizdaModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BizKimizMetin1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BizKimizMetin2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vizyonumuz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Misyonumuz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KendimiziTanitalim1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KendimiziTanitalim2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HakkimizdaModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HakkimizdaSliderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HakkimizdaSliderModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresMetin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresIFrame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(144)", maxLength: 144, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(144)", maxLength: 144, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Sifre2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReCaptchaResults",
                columns: table => new
                {
                    Captcha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReferasanslarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    ReferansWebsite = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LastupUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    Kilitli = table.Column<bool>(type: "bit", nullable: true),
                    İptal = table.Column<bool>(type: "bit", nullable: true),
                    Special1 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special2 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Special3 = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    Catalog = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Entegrasyon = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FlagTipi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferasanslarModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnasayfaModels");

            migrationBuilder.DropTable(
                name: "AnasayfaMusteriYorumlariModels");

            migrationBuilder.DropTable(
                name: "AnaSayfaSliderModels");

            migrationBuilder.DropTable(
                name: "BizeUlasinModels");

            migrationBuilder.DropTable(
                name: "EmailDatas");

            migrationBuilder.DropTable(
                name: "HakkimizdaModels");

            migrationBuilder.DropTable(
                name: "HakkimizdaSliderModels");

            migrationBuilder.DropTable(
                name: "IletisimModels");

            migrationBuilder.DropTable(
                name: "Kullanicilars");

            migrationBuilder.DropTable(
                name: "ReCaptchaResults");

            migrationBuilder.DropTable(
                name: "ReferasanslarModels");
        }
    }
}
