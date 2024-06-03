using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EUC.Profile.Buddy.Web.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileSummaries",
                table: "UserProfileSummaries");

            migrationBuilder.RenameTable(
                name: "UserProfileSummaries",
                newName: "UserProfileSummary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileSummary",
                table: "UserProfileSummary",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileSummary",
                table: "UserProfileSummary");

            migrationBuilder.RenameTable(
                name: "UserProfileSummary",
                newName: "UserProfileSummaries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileSummaries",
                table: "UserProfileSummaries",
                column: "Id");
        }
    }
}
