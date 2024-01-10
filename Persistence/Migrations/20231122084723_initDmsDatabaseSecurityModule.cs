using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initDmsDatabaseSecurityModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypeUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionTypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypeUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryphoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustCode = table.Column<int>(type: "int", nullable: false),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustLatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustLatAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicCurrencyCode = table.Column<int>(type: "int", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotActive = table.Column<bool>(type: "bit", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryISO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustCode);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSetups",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailApi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailPort = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSetups", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermission",
                columns: table => new
                {
                    GroupCode = table.Column<int>(type: "int", nullable: false),
                    ProgId = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Insert = table.Column<bool>(type: "bit", nullable: true),
                    Edit = table.Column<bool>(type: "bit", nullable: true),
                    Read = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true),
                    Print = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermission", x => new { x.GroupCode, x.ProgId });
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GroupLatName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "PrgPer",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProgId = table.Column<decimal>(type: "decimal(18,0)", nullable: false, comment: "كود الشاشة"),
                    Insert = table.Column<bool>(type: "bit", nullable: true, comment: "صلاحية إدخال بيانات"),
                    Edit = table.Column<bool>(type: "bit", nullable: true, comment: "صلاحية تعديل بيانات"),
                    Read = table.Column<bool>(type: "bit", nullable: true, comment: "صلاحية قراءة بيانات"),
                    Delete = table.Column<bool>(type: "bit", nullable: true, comment: "صلاحية حذف بيانات"),
                    Print = table.Column<bool>(type: "bit", nullable: true, comment: "صلاحية الطباعة")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrgPer", x => new { x.UserId, x.ProgId });
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgId = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ParentID = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ArabicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Parameters = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    URL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HaveInsert = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    HaveEdit = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    HaveRead = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    HaveDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    HavePrint = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgId);
                });

            migrationBuilder.CreateTable(
                name: "UsersLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: true),
                    IPaddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    DayCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayLatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.DayCode);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => new { x.CountryCode, x.CityCode });
                    table.ForeignKey(
                        name: "FK_Citys_Countrys_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countrys",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "Date", nullable: true),
                    Mobile1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: true),
                    NotActive = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSolt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    PhotoUserPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approval = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDateAndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VerificationCodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VerificationCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_UserId",
                table: "VerificationCodes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionTypeUser");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "GeneralSetups");

            migrationBuilder.DropTable(
                name: "GroupPermission");

            migrationBuilder.DropTable(
                name: "PrgPer");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "UsersLog");

            migrationBuilder.DropTable(
                name: "VerificationCodes");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "Countrys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
