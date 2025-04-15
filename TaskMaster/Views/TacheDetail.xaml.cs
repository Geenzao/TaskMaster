using Microsoft.Maui.Controls;
using TaskMaster.Models;
using System.Diagnostics;

namespace TaskMaster.Views;

public partial class TacheDetail : ContentPage
{
    public Tache Tache { get; private set; }

    public TacheDetail(Tache tache)
    {
        InitializeComponent();
        
        // Vérification de la tâche pour débogage
        if (tache == null)
        {
            Debug.WriteLine("Erreur: La tâche transmise est null!");
            DisplayAlert("Erreur", "Impossible de charger les détails de la tâche", "OK");
        }
        
        // Assignation de la tâche et du contexte de binding
        Tache = tache;
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        // Forcer le rafraîchissement de l'interface
        OnPropertyChanged(nameof(Tache));
    }

    private void OnModifierClicked(object sender, EventArgs e)
    {
        DisplayAlert("Modification", "Fonctionnalité à implémenter", "OK");
    }

    private async void OnSupprimerClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Supprimer", "Êtes-vous sûr de vouloir supprimer cette tâche ?", "Oui", "Non");
        if (confirm)
        {
            await Navigation.PopAsync();
        }
    }
}