using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRP.DAL.Migrations
{
    public partial class ChangedFileEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "FileEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FileEntries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "FileEntries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FileEntries");
        }
    }
}
