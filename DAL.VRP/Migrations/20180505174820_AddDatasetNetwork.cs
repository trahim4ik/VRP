using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRP.DAL.Migrations
{
    public partial class AddDatasetNetwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSetNetworks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSetId = table.Column<long>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Error = table.Column<double>(nullable: false),
                    FileEntryId = table.Column<long>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSetNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSetNetworks_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSetNetworks_FileEntries_FileEntryId",
                        column: x => x.FileEntryId,
                        principalTable: "FileEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSetNetworks_DataSetId",
                table: "DataSetNetworks",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSetNetworks_FileEntryId",
                table: "DataSetNetworks",
                column: "FileEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSetNetworks");
        }
    }
}
