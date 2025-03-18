using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoParkService.Migrations
{
    /// <inheritdoc />
    public partial class TenantId_added_in_applicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "User");
        }
    }
}
