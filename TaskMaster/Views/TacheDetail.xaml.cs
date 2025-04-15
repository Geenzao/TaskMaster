using Microsoft.Maui.Controls;
using TaskMaster.Models;
using TaskMaster.Services;
using System.Diagnostics;

namespace TaskMaster.Views;

public partial class TacheDetail : ContentPage
{
    private readonly ITacheService _tacheService;
    public Tache Tache { get; private set; }

    // Événement pour notifier de la suppression d'une tâche
    public event EventHandler<int> TacheDeleted;

    public TacheDetail(Tache tache, ITacheService tacheService)
    {
        InitializeComponent();
        _tacheService = tacheService;
        
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
            try
            {
                await _tacheService.DeleteTacheAsync(Tache.Id_Tache);
                await DisplayAlert("Succès", "La tâche a été supprimée avec succès", "OK");
                
                // Déclencher l'événement de suppression
                TacheDeleted?.Invoke(this, Tache.Id_Tache);
                
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Erreur", "Impossible de supprimer la tâche", "OK");
            }
        }
    }
}