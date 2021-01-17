using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class ostatnia2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Models",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Models");
        }
    }
}
