using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRP.DAL.Migrations
{
    public partial class UpodateDataSetItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bedrooms",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BuildingArea",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Distance",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floors",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lattitude",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longtitude",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "DataSetItems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Rooms",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "DataSetItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearBuilt",
                table: "DataSetItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Bedrooms",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "BuildingArea",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Floors",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "DataSetItems");

            migrationBuilder.DropColumn(
                name: "YearBuilt",
                table: "DataSetItems");
        }
    }
}
