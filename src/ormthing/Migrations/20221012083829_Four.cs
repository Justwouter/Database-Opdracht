using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ormthing.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Attracties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Attracties");
        }
    }
}
