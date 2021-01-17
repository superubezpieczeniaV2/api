using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class dfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Cars_IDAuto",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.RenameColumn(
                name: "IDAuto",
                table: "Forms",
                newName: "IDPolicyDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_IDAuto",
                table: "Forms",
                newName: "IX_Forms_IDPolicyDetails");

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    IDInsurance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDForm = table.Column<int>(type: "int", nullable: false),
                    IDPriceList = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.IDInsurance);
                    table.ForeignKey(
                        name: "FK_Insurances_Forms_IDForm",
                        column: x => x.IDForm,
                        principalTable: "Forms",
                        principalColumn: "IDForm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Insurances_PriceLists_IDPriceList",
                        column: x => x.IDPriceList,
                        principalTable: "PriceLists",
                        principalColumn: "IDPriceList",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyDetails",
                columns: table => new
                {
                    IDPolicyDetails = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMark = table.Column<int>(type: "int", nullable: false),
                    IDTypeOwner = table.Column<int>(type: "int", nullable: false),
                    YearProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDTypeFuel = table.Column<int>(type: "int", nullable: false),
                    IDEnginePower = table.Column<int>(type: "int", nullable: false),
                    LocationDriver = table.Column<bool>(type: "bit", nullable: false),
                    FirstRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedMileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDMethodUse = table.Column<int>(type: "int", nullable: false),
                    IDParkingPlace = table.Column<int>(type: "int", nullable: false),
                    BroughtBack = table.Column<bool>(type: "bit", nullable: false),
                    SinceWhenInsurance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraDrivers = table.Column<int>(type: "int", nullable: false),
                    CurrentMileage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDetails", x => x.IDPolicyDetails);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_EnginePowers_IDEnginePower",
                        column: x => x.IDEnginePower,
                        principalTable: "EnginePowers",
                        principalColumn: "IDenginePower",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_Marks_IDMark",
                        column: x => x.IDMark,
                        principalTable: "Marks",
                        principalColumn: "IDMark",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_MethodUses_IDMethodUse",
                        column: x => x.IDMethodUse,
                        principalTable: "MethodUses",
                        principalColumn: "IDMethodUse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_ParkingPlaces_IDParkingPlace",
                        column: x => x.IDParkingPlace,
                        principalTable: "ParkingPlaces",
                        principalColumn: "IDParkingPlace",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_TypeFuels_IDTypeFuel",
                        column: x => x.IDTypeFuel,
                        principalTable: "TypeFuels",
                        principalColumn: "IDTypeFuel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_TypeOwners_IDTypeOwner",
                        column: x => x.IDTypeOwner,
                        principalTable: "TypeOwners",
                        principalColumn: "IDTypeOwner",
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
                name: "IX_PolicyDetails_IDEnginePower",
                table: "PolicyDetails",
                column: "IDEnginePower");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDMark",
                table: "PolicyDetails",
                column: "IDMark");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDMethodUse",
                table: "PolicyDetails",
                column: "IDMethodUse");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDParkingPlace",
                table: "PolicyDetails",
                column: "IDParkingPlace");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDTypeFuel",
                table: "PolicyDetails",
                column: "IDTypeFuel");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_IDTypeOwner",
                table: "PolicyDetails",
                column: "IDTypeOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_PolicyDetails_IDPolicyDetails",
                table: "Forms",
                column: "IDPolicyDetails",
                principalTable: "PolicyDetails",
                principalColumn: "IDPolicyDetails",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_PolicyDetails_IDPolicyDetails",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "PolicyDetails");

            migrationBuilder.RenameColumn(
                name: "IDPolicyDetails",
                table: "Forms",
                newName: "IDAuto");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_IDPolicyDetails",
                table: "Forms",
                newName: "IX_Forms_IDAuto");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroughtBack = table.Column<bool>(type: "bit", nullable: false),
                    CurrentMileage = table.Column<int>(type: "int", nullable: false),
                    ExtraDrivers = table.Column<int>(type: "int", nullable: false),
                    FirstRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDEnginePower = table.Column<int>(type: "int", nullable: false),
                    IDMethodUse = table.Column<int>(type: "int", nullable: false),
                    IDModel = table.Column<int>(type: "int", nullable: false),
                    IDParkingPlace = table.Column<int>(type: "int", nullable: false),
                    IDTypeFuel = table.Column<int>(type: "int", nullable: false),
                    IDTypeOwner = table.Column<int>(type: "int", nullable: false),
                    LocationDriver = table.Column<bool>(type: "bit", nullable: false),
                    PlannedMileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinceWhenInsurance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearProduction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IDAuto);
                    table.ForeignKey(
                        name: "FK_Cars_EnginePowers_IDEnginePower",
                        column: x => x.IDEnginePower,
                        principalTable: "EnginePowers",
                        principalColumn: "IDenginePower",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_MethodUses_IDMethodUse",
                        column: x => x.IDMethodUse,
                        principalTable: "MethodUses",
                        principalColumn: "IDMethodUse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_IDModel",
                        column: x => x.IDModel,
                        principalTable: "Models",
                        principalColumn: "IDModel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_ParkingPlaces_IDParkingPlace",
                        column: x => x.IDParkingPlace,
                        principalTable: "ParkingPlaces",
                        principalColumn: "IDParkingPlace",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_TypeFuels_IDTypeFuel",
                        column: x => x.IDTypeFuel,
                        principalTable: "TypeFuels",
                        principalColumn: "IDTypeFuel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_TypeOwners_IDTypeOwner",
                        column: x => x.IDTypeOwner,
                        principalTable: "TypeOwners",
                        principalColumn: "IDTypeOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    IDPolicy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDForm = table.Column<int>(type: "int", nullable: false),
                    IDPriceList = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.IDPolicy);
                    table.ForeignKey(
                        name: "FK_Policies_Forms_IDForm",
                        column: x => x.IDForm,
                        principalTable: "Forms",
                        principalColumn: "IDForm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_PriceLists_IDPriceList",
                        column: x => x.IDPriceList,
                        principalTable: "PriceLists",
                        principalColumn: "IDPriceList",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IDEnginePower",
                table: "Cars",
                column: "IDEnginePower");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IDMethodUse",
                table: "Cars",
                column: "IDMethodUse");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IDModel",
                table: "Cars",
                column: "IDModel");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IDParkingPlace",
                table: "Cars",
                column: "IDParkingPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IDTypeFuel",
                table: "Cars",
                column: "IDTypeFuel");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IDTypeOwner",
                table: "Cars",
                column: "IDTypeOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_IDForm",
                table: "Policies",
                column: "IDForm");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_IDPriceList",
                table: "Policies",
                column: "IDPriceList");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Cars_IDAuto",
                table: "Forms",
                column: "IDAuto",
                principalTable: "Cars",
                principalColumn: "IDAuto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
