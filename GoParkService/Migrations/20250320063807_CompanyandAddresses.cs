using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoParkService.Migrations
{
    /// <inheritdoc />
    public partial class CompanyandAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrimaryContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrimaryEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId3 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Company_CompanyId2",
                        column: x => x.CompanyId2,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Company_CompanyId3",
                        column: x => x.CompanyId3,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId1",
                table: "Address",
                column: "CompanyId1",
                unique: true,
                filter: "[CompanyId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId2",
                table: "Address",
                column: "CompanyId2",
                unique: true,
                filter: "[CompanyId2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId3",
                table: "Address",
                column: "CompanyId3",
                unique: true,
                filter: "[CompanyId3] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
