﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VRP.Core.Enums;
using VRP.DAL;

namespace VRP.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180511090826_AddDataSetPredictTable")]
    partial class AddDataSetPredictTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VRP.Entities.DataSet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("InsertDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DataSets");
                });

            modelBuilder.Entity("VRP.Entities.DataSetFileEntry", b =>
                {
                    b.Property<long>("FileEntryId");

                    b.Property<long>("DataSetId");

                    b.Property<int>("DataSetType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("FileEntryId", "DataSetId");

                    b.HasIndex("DataSetId");

                    b.ToTable("DataSetFileEntry");
                });

            modelBuilder.Entity("VRP.Entities.DataSetItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("BasketballDistance");

                    b.Property<double?>("BigMarketDistance");

                    b.Property<double?>("BusTerminalDistance");

                    b.Property<double?>("CarMetroDistance");

                    b.Property<double?>("CarMetroMin");

                    b.Property<long>("DataSetId");

                    b.Property<int>("DataSetType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<double?>("DetentionFacilityDistance");

                    b.Property<string>("District");

                    b.Property<int?>("ElderAll");

                    b.Property<int?>("ElderFemale");

                    b.Property<int?>("ElderMale");

                    b.Property<int?>("Female");

                    b.Property<double?>("FitnessDistance");

                    b.Property<int?>("Floor");

                    b.Property<double?>("FullArea");

                    b.Property<double?>("GreenZoneDistance");

                    b.Property<double?>("HospiceDistance");

                    b.Property<double?>("IcePalaceDistance");

                    b.Property<double?>("IndustrialZoneDistance");

                    b.Property<DateTime>("InsertDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double?>("KindergartenDistance");

                    b.Property<double?>("KitchenArea");

                    b.Property<double?>("LifeArea");

                    b.Property<int?>("Male");

                    b.Property<double?>("MarketDistance");

                    b.Property<int>("Material");

                    b.Property<int?>("MaxFloor");

                    b.Property<double?>("MetroDistance");

                    b.Property<double?>("ParkDistance");

                    b.Property<int?>("Population");

                    b.Property<double?>("Price");

                    b.Property<string>("ProductType");

                    b.Property<double?>("PublicHealthcareDistance");

                    b.Property<int?>("Rooms");

                    b.Property<DateTime?>("SaleDate");

                    b.Property<double?>("SchoolDistance");

                    b.Property<double?>("StadiumDistance");

                    b.Property<int?>("State");

                    b.Property<double?>("SwimmingPoolDistance");

                    b.Property<double?>("TimeToMetro");

                    b.Property<double?>("TrainStationDistance");

                    b.Property<double?>("UniversityDistance");

                    b.Property<int?>("WorkAll");

                    b.Property<int?>("WorkFemale");

                    b.Property<int?>("WorkMale");

                    b.Property<int?>("YearBuilt");

                    b.Property<int?>("YoungAll");

                    b.Property<int?>("YoungFemale");

                    b.Property<int?>("YoungMale");

                    b.HasKey("Id");

                    b.HasIndex("DataSetId");

                    b.ToTable("DataSetItems");
                });

            modelBuilder.Entity("VRP.Entities.DataSetNetwork", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DataSetId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<double>("Error");

                    b.Property<long>("FileEntryId");

                    b.Property<DateTime>("InsertDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("DataSetId");

                    b.HasIndex("FileEntryId");

                    b.ToTable("DataSetNetworks");
                });

            modelBuilder.Entity("VRP.Entities.DataSetPredict", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DataSetId");

                    b.Property<double>("Predict");

                    b.Property<double>("Target");

                    b.HasKey("Id");

                    b.HasIndex("DataSetId");

                    b.ToTable("DataSetPredicts");
                });

            modelBuilder.Entity("VRP.Entities.FileEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Description");

                    b.Property<string>("Extension");

                    b.Property<string>("FileName");

                    b.Property<DateTime>("InsertDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<long>("Length");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FileEntries");
                });

            modelBuilder.Entity("VRP.Entities.Realty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Area");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<DateTime>("InsertDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<double>("Price");

                    b.Property<long>("UserId");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Realties");
                });

            modelBuilder.Entity("VRP.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("VRP.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("VRP.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("VRP.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("VRP.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("VRP.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VRP.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("VRP.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VRP.Entities.DataSet", b =>
                {
                    b.HasOne("VRP.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VRP.Entities.DataSetFileEntry", b =>
                {
                    b.HasOne("VRP.Entities.DataSet", "DataSet")
                        .WithMany("DataSetFileEntries")
                        .HasForeignKey("DataSetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VRP.Entities.FileEntry", "FileEntry")
                        .WithMany("DataSetFileEntries")
                        .HasForeignKey("FileEntryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VRP.Entities.DataSetItem", b =>
                {
                    b.HasOne("VRP.Entities.DataSet", "DataSet")
                        .WithMany("DataSetItems")
                        .HasForeignKey("DataSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VRP.Entities.DataSetNetwork", b =>
                {
                    b.HasOne("VRP.Entities.DataSet", "DataSet")
                        .WithMany("DataSetNetworks")
                        .HasForeignKey("DataSetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VRP.Entities.FileEntry", "FileEntry")
                        .WithMany()
                        .HasForeignKey("FileEntryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VRP.Entities.DataSetPredict", b =>
                {
                    b.HasOne("VRP.Entities.DataSet", "DataSet")
                        .WithMany("DataSetPredicts")
                        .HasForeignKey("DataSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VRP.Entities.Realty", b =>
                {
                    b.HasOne("VRP.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
