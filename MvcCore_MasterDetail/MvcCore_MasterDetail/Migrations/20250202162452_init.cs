using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCore_MasterDetail.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentHearingDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextHearingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CaseMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseDetails_CaseMasters_CaseMasterId",
                        column: x => x.CaseMasterId,
                        principalTable: "CaseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseDetails_CaseMasterId",
                table: "CaseDetails",
                column: "CaseMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseDetails");

            migrationBuilder.DropTable(
                name: "CaseMasters");
        }
    }
}
