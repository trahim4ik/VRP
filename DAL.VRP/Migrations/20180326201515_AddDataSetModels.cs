using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VRP.DAL.Migrations
{
    public partial class AddDataSetModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realty_AspNetUsers_UserId",
                table: "Realty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realty",
                table: "Realty");

            migrationBuilder.RenameTable(
                name: "Realty",
                newName: "Realties");

            migrationBuilder.RenameIndex(
                name: "IX_Realty_UserId",
                table: "Realties",
                newName: "IX_Realties_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Realties",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Realties",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realties",
                table: "Realties",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSetItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSetId = table.Column<long>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSetItems_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSetItems_DataSetId",
                table: "DataSetItems",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_UserId",
                table: "DataSets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_AspNetUsers_UserId",
                table: "Realties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realties_AspNetUsers_UserId",
                table: "Realties");

            migrationBuilder.DropTable(
                name: "DataSetItems");

            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realties",
                table: "Realties");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Realties");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Realties");

            migrationBuilder.RenameTable(
                name: "Realties",
                newName: "Realty");

            migrationBuilder.RenameIndex(
                name: "IX_Realties_UserId",
                table: "Realty",
                newName: "IX_Realty_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realty",
                table: "Realty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Realty_AspNetUsers_UserId",
                table: "Realty",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
