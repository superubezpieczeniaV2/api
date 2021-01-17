using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class aeews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "ParkingPlaces",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "IDenginePower",
                table: "EnginePowers",
                newName: "IDEnginePower");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "PolicyDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "PolicyDetails");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ParkingPlaces",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "IDEnginePower",
                table: "EnginePowers",
                newName: "IDenginePower");
        }
    }
}
