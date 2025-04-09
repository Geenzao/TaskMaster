using System.ComponentModel.DataAnnotations;

public class Historique
{
    [Key]
    public int Id_Historique { get; set; }
    public required string Description { get; set; }
    public required string AncienneValeur { get; set; }
    public required string NouvelleValeur { get; set; }
    public DateTime DateModification { get; set; }
    public int Id_Tache { get; set; }
    public required Tache Tache { get; set; }
}