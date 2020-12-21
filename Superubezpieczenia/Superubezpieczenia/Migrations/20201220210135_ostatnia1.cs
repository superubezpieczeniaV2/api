using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class ostatnia1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_PriceLists_IDTypeInsurance",
                table: "PolicyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceLists",
                table: "PriceLists");

            migrationBuilder.RenameTable(
                name: "PriceLists",
                newName: "TypeInsurance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeInsurance",
                table: "TypeInsurance",
                column: "IDTypeInsurance");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_TypeInsurance_IDTypeInsurance",
                table: "PolicyDetails",
                column: "IDTypeInsurance",
                principalTable: "TypeInsurance",
                principalColumn: "IDTypeInsurance",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_TypeInsurance_IDTypeInsurance",
                table: "PolicyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeInsurance",
                table: "TypeInsurance");

            migrationBuilder.RenameTable(
                name: "TypeInsurance",
                newName: "PriceLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceLists",
                table: "PriceLists",
                column: "IDTypeInsurance");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_PriceLists_IDTypeInsurance",
                table: "PolicyDetails",
                column: "IDTypeInsurance",
                principalTable: "PriceLists",
                principalColumn: "IDTypeInsurance",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
