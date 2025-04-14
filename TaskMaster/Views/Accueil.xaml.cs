using Microsoft.Maui.Controls;
using TaskMaster.Models;
using System.Collections.ObjectModel;
using TaskMaster.Services;

namespace TaskMaster.Views;

public partial class Accueil : ContentPage
{
    private readonly ISessionService _sessionService;

    public ObservableCollection<Projet> Projets { get; set; }

    public Accueil(ISessionService sessionService)
    {
        InitializeComponent();
        _sessionService = sessionService;

        // Simuler la récupération des projets depuis le back
        Projets = new ObservableCollection<Projet>
        {
           
        };

        BindingContext = this;
    }

    private async void OnDeconnexionClicked(object sender, EventArgs e)
    {
        _sessionService.ClearSession();
        await Shell.Current.DisplayAlert("Info", "Vous avez été déconnecté !", "OK");
        await Shell.Current.GoToAsync("//Connexion");
    }
}
