using Microsoft.EntityFrameworkCore.Migrations;

namespace AxiaTeam1._0.Migrations
{
    public partial class createTacheaFaitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TacheAFait_Users_UserId",
                table: "TacheAFait");

            migrationBuilder.DropForeignKey(
                name: "FK_TacheAFait_Taches_tacheId",
                table: "TacheAFait");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TacheAFait",
                table: "TacheAFait");

            migrationBuilder.DropColumn(
                name: "developerId",
                table: "TacheAFait");

            migrationBuilder.RenameTable(
                name: "TacheAFait",
                newName: "tacheAFaits");

            migrationBuilder.RenameIndex(
                name: "IX_TacheAFait_tacheId",
                table: "tacheAFaits",
                newName: "IX_tacheAFaits_tacheId");

            migrationBuilder.RenameIndex(
                name: "IX_TacheAFait_UserId",
                table: "tacheAFaits",
                newName: "IX_tacheAFaits_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "tacheAFaits",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tacheAFaits",
                table: "tacheAFaits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tacheAFaits_Users_UserId",
                table: "tacheAFaits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tacheAFaits_Taches_tacheId",
                table: "tacheAFaits",
                column: "tacheId",
                principalTable: "Taches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tacheAFaits_Users_UserId",
                table: "tacheAFaits");

            migrationBuilder.DropForeignKey(
                name: "FK_tacheAFaits_Taches_tacheId",
                table: "tacheAFaits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tacheAFaits",
                table: "tacheAFaits");

            migrationBuilder.RenameTable(
                name: "tacheAFaits",
                newName: "TacheAFait");

            migrationBuilder.RenameIndex(
                name: "IX_tacheAFaits_tacheId",
                table: "TacheAFait",
                newName: "IX_TacheAFait_tacheId");

            migrationBuilder.RenameIndex(
                name: "IX_tacheAFaits_UserId",
                table: "TacheAFait",
                newName: "IX_TacheAFait_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TacheAFait",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "developerId",
                table: "TacheAFait",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TacheAFait",
                table: "TacheAFait",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TacheAFait_Users_UserId",
                table: "TacheAFait",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TacheAFait_Taches_tacheId",
                table: "TacheAFait",
                column: "tacheId",
                principalTable: "Taches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
