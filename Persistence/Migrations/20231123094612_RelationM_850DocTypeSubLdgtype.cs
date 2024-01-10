using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationM850DocTypeSubLdgtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Company_CompanyCode",
                table: "Branch");

            migrationBuilder.CreateTable(
                name: "M_850DocType",
                columns: table => new
                {
                    Kind = table.Column<int>(type: "int", nullable: false),
                    DocTypeCode = table.Column<int>(type: "int", nullable: false),
                    Serial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubLdgTypeCode = table.Column<int>(type: "int", nullable: false),
                    DocTypeAraName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocTypeLatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonActive = table.Column<bool>(type: "bit", nullable: true),
                    DefaultAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultRead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultWrite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_850DocType", x => new { x.Kind, x.DocTypeCode });
                });

            migrationBuilder.CreateTable(
                name: "SubLdgType",
                columns: table => new
                {
                    SubLdgTypeCode = table.Column<int>(type: "int", nullable: false),
                    SubLdgTypeAraName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubLdgTypeLatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotActive = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLdgType", x => x.SubLdgTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "M_850DocTypeSubLdgTypes",
                columns: table => new
                {
                    Serial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    DocTypeCode = table.Column<int>(type: "int", nullable: false),
                    SubLdgTypeCode = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_850DocTypeSubLdgTypes", x => x.Serial);
                    table.ForeignKey(
                        name: "FK_M_850DocTypeSubLdgTypes_M_850DocType_Kind_DocTypeCode",
                        columns: x => new { x.Kind, x.DocTypeCode },
                        principalTable: "M_850DocType",
                        principalColumns: new[] { "Kind", "DocTypeCode" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_M_850DocTypeSubLdgTypes_SubLdgType_SubLdgTypeCode",
                        column: x => x.SubLdgTypeCode,
                        principalTable: "SubLdgType",
                        principalColumn: "SubLdgTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_850DocTypeSubLdgTypes_Kind_DocTypeCode",
                table: "M_850DocTypeSubLdgTypes",
                columns: new[] { "Kind", "DocTypeCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_M_850DocTypeSubLdgTypes_SubLdgTypeCode",
                table: "M_850DocTypeSubLdgTypes",
                column: "SubLdgTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Company_CompanyCode",
                table: "Branch",
                column: "CompanyCode",
                principalTable: "Company",
                principalColumn: "CompanyCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Company_CompanyCode",
                table: "Branch");

            migrationBuilder.DropTable(
                name: "M_850DocTypeSubLdgTypes");

            migrationBuilder.DropTable(
                name: "M_850DocType");

            migrationBuilder.DropTable(
                name: "SubLdgType");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Company_CompanyCode",
                table: "Branch",
                column: "CompanyCode",
                principalTable: "Company",
                principalColumn: "CompanyCode");
        }
    }
}
