using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ormthing.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReserveringId",
                table: "Attractions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_ReserveringId",
                table: "Attractions",
                column: "ReserveringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Reservations_ReserveringId",
                table: "Attractions",
                column: "ReserveringId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Reservations_ReserveringId",
                table: "Attractions");

            migrationBuilder.DropIndex(
                name: "IX_Attractions_ReserveringId",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "ReserveringId",
                table: "Attractions");
        }
    }
}
