using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        ID = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmpID = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
            //        FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        MiddleName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        LastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        CertificateDOB = table.Column<DateTime>(type: "date", nullable: false),
            //        ActualBOD = table.Column<DateTime>(type: "date", nullable: true),
            //        DOJ = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Gender = table.Column<byte>(type: "tinyint", nullable: false),
            //        ReportingManagerid = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
            //        OfficeLocation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false),
            //        CompanyEmailId = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        PersonalEmailId = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        SeperatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        MaritalStatus = table.Column<byte>(type: "tinyint", nullable: false),
            //        CreatedBy = table.Column<long>(type: "bigint", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
            //        ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.ID);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Address",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeId = table.Column<long>(type: "bigint", nullable: false),
            //        Type = table.Column<bool>(type: "bit", nullable: false),
            //        Line1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Line2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        City = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Zipcode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedBy = table.Column<long>(type: "bigint", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
            //        ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Address", x => x.id);
            //        table.ForeignKey(
            //            name: "FK__Address__Employe__56B3DD81",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employee",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contact",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeId = table.Column<long>(type: "bigint", nullable: false),
            //        MobileCountryCode = table.Column<byte>(type: "tinyint", nullable: false),
            //        Mobile = table.Column<long>(type: "bigint", nullable: false),
            //        AlternateMobileCountryCode = table.Column<byte>(type: "tinyint", nullable: true),
            //        AlternateMobile = table.Column<long>(type: "bigint", nullable: true),
            //        WorkNumberCountryCode = table.Column<byte>(type: "tinyint", nullable: true),
            //        WorkNumber = table.Column<long>(type: "bigint", nullable: true),
            //        WorkExtension = table.Column<byte>(type: "tinyint", nullable: true),
            //        HomeCountryCode = table.Column<byte>(type: "tinyint", nullable: true),
            //        HomeNumber = table.Column<long>(type: "bigint", nullable: true),
            //        HomeExtension = table.Column<byte>(type: "tinyint", nullable: true),
            //        CompanyMobileCountryCode = table.Column<byte>(type: "tinyint", nullable: true),
            //        CompanyMobile = table.Column<long>(type: "bigint", nullable: true),
            //        Active = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedBy = table.Column<long>(type: "bigint", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
            //        ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contact", x => x.id);
            //        table.ForeignKey(
            //            name: "FK__Contact__Employe__59904A2C",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employee",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_EmployeeId",
                table: "Contact",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
