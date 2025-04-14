using System.ComponentModel.DataAnnotations;

public class Projet
{
    [Key]
    public int Id_Projet { get; set; }
    public required string Nom { get; set; }
    public required string Description { get; set; }
    public List<Tache> Taches { get; set; } = new List<Tache>();
}