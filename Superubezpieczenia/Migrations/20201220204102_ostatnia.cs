using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class ostatnia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Forms_IDForm",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_PriceLists_IDPriceList",
                table: "Insurances");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_IDForm",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_IDPriceList",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "IDForm",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "IDPriceList",
                table: "Insurances");

            migrationBuilder.RenameColumn(
                name: "IDPriceList",
                table: "PriceLists",
                newName: "IDTypeInsurance");

            migrationBuilder.AddColumn<int>(
                name: "IDTypeInsurance",
                table: "PolicyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IDUser",
                table: "PolicyDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDUser",
                table: "Insurances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDTypeInsurance",
                table: "PolicyDetails",
                column: "IDTypeInsurance");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDUser",
                table: "PolicyDetails",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_IDUser",
                table: "Insurances",
                column: "IDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_AspNetUsers_IDUser",
                table: "Insurances",
                column: "IDUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_AspNetUsers_IDUser",
                table: "PolicyDetails",
                column: "IDUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDetails_PriceLists_IDTypeInsurance",
                table: "PolicyDetails",
                column: "IDTypeInsurance",
                principalTable: "PriceLists",
                principalColumn: "IDTypeInsurance",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_AspNetUsers_IDUser",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_AspNetUsers_IDUser",
                table: "PolicyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDetails_PriceLists_IDTypeInsurance",
                table: "PolicyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDetails_IDTypeInsurance",
                table: "PolicyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDetails_IDUser",
                table: "PolicyDetails");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_IDUser",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "IDTypeInsurance",
                table: "PolicyDetails");

            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "PolicyDetails");

            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "Insurances");

            migrationBuilder.RenameColumn(
                name: "IDTypeInsurance",
                table: "PriceLists",
                newName: "IDPriceList");

            migrationBuilder.AddColumn<int>(
                name: "IDForm",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDPriceList",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    IDForm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPolicyDetails = table.Column<int>(type: "int", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.IDForm);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forms_PolicyDetails_IDPolicyDetails",
                        column: x => x.IDPolicyDetails,
                        principalTable: "PolicyDetails",
                        principalColumn: "IDPolicyDetails",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_IDForm",
                table: "Insurances",
                column: "IDForm");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_IDPriceList",
                table: "Insurances",
                column: "IDPriceList");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_IDPolicyDetails",
                table: "Forms",
                column: "IDPolicyDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_IDUser",
                table: "Forms",
                column: "IDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Forms_IDForm",
                table: "Insurances",
                column: "IDForm",
                principalTable: "Forms",
                principalColumn: "IDForm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_PriceLists_IDPriceList",
                table: "Insurances",
                column: "IDPriceList",
                principalTable: "PriceLists",
                principalColumn: "IDPriceList",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
