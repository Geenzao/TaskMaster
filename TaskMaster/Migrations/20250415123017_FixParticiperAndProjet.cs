using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class FixParticiperAndProjet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participers",
                table: "Participers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participers",
                table: "Participers",
                columns: new[] { "Id_Utilisateur", "Id_Projet", "Id_Tache" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participers",
                table: "Participers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participers",
                table: "Participers",
                columns: new[] { "Id_Utilisateur", "Id_Tache", "Id_Projet" });
        }
    }
}
