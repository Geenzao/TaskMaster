using Microsoft.Maui.Controls;
using TaskMaster.Models;
using System.Collections.ObjectModel;

namespace TaskMaster.Views;

public partial class Accueil : ContentPage
{
    public ObservableCollection<Projet> Projets { get; set; }

    public Accueil()
    {
        InitializeComponent();

        // Simuler la récupération des projets depuis le back
        Projets = new ObservableCollection<Projet>
        {
            new Projet 
            { 
                Nom = "Projet 1", 
                Description = "Description du projet 1",
                Taches = new List<Tache>
                {
                    new Tache 
                    { 
                        Id_Tache = 1,
                        Titre = "Tâche 1", 
                        Description = "Description de la tâche 1", 
                        DateCreation = DateTime.Now,
                        DateEcheance = DateTime.Now.AddDays(7), 
                        Statut = "En cours",
                        Priorite = "Haute",
                        Categorie = "Catégorie1",
                        Etiquette = "Urgent",
                        Id_Utilisateur = 1,
                        Utilisateur = new Utilisateur 
                        { 
                            Id_Utilisateur = 1, 
                            Nom = "Utilisateur1", 
                            Prenom = "Prenom1", 
                            Email = "utilisateur1@example.com", 
                            MotDePasse = "motdepasse1" 
                        }
                    },
                    new Tache 
                    { 
                        Id_Tache = 2,
                        Titre = "Tâche 2", 
                        Description = "Description de la tâche 2", 
                        DateCreation = DateTime.Now,
                        DateEcheance = DateTime.Now.AddDays(14), 
                        Statut = "À faire",
                        Priorite = "Moyenne",
                        Categorie = "Catégorie2",
                        Etiquette = "Normal",
                        Id_Utilisateur = 2,
                        Utilisateur = new Utilisateur 
                        { 
                            Id_Utilisateur = 2, 
                            Nom = "Utilisateur2", 
                            Prenom = "Prenom2", 
                            Email = "utilisateur2@example.com", 
                            MotDePasse = "motdepasse2" 
                        }
                    },
                    new Tache 
                    { 
                        Id_Tache = 3,
                        Titre = "Tâche 3", 
                        Description = "Description de la tâche 3", 
                        DateCreation = DateTime.Now,
                        DateEcheance = DateTime.Now.AddDays(21), 
                        Statut = "Terminé",
                        Priorite = "Basse",
                        Categorie = "Catégorie3",
                        Etiquette = "Non urgent",
                        Id_Utilisateur = 3,
                        Utilisateur = new Utilisateur 
                        { 
                            Id_Utilisateur = 3, 
                            Nom = "Utilisateur3", 
                            Prenom = "Prenom3", 
                            Email = "utilisateur3@example.com", 
                            MotDePasse = "motdepasse3" 
                        }
                    }
                }
            },
            new Projet 
            { 
                Nom = "Projet 2", 
                Description = "Description du projet 2",
                Taches = new List<Tache>
                {
                    new Tache 
                    { 
                        Id_Tache = 4,
                        Titre = "Tâche 1", 
                        Description = "Description de la tâche 1", 
                        DateCreation = DateTime.Now,
                        DateEcheance = DateTime.Now.AddDays(5), 
                        Statut = "En cours",
                        Priorite = "Haute",
                        Categorie = "Catégorie1",
                        Etiquette = "Urgent",
                        Id_Utilisateur = 1,
                        Utilisateur = new Utilisateur 
                        { 
                            Id_Utilisateur = 1, 
                            Nom = "Utilisateur1", 
                            Prenom = "Prenom1", 
                            Email = "utilisateur1@example.com", 
                            MotDePasse = "motdepasse1" 
                        }
                    },
                    new Tache 
                    { 
                        Id_Tache = 5,
                        Titre = "Tâche 2", 
                        Description = "Description de la tâche 2", 
                        DateCreation = DateTime.Now,
                        DateEcheance = DateTime.Now.AddDays(10), 
                        Statut = "À faire",
                        Priorite = "Moyenne",
                        Categorie = "Catégorie2",
                        Etiquette = "Normal",
                        Id_Utilisateur = 2,
                        Utilisateur = new Utilisateur 
                        { 
                            Id_Utilisateur = 2, 
                            Nom = "Utilisateur2", 
                            Prenom = "Prenom2", 
                            Email = "utilisateur2@example.com", 
                            MotDePasse = "motdepasse2" 
                        }
                    }
                }
            },
            new Projet 
            { 
                Nom = "Projet 3", 
                Description = "Description du projet 3",
                Taches = new List<Tache>
                {
                    new Tache 
                    { 
                        Id_Tache = 6,
                        Titre = "Tâche 1", 
                        Description = "Description de la tâche 1", 
                        DateCreation = DateTime.Now,
                        DateEcheance = DateTime.Now.AddDays(3), 
                        Statut = "Terminé",
                        Priorite = "Basse",
                        Categorie = "Catégorie3",
                        Etiquette = "Non urgent",
                        Id_Utilisateur = 3,
                        Utilisateur = new Utilisateur 
                        { 
                            Id_Utilisateur = 3, 
                            Nom = "Utilisateur3", 
                            Prenom = "Prenom3", 
                            Email = "utilisateur3@example.com", 
                            MotDePasse = "motdepasse3" 
                        }
                    }
                }
            }
        };

        BindingContext = this;
    }

    private async void OnDeconnexionClicked(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Info", "Vous avez été déconnecté !", "OK");
        await Shell.Current.GoToAsync("//Connexion");
    }
}
