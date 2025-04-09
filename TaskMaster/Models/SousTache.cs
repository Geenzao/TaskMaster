public class SousTache
{
    public int Id_SousTache { get; set; }
    public string Titre { get; set; }
    public string Statut { get; set; }
    public DateTime DateEcheance { get; set; }
    public int Id_Tache { get; set; }
    public Tache Tache { get; set; }
    public int Id_Utilisateur { get; set; }
    public Utilisateur Utilisateur { get; set; }
}