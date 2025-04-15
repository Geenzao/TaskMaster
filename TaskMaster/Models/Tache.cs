using System.ComponentModel.DataAnnotations;

public class Tache
{
    [Key]
    public int Id_Tache { get; set; }
    public required string Titre { get; set; }
    public required string Description { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateEcheance { get; set; }
    public required string Statut { get; set; }
    public required string Priorite { get; set; }
    public required string Categorie { get; set; }
    public required string Etiquette { get; set; }
    public int Id_Utilisateur { get; set; }
}