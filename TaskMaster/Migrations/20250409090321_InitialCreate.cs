using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id_Projet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id_Projet);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id_Utilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotDePasse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id_Utilisateur);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    Id_Tache = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Statut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Priorite = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categorie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Etiquette = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_Utilisateur = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId_Utilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.Id_Tache);
                    table.ForeignKey(
                        name: "FK_Taches_Utilisateurs_UtilisateurId_Utilisateur",
                        column: x => x.UtilisateurId_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id_Utilisateur",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id_Commentaires = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Contenu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_Tache = table.Column<int>(type: "int", nullable: false),
                    TacheId_Tache = table.Column<int>(type: "int", nullable: false),
                    Id_Utilisateur = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId_Utilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id_Commentaires);
                    table.ForeignKey(
                        name: "FK_Commentaires_Taches_TacheId_Tache",
                        column: x => x.TacheId_Tache,
                        principalTable: "Taches",
                        principalColumn: "Id_Tache",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Utilisateurs_UtilisateurId_Utilisateur",
                        column: x => x.UtilisateurId_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id_Utilisateur",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    Id_Historique = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AncienneValeur = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NouvelleValeur = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id_Tache = table.Column<int>(type: "int", nullable: false),
                    TacheId_Tache = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.Id_Historique);
                    table.ForeignKey(
                        name: "FK_Historiques_Taches_TacheId_Tache",
                        column: x => x.TacheId_Tache,
                        principalTable: "Taches",
                        principalColumn: "Id_Tache",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participers",
                columns: table => new
                {
                    Id_Utilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UtilisateurId_Utilisateur = table.Column<int>(type: "int", nullable: false),
                    Id_Tache = table.Column<int>(type: "int", nullable: false),
                    TacheId_Tache = table.Column<int>(type: "int", nullable: false),
                    Id_Projet = table.Column<int>(type: "int", nullable: false),
                    ProjetId_Projet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participers", x => x.Id_Utilisateur);
                    table.ForeignKey(
                        name: "FK_Participers_Projets_ProjetId_Projet",
                        column: x => x.ProjetId_Projet,
                        principalTable: "Projets",
                        principalColumn: "Id_Projet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participers_Taches_TacheId_Tache",
                        column: x => x.TacheId_Tache,
                        principalTable: "Taches",
                        principalColumn: "Id_Tache",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participers_Utilisateurs_UtilisateurId_Utilisateur",
                        column: x => x.UtilisateurId_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id_Utilisateur",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SousTaches",
                columns: table => new
                {
                    Id_SousTache = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Statut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateEcheance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id_Tache = table.Column<int>(type: "int", nullable: false),
                    TacheId_Tache = table.Column<int>(type: "int", nullable: false),
                    Id_Utilisateur = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId_Utilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousTaches", x => x.Id_SousTache);
                    table.ForeignKey(
                        name: "FK_SousTaches_Taches_TacheId_Tache",
                        column: x => x.TacheId_Tache,
                        principalTable: "Taches",
                        principalColumn: "Id_Tache",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SousTaches_Utilisateurs_UtilisateurId_Utilisateur",
                        column: x => x.UtilisateurId_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id_Utilisateur",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_TacheId_Tache",
                table: "Commentaires",
                column: "TacheId_Tache");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_UtilisateurId_Utilisateur",
                table: "Commentaires",
                column: "UtilisateurId_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_TacheId_Tache",
                table: "Historiques",
                column: "TacheId_Tache");

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

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_TacheId_Tache",
                table: "SousTaches",
                column: "TacheId_Tache");

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_UtilisateurId_Utilisateur",
                table: "SousTaches",
                column: "UtilisateurId_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_UtilisateurId_Utilisateur",
                table: "Taches",
                column: "UtilisateurId_Utilisateur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Participers");

            migrationBuilder.DropTable(
                name: "SousTaches");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "Taches");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
