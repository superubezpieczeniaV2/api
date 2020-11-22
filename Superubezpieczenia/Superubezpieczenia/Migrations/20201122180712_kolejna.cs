using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class kolejna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnginePowers",
                columns: table => new
                {
                    IDenginePower = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Power = table.Column<double>(type: "float", nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnginePowers", x => x.IDenginePower);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    IDMark = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.IDMark);
                });

            migrationBuilder.CreateTable(
                name: "MethodUses",
                columns: table => new
                {
                    IDMethodUse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodUses", x => x.IDMethodUse);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlaces",
                columns: table => new
                {
                    IDParkingPlace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaces", x => x.IDParkingPlace);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    IDPermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.IDPermission);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    IDPriceList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.IDPriceList);
                });

            migrationBuilder.CreateTable(
                name: "TypeFuels",
                columns: table => new
                {
                    IDTypeFuel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFuels", x => x.IDTypeFuel);
                });

            migrationBuilder.CreateTable(
                name: "TypeOwners",
                columns: table => new
                {
                    IDTypeOwner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOwners", x => x.IDTypeOwner);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    IDModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMark = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.IDModel);
                    table.ForeignKey(
                        name: "FK_Models_Marks_IDMark",
                        column: x => x.IDMark,
                        principalTable: "Marks",
                        principalColumn: "IDMark",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    IDUserPermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    IDPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.IDUserPermission);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_IDPermission",
                        column: x => x.IDPermission,
                        principalTable: "Permissions",
                        principalColumn: "IDPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDModel = table.Column<int>(type: "int", nullable: false),
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
                name: "Forms",
                columns: table => new
                {
                    IDForm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    IDAuto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.IDForm);
                    table.ForeignKey(
                        name: "FK_Forms_Cars_IDAuto",
                        column: x => x.IDAuto,
                        principalTable: "Cars",
                        principalColumn: "IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    IDPolicy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDForm = table.Column<int>(type: "int", nullable: false),
                    IDPriceList = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Forms_IDAuto",
                table: "Forms",
                column: "IDAuto");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_IDUser",
                table: "Forms",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Models_IDMark",
                table: "Models",
                column: "IDMark");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_IDForm",
                table: "Policies",
                column: "IDForm");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_IDPriceList",
                table: "Policies",
                column: "IDPriceList");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_IDPermission",
                table: "UserPermissions",
                column: "IDPermission");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_IDUser",
                table: "UserPermissions",
                column: "IDUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EnginePowers");

            migrationBuilder.DropTable(
                name: "MethodUses");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ParkingPlaces");

            migrationBuilder.DropTable(
                name: "TypeFuels");

            migrationBuilder.DropTable(
                name: "TypeOwners");

            migrationBuilder.DropTable(
                name: "Marks");
        }
    }
}
