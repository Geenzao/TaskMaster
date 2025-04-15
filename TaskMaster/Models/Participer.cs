using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Models
{
    [PrimaryKey(nameof(Id_Utilisateur), nameof(Id_Projet), nameof(Id_Tache))]
    public class Participer
    {
        public int Id_Utilisateur { get; set; }
        public int Id_Projet { get; set; }
        public int Id_Tache { get; set; }
    }
}