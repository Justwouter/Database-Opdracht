using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ormthing.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Gasten",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavorieteAttractieId",
                table: "Gasten",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GeboorteDatum",
                table: "Gasten",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_FavorieteAttractieId",
                table: "Gasten",
                column: "FavorieteAttractieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_Attractions_FavorieteAttractieId",
                table: "Gasten",
                column: "FavorieteAttractieId",
                principalTable: "Attractions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_Attractions_FavorieteAttractieId",
                table: "Gasten");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_FavorieteAttractieId",
                table: "Gasten");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Gasten");

            migrationBuilder.DropColumn(
                name: "FavorieteAttractieId",
                table: "Gasten");

            migrationBuilder.DropColumn(
                name: "GeboorteDatum",
                table: "Gasten");
        }
    }
}
