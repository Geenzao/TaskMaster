using System.ComponentModel.DataAnnotations;

public class SousTache
{
    [Key]
    public int Id_SousTache { get; set; }
    public required string Titre { get; set; }
    public required string Statut { get; set; }
    public DateTime DateEcheance { get; set; }
    public int Id_Tache { get; set; }
    public required Tache Tache { get; set; }
    public int Id_Utilisateur { get; set; }
    public required Utilisateur Utilisateur { get; set; }
}