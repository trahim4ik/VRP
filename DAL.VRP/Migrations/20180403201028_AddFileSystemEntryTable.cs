using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRP.DAL.Migrations
{
    public partial class AddFileSystemEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileEntries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentType = table.Column<string>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSetFileEntry",
                columns: table => new
                {
                    FileEntryId = table.Column<long>(nullable: false),
                    DataSetId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSetFileEntry", x => new { x.FileEntryId, x.DataSetId });
                    table.ForeignKey(
                        name: "FK_DataSetFileEntry_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSetFileEntry_FileEntries_FileEntryId",
                        column: x => x.FileEntryId,
                        principalTable: "FileEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSetFileEntry_DataSetId",
                table: "DataSetFileEntry",
                column: "DataSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSetFileEntry");

            migrationBuilder.DropTable(
                name: "FileEntries");
        }
    }
}
