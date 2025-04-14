using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Id_Utilisateur), nameof(Id_Tache), nameof(Id_Projet))]
public class Participer
{
    public int Id_Utilisateur { get; set; }
    public int? Id_Tache { get; set; }
    public int Id_Projet { get; set; }
}