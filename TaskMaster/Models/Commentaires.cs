using System.ComponentModel.DataAnnotations;

public class Commentaires
{
    [Key]
    public int Id_Commentaires { get; set; }
    public DateTime DateCreation { get; set; }
    public required string Contenu { get; set; }
    public int Id_Tache { get; set; }
    public required Tache Tache { get; set; }
    public int Id_Utilisateur { get; set; }
    public required Utilisateur Utilisateur { get; set; }
}