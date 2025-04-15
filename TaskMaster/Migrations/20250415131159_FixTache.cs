using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class FixTache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Utilisateurs_UtilisateurId_Utilisateur",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_UtilisateurId_Utilisateur",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "UtilisateurId_Utilisateur",
                table: "Taches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId_Utilisateur",
                table: "Taches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taches_UtilisateurId_Utilisateur",
                table: "Taches",
                column: "UtilisateurId_Utilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Utilisateurs_UtilisateurId_Utilisateur",
                table: "Taches",
                column: "UtilisateurId_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id_Utilisateur",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
