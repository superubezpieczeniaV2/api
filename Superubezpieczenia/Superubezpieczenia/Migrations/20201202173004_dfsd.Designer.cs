﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Superubezpieczenia.Persistence.Context;

namespace Superubezpieczenia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201202173004_dfsd")]
    partial class dfsd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.EnginePower", b =>
                {
                    b.Property<int>("IDenginePower")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<double>("Power")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IDenginePower");

                    b.ToTable("EnginePowers");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Form", b =>
                {
                    b.Property<int>("IDForm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDPolicyDetails")
                        .HasColumnType("int");

                    b.Property<string>("IDUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IDForm");

                    b.HasIndex("IDPolicyDetails");

                    b.HasIndex("IDUser");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Insurance", b =>
                {
                    b.Property<int>("IDInsurance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDForm")
                        .HasColumnType("int");

                    b.Property<int>("IDPriceList")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IDInsurance");

                    b.HasIndex("IDForm");

                    b.HasIndex("IDPriceList");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Mark", b =>
                {
                    b.Property<int>("IDMark")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IDMark");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.MethodUse", b =>
                {
                    b.Property<int>("IDMethodUse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IDMethodUse");

                    b.ToTable("MethodUses");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Model", b =>
                {
                    b.Property<int>("IDModel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDMark")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDModel");

                    b.HasIndex("IDMark");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.ParkingPlace", b =>
                {
                    b.Property<int>("IDParkingPlace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("value")
                        .HasColumnType("float");

                    b.HasKey("IDParkingPlace");

                    b.ToTable("ParkingPlaces");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.PolicyDetails", b =>
                {
                    b.Property<int>("IDPolicyDetails")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("BroughtBack")
                        .HasColumnType("bit");

                    b.Property<int>("CurrentMileage")
                        .HasColumnType("int");

                    b.Property<int>("ExtraDrivers")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDEnginePower")
                        .HasColumnType("int");

                    b.Property<int>("IDMark")
                        .HasColumnType("int");

                    b.Property<int>("IDMethodUse")
                        .HasColumnType("int");

                    b.Property<int>("IDParkingPlace")
                        .HasColumnType("int");

                    b.Property<int>("IDTypeFuel")
                        .HasColumnType("int");

                    b.Property<int>("IDTypeOwner")
                        .HasColumnType("int");

                    b.Property<bool>("LocationDriver")
                        .HasColumnType("bit");

                    b.Property<string>("PlannedMileage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SinceWhenInsurance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("YearProduction")
                        .HasColumnType("datetime2");

                    b.HasKey("IDPolicyDetails");

                    b.HasIndex("IDEnginePower");

                    b.HasIndex("IDMark");

                    b.HasIndex("IDMethodUse");

                    b.HasIndex("IDParkingPlace");

                    b.HasIndex("IDTypeFuel");

                    b.HasIndex("IDTypeOwner");

                    b.ToTable("PolicyDetails");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.PriceList", b =>
                {
                    b.Property<int>("IDPriceList")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDPriceList");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.TypeFuel", b =>
                {
                    b.Property<int>("IDTypeFuel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("IDTypeFuel");

                    b.ToTable("TypeFuels");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.TypeOwner", b =>
                {
                    b.Property<int>("IDTypeOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IDTypeOwner");

                    b.ToTable("TypeOwners");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Form", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.PolicyDetails", "PolicyDetails")
                        .WithMany("Forms")
                        .HasForeignKey("IDPolicyDetails")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IDUser");

                    b.Navigation("PolicyDetails");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Insurance", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.Form", "Form")
                        .WithMany("Policies")
                        .HasForeignKey("IDForm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.PriceList", "PriceList")
                        .WithMany("Insurances")
                        .HasForeignKey("IDPriceList")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Model", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.Mark", "Mark")
                        .WithMany("Models")
                        .HasForeignKey("IDMark")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.PolicyDetails", b =>
                {
                    b.HasOne("Superubezpieczenia.Domain.Models.EnginePower", "EnginePower")
                        .WithMany("Policies")
                        .HasForeignKey("IDEnginePower")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.Mark", "Mark")
                        .WithMany("Policies")
                        .HasForeignKey("IDMark")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.MethodUse", "MethodUse")
                        .WithMany("Policies")
                        .HasForeignKey("IDMethodUse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.ParkingPlace", "ParkingPlace")
                        .WithMany("Policies")
                        .HasForeignKey("IDParkingPlace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.TypeFuel", "TypeFuel")
                        .WithMany("Policies")
                        .HasForeignKey("IDTypeFuel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superubezpieczenia.Domain.Models.TypeOwner", "TypeOwner")
                        .WithMany("Policies")
                        .HasForeignKey("IDTypeOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnginePower");

                    b.Navigation("Mark");

                    b.Navigation("MethodUse");

                    b.Navigation("ParkingPlace");

                    b.Navigation("TypeFuel");

                    b.Navigation("TypeOwner");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.EnginePower", b =>
                {
                    b.Navigation("Policies");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Form", b =>
                {
                    b.Navigation("Policies");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.Mark", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Policies");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.MethodUse", b =>
                {
                    b.Navigation("Policies");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.ParkingPlace", b =>
                {
                    b.Navigation("Policies");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.PolicyDetails", b =>
                {
                    b.Navigation("Forms");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.PriceList", b =>
                {
                    b.Navigation("Insurances");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.TypeFuel", b =>
                {
                    b.Navigation("Policies");
                });

            modelBuilder.Entity("Superubezpieczenia.Domain.Models.TypeOwner", b =>
                {
                    b.Navigation("Policies");
                });
#pragma warning restore 612, 618
        }
    }
}
