using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EUC.Profile.Buddy.Web.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    TaskName = table.Column<string>(type: "TEXT", nullable: true),
                    TaskExecuted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TaskState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInformation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskInformation");
        }
    }
}
