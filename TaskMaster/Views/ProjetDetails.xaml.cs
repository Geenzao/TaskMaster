using Microsoft.Maui.Controls;
using TaskMaster.Models;
using System.Diagnostics;

namespace TaskMaster.Views;

public partial class ProjetDetail : ContentPage
{
    public ProjetDetail()
    {
        InitializeComponent();
    }

    private async void OnTacheTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Tache tache)
        {
            try
            {
                // Vérification que la tâche est bien initialisée
                Debug.WriteLine($"Navigation vers la tâche: {tache.Titre}");
                
                // Navigation vers la page de détails
                await Navigation.PushAsync(new TacheDetail(tache));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la navigation: {ex.Message}");
                await DisplayAlert("Erreur", "Impossible d'afficher les détails de la tâche", "OK");
            }
        }
    }
}
