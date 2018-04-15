using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRP.DAL.Migrations
{
    public partial class UpdatedDatasetInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "DataSetItems");

            migrationBuilder.RenameColumn(
                name: "Postcode",
                table: "DataSetItems",
                newName: "ProductType");

            migrationBuilder.RenameColumn(
                name: "OwnerName",
                table: "DataSetItems",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "Longtitude",
                table: "DataSetItems",
                newName: "UniversityDistance");

            migrationBuilder.RenameColumn(
                name: "Lattitude",
                table: "DataSetItems",
                newName: "TrainStationDistance");

            migrationBuilder.RenameColumn(
                name: "Floors",
                table: "DataSetItems",
                newName: "YoungMale");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "DataSetItems",
                newName: "TimeToMetro");

            migrationBuilder.RenameColumn(
                name: "BuildingArea",
                table: "DataSetItems",
                newName: "SwimmingPoolDistance");

            migrationBuilder.RenameColumn(
                name: "Bedrooms",
                table: "DataSetItems",
                newName: "YoungFemale");

            migrationBuilder.RenameColumn(
                name: "Bathrooms",
                table: "DataSetItems",
                newName: "YoungAll");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "DataSetItems",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "BasketballDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BigMarketDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BusTerminalDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CarMetroDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CarMetroMin",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DetentionFacilityDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElderAll",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElderFemale",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElderMale",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Female",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FitnessDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FullArea",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GreenZoneDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HospiceDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IcePalaceDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IndustrialZoneDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "KindergartenDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "KitchenArea",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LifeArea",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Male",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MarketDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Material",
                table: "DataSetItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxFloor",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MetroDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ParkDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PublicHealthcareDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SchoolDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StadiumDistance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkAll",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkFemale",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkMale",
                table: "DataSetItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasketballDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "BigMarketDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "BusTerminalDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "CarMetroDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "CarMetroMin",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "DetentionFacilityDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "ElderAll",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "ElderFemale",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "ElderMale",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Female",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "FitnessDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "FullArea",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "GreenZoneDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "HospiceDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "IcePalaceDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "IndustrialZoneDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "KindergartenDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "KitchenArea",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "LifeArea",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Male",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "MarketDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "MaxFloor",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "MetroDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "ParkDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "PublicHealthcareDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "SchoolDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "StadiumDistance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "State",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "WorkAll",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "WorkFemale",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "WorkMale",
                table: "DataSetItems");

            migrationBuilder.RenameColumn(
                name: "YoungMale",
                table: "DataSetItems",
                newName: "Floors");

            migrationBuilder.RenameColumn(
                name: "YoungFemale",
                table: "DataSetItems",
                newName: "Bedrooms");

            migrationBuilder.RenameColumn(
                name: "YoungAll",
                table: "DataSetItems",
                newName: "Bathrooms");

            migrationBuilder.RenameColumn(
                name: "UniversityDistance",
                table: "DataSetItems",
                newName: "Longtitude");

            migrationBuilder.RenameColumn(
                name: "TrainStationDistance",
                table: "DataSetItems",
                newName: "Lattitude");

            migrationBuilder.RenameColumn(
                name: "TimeToMetro",
                table: "DataSetItems",
                newName: "Distance");

            migrationBuilder.RenameColumn(
                name: "SwimmingPoolDistance",
                table: "DataSetItems",
                newName: "BuildingArea");

            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "DataSetItems",
                newName: "Postcode");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "DataSetItems",
                newName: "OwnerName");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "DataSetItems",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DataSetItems",
                nullable: true);
        }
    }
}
