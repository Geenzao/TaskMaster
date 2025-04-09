using System.ComponentModel.DataAnnotations;

public class Utilisateur
{
    [Key]
    public int Id_Utilisateur { get; set; }
    public required string Nom { get; set; }
    public required string Prenom { get; set; }
    public required string Email { get; set; }
    public required string MotDePasse { get; set; }
}