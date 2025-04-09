public class Commentaires
{
    public int Id_Commentaires { get; set; }
    public DateTime DateCreation { get; set; }
    public string Contenu { get; set; }
    public int Id_Tache { get; set; }
    public Tache Tache { get; set; }
    public int Id_Utilisateur { get; set; }
    public Utilisateur Utilisateur { get; set; }
}