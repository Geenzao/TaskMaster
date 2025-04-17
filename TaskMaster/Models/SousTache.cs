using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SousTache
{
    [Key]
    public int Id_SousTache { get; set; }
    public required string Titre { get; set; }
    public required string Statut { get; set; }
    public DateTime DateEcheance { get; set; }
    
    [ForeignKey("Tache")]
    public int Id_Tache { get; set; }
    public virtual Tache Tache { get; set; }
    
    [ForeignKey("Utilisateur")]
    public int Id_Utilisateur { get; set; }
    public virtual Utilisateur Utilisateur { get; set; }
}