using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class sda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_Marks_IDMark",
                table: "PolicyDetails");

            migrationBuilder.RenameColumn(
                name: "IDMark",
                table: "PolicyDetails",
                newName: "IDModel");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyDetails_IDMark",
                table: "PolicyDetails",
                newName: "IX_PolicyDetails_IDModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_Models_IDModel",
                table: "PolicyDetails",
                column: "IDModel",
                principalTable: "Models",
                principalColumn: "IDModel",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_Models_IDModel",
                table: "PolicyDetails");

            migrationBuilder.RenameColumn(
                name: "IDModel",
                table: "PolicyDetails",
                newName: "IDMark");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyDetails_IDModel",
                table: "PolicyDetails",
                newName: "IX_PolicyDetails_IDMark");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_Marks_IDMark",
                table: "PolicyDetails",
                column: "IDMark",
                principalTable: "Marks",
                principalColumn: "IDMark",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
