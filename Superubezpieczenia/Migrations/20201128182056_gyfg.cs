using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superubezpieczenia.Migrations
{
    public partial class gyfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IDAuto = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Forms_Cars_IDAuto",
                        column: x => x.IDAuto,
                        principalTable: "Cars",
                        principalColumn: "IDAuto",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

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
