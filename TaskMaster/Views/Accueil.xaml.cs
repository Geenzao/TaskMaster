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
            new Projet { Nom = "Projet 1", Description = "Description du projet 1" },
            new Projet { Nom = "Projet 2", Description = "Description du projet 2" },
            new Projet { Nom = "Projet 3", Description = "Description du projet 3" }
        };

        BindingContext = this;
    }

    private async void OnDeconnexionClicked(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Info", "Vous avez été déconnecté !", "OK");
        await Shell.Current.GoToAsync("//Connexion");
    }
}
