using Microsoft.EntityFrameworkCore.Migrations;

namespace AxiaTeam1._0.Migrations
{
    public partial class updateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStoryId",
                table: "Taches",
                nullable: false,
                defaultValue: 0);

         

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "BackLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taches_UserStoryId",
                table: "Taches",
                column: "UserStoryId");


            migrationBuilder.CreateIndex(
                name: "IX_BackLogs_ProjectId",
                table: "BackLogs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackLogs_Projects_ProjectId",
                table: "BackLogs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

           

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_UserStorys_UserStoryId",
                table: "Taches",
                column: "UserStoryId",
                principalTable: "UserStorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackLogs_Projects_ProjectId",
                table: "BackLogs");

         

            migrationBuilder.DropForeignKey(
                name: "FK_Taches_UserStorys_UserStoryId",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_UserStoryId",
                table: "Taches");

     

            migrationBuilder.DropIndex(
                name: "IX_BackLogs_ProjectId",
                table: "BackLogs");

            migrationBuilder.DropColumn(
                name: "UserStoryId",
                table: "Taches");


            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "BackLogs");
        }
    }
}
