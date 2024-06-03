using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EUC.Profile.Buddy.Web.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "TaskRunTime",
                table: "TaskInformation",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskRunTime",
                table: "TaskInformation");
        }
    }
}
