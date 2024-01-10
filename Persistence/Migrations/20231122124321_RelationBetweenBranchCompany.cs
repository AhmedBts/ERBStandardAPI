using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenBranchCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyCode = table.Column<int>(type: "int", nullable: false),
                    CompanyArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEnName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyCode);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<int>(type: "int", nullable: true),
                    BranchAraName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchEngName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    workTimeFrom = table.Column<TimeSpan>(type: "time", nullable: true),
                    WorkTimeTo = table.Column<TimeSpan>(type: "time", nullable: true),
                    LicenseNo = table.Column<int>(type: "int", nullable: true),
                    Manager = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchCode);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Company",
                        principalColumn: "CompanyCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyCode",
                table: "Branch",
                column: "CompanyCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
