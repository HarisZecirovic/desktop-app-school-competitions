using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beleske",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserNameUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    ImeTimaUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    TesktBeleske = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beleske", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezultati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserNameUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    IdTakmicenja = table.Column<int>(type: "INTEGER", nullable: false),
                    ImeUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    PrezimeUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    Bodovi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezultati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Takmicenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NazivTakmicenja = table.Column<string>(type: "TEXT", nullable: true),
                    RokZaPrijavu = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumTakmicenja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RazredTakmicenja = table.Column<string>(type: "TEXT", nullable: true),
                    StatusTakmicenja = table.Column<string>(type: "TEXT", nullable: true),
                    DozvolaZaPrijavu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takmicenja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Ime = table.Column<string>(type: "TEXT", nullable: true),
                    Prezime = table.Column<string>(type: "TEXT", nullable: true),
                    Lozinka = table.Column<string>(type: "TEXT", nullable: true),
                    Mesto = table.Column<string>(type: "TEXT", nullable: true),
                    Drzava = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    ElPosta = table.Column<string>(type: "TEXT", nullable: true),
                    Tip = table.Column<string>(type: "TEXT", nullable: true),
                    Dozvola = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "PrijaveZaTakmicenje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime_Tima = table.Column<string>(type: "TEXT", nullable: true),
                    Razred = table.Column<string>(type: "TEXT", nullable: true),
                    NazivSkole = table.Column<string>(type: "TEXT", nullable: true),
                    TakmicenjeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijaveZaTakmicenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijaveZaTakmicenje_Takmicenja_TakmicenjeId",
                        column: x => x.TakmicenjeId,
                        principalTable: "Takmicenja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skola",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NazivSkole = table.Column<string>(type: "TEXT", nullable: true),
                    UserNameSkole = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skola", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skola_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ucenici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Jmbg = table.Column<string>(type: "TEXT", nullable: true),
                    Pol = table.Column<string>(type: "TEXT", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Razred = table.Column<string>(type: "TEXT", nullable: true),
                    UserNameUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ucenici_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RasporediSedenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserNameUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    IdTakmicenja = table.Column<int>(type: "INTEGER", nullable: false),
                    ImeTima = table.Column<string>(type: "TEXT", nullable: true),
                    NazivSkole = table.Column<string>(type: "TEXT", nullable: true),
                    BrojKlupe = table.Column<int>(type: "INTEGER", nullable: false),
                    BrojZadnjeKlupe = table.Column<int>(type: "INTEGER", nullable: false),
                    PrijavaZaTakmicenjeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporediSedenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RasporediSedenja_PrijaveZaTakmicenje_PrijavaZaTakmicenjeId",
                        column: x => x.PrijavaZaTakmicenjeId,
                        principalTable: "PrijaveZaTakmicenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timovi",
                columns: table => new
                {
                    ImeTima = table.Column<string>(type: "TEXT", nullable: false),
                    Razred = table.Column<string>(type: "TEXT", nullable: true),
                    SkolaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timovi", x => x.ImeTima);
                    table.ForeignKey(
                        name: "FK_Timovi_Skola_SkolaId",
                        column: x => x.SkolaId,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Dozvola = table.Column<string>(type: "TEXT", nullable: true),
                    UserNameUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    UcenikId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImeTimaUcenika = table.Column<string>(type: "TEXT", nullable: true),
                    ImeSkole = table.Column<string>(type: "TEXT", nullable: true),
                    TimImeTima = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clanovi_Timovi_TimImeTima",
                        column: x => x.TimImeTima,
                        principalTable: "Timovi",
                        principalColumn: "ImeTima",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clanovi_Ucenici_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Ucenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_TimImeTima",
                table: "Clanovi",
                column: "TimImeTima");

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_UcenikId",
                table: "Clanovi",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveZaTakmicenje_TakmicenjeId",
                table: "PrijaveZaTakmicenje",
                column: "TakmicenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_RasporediSedenja_PrijavaZaTakmicenjeId",
                table: "RasporediSedenja",
                column: "PrijavaZaTakmicenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skola_UserName",
                table: "Skola",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Timovi_SkolaId",
                table: "Timovi",
                column: "SkolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ucenici_UserName",
                table: "Ucenici",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beleske");

            migrationBuilder.DropTable(
                name: "Clanovi");

            migrationBuilder.DropTable(
                name: "RasporediSedenja");

            migrationBuilder.DropTable(
                name: "Rezultati");

            migrationBuilder.DropTable(
                name: "Timovi");

            migrationBuilder.DropTable(
                name: "Ucenici");

            migrationBuilder.DropTable(
                name: "PrijaveZaTakmicenje");

            migrationBuilder.DropTable(
                name: "Skola");

            migrationBuilder.DropTable(
                name: "Takmicenja");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
