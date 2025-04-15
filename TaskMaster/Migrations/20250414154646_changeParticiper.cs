using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class changeParticiper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participers_Projets_ProjetId_Projet",
                table: "Participers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participers_Taches_TacheId_Tache",
                table: "Participers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participers_Utilisateurs_UtilisateurId_Utilisateur",
                table: "Participers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participers",
                table: "Participers");

            migrationBuilder.DropIndex(
                name: "IX_Participers_ProjetId_Projet",
                table: "Participers");

            migrationBuilder.DropIndex(
                name: "IX_Participers_TacheId_Tache",
                table: "Participers");

            migrationBuilder.DropIndex(
                name: "IX_Participers_UtilisateurId_Utilisateur",
                table: "Participers");

            migrationBuilder.DropColumn(
                name: "ProjetId_Projet",
                table: "Participers");

            migrationBuilder.DropColumn(
                name: "TacheId_Tache",
                table: "Participers");

            migrationBuilder.DropColumn(
                name: "UtilisateurId_Utilisateur",
                table: "Participers");

            migrationBuilder.AddColumn<int>(
                name: "ProjetId_Projet",
                table: "Taches",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Utilisateur",
                table: "Participers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participers",
                table: "Participers",
                columns: new[] { "Id_Utilisateur", "Id_Tache", "Id_Projet" });

            migrationBuilder.CreateIndex(
                name: "IX_Taches_ProjetId_Projet",
                table: "Taches",
                column: "ProjetId_Projet");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Projets_ProjetId_Projet",
                table: "Taches",
                column: "ProjetId_Projet",
                principalTable: "Projets",
                principalColumn: "Id_Projet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Projets_ProjetId_Projet",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_ProjetId_Projet",
                table: "Taches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participers",
                table: "Participers");

            migrationBuilder.DropColumn(
                name: "ProjetId_Projet",
                table: "Taches");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Utilisateur",
                table: "Participers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProjetId_Projet",
                table: "Participers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TacheId_Tache",
                table: "Participers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId_Utilisateur",
                table: "Participers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participers",
                table: "Participers",
                column: "Id_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Participers_ProjetId_Projet",
                table: "Participers",
                column: "ProjetId_Projet");

            migrationBuilder.CreateIndex(
                name: "IX_Participers_TacheId_Tache",
                table: "Participers",
                column: "TacheId_Tache");

            migrationBuilder.CreateIndex(
                name: "IX_Participers_UtilisateurId_Utilisateur",
                table: "Participers",
                column: "UtilisateurId_Utilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_Participers_Projets_ProjetId_Projet",
                table: "Participers",
                column: "ProjetId_Projet",
                principalTable: "Projets",
                principalColumn: "Id_Projet",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participers_Taches_TacheId_Tache",
                table: "Participers",
                column: "TacheId_Tache",
                principalTable: "Taches",
                principalColumn: "Id_Tache",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participers_Utilisateurs_UtilisateurId_Utilisateur",
                table: "Participers",
                column: "UtilisateurId_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id_Utilisateur",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
