using Microsoft.EntityFrameworkCore.Migrations;

namespace AxiaTeam1._0.Migrations
{
    public partial class createEmployeeEquipeTableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeEquipes_Equipe_EquipeId",
                table: "employeeEquipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipe",
                table: "Equipe");

            migrationBuilder.RenameTable(
                name: "Equipe",
                newName: "equipes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_equipes",
                table: "equipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeEquipes_equipes_EquipeId",
                table: "employeeEquipes",
                column: "EquipeId",
                principalTable: "equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeEquipes_equipes_EquipeId",
                table: "employeeEquipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_equipes",
                table: "equipes");

            migrationBuilder.RenameTable(
                name: "equipes",
                newName: "Equipe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipe",
                table: "Equipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeEquipes_Equipe_EquipeId",
                table: "employeeEquipes",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
