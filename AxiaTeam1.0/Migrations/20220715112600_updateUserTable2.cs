using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AxiaTeam1._0.Migrations
{
    public partial class updateUserTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
