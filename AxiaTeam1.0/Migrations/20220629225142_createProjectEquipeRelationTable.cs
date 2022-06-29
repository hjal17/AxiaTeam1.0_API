using Microsoft.EntityFrameworkCore.Migrations;

namespace AxiaTeam1._0.Migrations
{
    public partial class createProjectEquipeRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Projects",
                nullable: true,
                defaultValue: 0);
                
            migrationBuilder.CreateIndex(
                name: "IX_Projects_EquipeId",
                table: "Projects",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_equipes_EquipeId",
                table: "Projects",
                column: "EquipeId",
                principalTable: "equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_equipes_EquipeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EquipeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Projects");
        }
    }
}
