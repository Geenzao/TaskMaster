public class Historique
{
    public int Id_Historique { get; set; }
    public string Description { get; set; }
    public string AncienneValeur { get; set; }
    public string NouvelleValeur { get; set; }
    public DateTime DateModification { get; set; }
    public int Id_Tache { get; set; }
    public Tache Tache { get; set; }
}