public class Participer
{
    public int Id_Utilisateur { get; set; }
    public Utilisateur Utilisateur { get; set; }
    public int Id_Tache { get; set; }
    public Tache Tache { get; set; }
    public int Id_Projet { get; set; }
    public Projet Projet { get; set; }
}