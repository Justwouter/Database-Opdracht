using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ormthing.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attracties_Reservations_reserveringId",
                table: "Attracties");

            migrationBuilder.DropIndex(
                name: "IX_Attracties_reserveringId",
                table: "Attracties");

            migrationBuilder.DropColumn(
                name: "reserveringId",
                table: "Attracties");

            migrationBuilder.AddColumn<int>(
                name: "ReservedAttractionId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedAttractionId",
                table: "Reservations",
                column: "ReservedAttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Attracties_ReservedAttractionId",
                table: "Reservations",
                column: "ReservedAttractionId",
                principalTable: "Attracties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Attracties_ReservedAttractionId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedAttractionId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedAttractionId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "reserveringId",
                table: "Attracties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attracties_reserveringId",
                table: "Attracties",
                column: "reserveringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attracties_Reservations_reserveringId",
                table: "Attracties",
                column: "reserveringId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
