using System.ComponentModel.DataAnnotations;

public class Participer
{
    [Key]
    public int Id_Utilisateur { get; set; }
    public required Utilisateur Utilisateur { get; set; }
    public int Id_Tache { get; set; }
    public required Tache Tache { get; set; }
    public int Id_Projet { get; set; }
    public required Projet Projet { get; set; }
}