using Microsoft.EntityFrameworkCore.Migrations;

namespace AxiaTeam1._0.Migrations
{
    public partial class updateEquipeProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_equipes_EquipeId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_equipes_EquipeId",
                table: "Projects",
                column: "EquipeId",
                principalTable: "equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_equipes_EquipeId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_equipes_EquipeId",
                table: "Projects",
                column: "EquipeId",
                principalTable: "equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
