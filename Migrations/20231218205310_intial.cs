using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyEntryArchiving.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCharts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyDetailsEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Debits = table.Column<double>(type: "float", nullable: false),
                    Credits = table.Column<double>(type: "float", nullable: false),
                    DailyEntryId = table.Column<int>(type: "int", nullable: false),
                    AccountChartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDetailsEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDetailsEntries_AccountCharts_AccountChartId",
                        column: x => x.AccountChartId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDetailsEntries_DailyEntries_DailyEntryId",
                        column: x => x.DailyEntryId,
                        principalTable: "DailyEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetailsEntries_AccountChartId",
                table: "DailyDetailsEntries",
                column: "AccountChartId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetailsEntries_DailyEntryId",
                table: "DailyDetailsEntries",
                column: "DailyEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyDetailsEntries");

            migrationBuilder.DropTable(
                name: "AccountCharts");

            migrationBuilder.DropTable(
                name: "DailyEntries");
        }
    }
}
