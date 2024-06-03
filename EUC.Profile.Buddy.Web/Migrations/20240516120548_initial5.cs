using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EUC.Profile.Buddy.Web.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileDirectory",
                table: "UserProfileSummary",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "TempSize",
                table: "UserProfileSummary",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileDirectory",
                table: "UserProfileSummary");

            migrationBuilder.DropColumn(
                name: "TempSize",
                table: "UserProfileSummary");
        }
    }
}
