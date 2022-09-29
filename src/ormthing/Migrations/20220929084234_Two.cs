using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ormthing.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attracties_Reservations_ReserveringId",
                table: "Attracties");

            migrationBuilder.RenameColumn(
                name: "ReserveringId",
                table: "Attracties",
                newName: "reserveringId");

            migrationBuilder.RenameIndex(
                name: "IX_Attracties_ReserveringId",
                table: "Attracties",
                newName: "IX_Attracties_reserveringId");

            migrationBuilder.AddColumn<string>(
                name: "BegeleiderEmail",
                table: "Gasten",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_BegeleiderEmail",
                table: "Gasten",
                column: "BegeleiderEmail",
                unique: true,
                filter: "[BegeleiderEmail] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Attracties_Reservations_reserveringId",
                table: "Attracties",
                column: "reserveringId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_Gasten_BegeleiderEmail",
                table: "Gasten",
                column: "BegeleiderEmail",
                principalTable: "Gasten",
                principalColumn: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attracties_Reservations_reserveringId",
                table: "Attracties");

            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_Gasten_BegeleiderEmail",
                table: "Gasten");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_BegeleiderEmail",
                table: "Gasten");

            migrationBuilder.DropColumn(
                name: "BegeleiderEmail",
                table: "Gasten");

            migrationBuilder.RenameColumn(
                name: "reserveringId",
                table: "Attracties",
                newName: "ReserveringId");

            migrationBuilder.RenameIndex(
                name: "IX_Attracties_reserveringId",
                table: "Attracties",
                newName: "IX_Attracties_ReserveringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attracties_Reservations_ReserveringId",
                table: "Attracties",
                column: "ReserveringId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
