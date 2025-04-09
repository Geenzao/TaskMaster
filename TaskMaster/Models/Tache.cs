public class Tache
{
    public int Id_Tache { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateEcheance { get; set; }
    public string Statut { get; set; }
    public string Priorite { get; set; }
    public string Categorie { get; set; }
    public string Etiquette { get; set; }
    public int Id_Utilisateur { get; set; }
    public Utilisateur Utilisateur { get; set; }
}