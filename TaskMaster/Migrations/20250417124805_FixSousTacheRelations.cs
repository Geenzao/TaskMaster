using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class FixSousTacheRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousTaches_Taches_TacheId_Tache",
                table: "SousTaches");

            migrationBuilder.DropForeignKey(
                name: "FK_SousTaches_Utilisateurs_UtilisateurId_Utilisateur",
                table: "SousTaches");

            migrationBuilder.DropIndex(
                name: "IX_SousTaches_TacheId_Tache",
                table: "SousTaches");

            migrationBuilder.DropIndex(
                name: "IX_SousTaches_UtilisateurId_Utilisateur",
                table: "SousTaches");

            migrationBuilder.DropColumn(
                name: "TacheId_Tache",
                table: "SousTaches");

            migrationBuilder.DropColumn(
                name: "UtilisateurId_Utilisateur",
                table: "SousTaches");

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_Id_Tache",
                table: "SousTaches",
                column: "Id_Tache");

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_Id_Utilisateur",
                table: "SousTaches",
                column: "Id_Utilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_SousTaches_Taches_Id_Tache",
                table: "SousTaches",
                column: "Id_Tache",
                principalTable: "Taches",
                principalColumn: "Id_Tache",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SousTaches_Utilisateurs_Id_Utilisateur",
                table: "SousTaches",
                column: "Id_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id_Utilisateur",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousTaches_Taches_Id_Tache",
                table: "SousTaches");

            migrationBuilder.DropForeignKey(
                name: "FK_SousTaches_Utilisateurs_Id_Utilisateur",
                table: "SousTaches");

            migrationBuilder.DropIndex(
                name: "IX_SousTaches_Id_Tache",
                table: "SousTaches");

            migrationBuilder.DropIndex(
                name: "IX_SousTaches_Id_Utilisateur",
                table: "SousTaches");

            migrationBuilder.AddColumn<int>(
                name: "TacheId_Tache",
                table: "SousTaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId_Utilisateur",
                table: "SousTaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_TacheId_Tache",
                table: "SousTaches",
                column: "TacheId_Tache");

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_UtilisateurId_Utilisateur",
                table: "SousTaches",
                column: "UtilisateurId_Utilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_SousTaches_Taches_TacheId_Tache",
                table: "SousTaches",
                column: "TacheId_Tache",
                principalTable: "Taches",
                principalColumn: "Id_Tache",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SousTaches_Utilisateurs_UtilisateurId_Utilisateur",
                table: "SousTaches",
                column: "UtilisateurId_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id_Utilisateur",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
