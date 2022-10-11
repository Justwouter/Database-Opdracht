using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ormthing.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "GuestInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud_taken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud_taken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderhoud_taken_Attracties_Id",
                        column: x => x.Id,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_Email",
                        column: x => x.Email,
                        principalTable: "Gebruikers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    BegeleiderEmail = table.Column<string>(type: "TEXT", nullable: true),
                    FavorieteAttractieId = table.Column<int>(type: "INTEGER", nullable: true),
                    GastinfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Gasten_Attracties_FavorieteAttractieId",
                        column: x => x.FavorieteAttractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasten_Gasten_BegeleiderEmail",
                        column: x => x.BegeleiderEmail,
                        principalTable: "Gasten",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_Email",
                        column: x => x.Email,
                        principalTable: "Gebruikers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gasten_GuestInfo_GastinfoId",
                        column: x => x.GastinfoId,
                        principalTable: "GuestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GastId = table.Column<int>(type: "INTEGER", nullable: false),
                    gastEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ReservedAttractionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Attracties_ReservedAttractionId",
                        column: x => x.ReservedAttractionId,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Gasten_gastEmail",
                        column: x => x.gastEmail,
                        principalTable: "Gasten",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_BegeleiderEmail",
                table: "Gasten",
                column: "BegeleiderEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_FavorieteAttractieId",
                table: "Gasten",
                column: "FavorieteAttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_GastinfoId",
                table: "Gasten",
                column: "GastinfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_gastEmail",
                table: "Reservations",
                column: "gastEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedAttractionId",
                table: "Reservations",
                column: "ReservedAttractionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Onderhoud_taken");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "GuestInfo");
        }
    }
}
