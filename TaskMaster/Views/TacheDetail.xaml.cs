using Microsoft.Maui.Controls;
using TaskMaster.Models;
using TaskMaster.Services;
using TaskMaster.ViewModels;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace TaskMaster.Views;

public partial class TacheDetail : ContentPage
{
    private readonly ITacheService _tacheService;
    private readonly TacheDetailViewModel _viewModel;

    // Événement pour notifier de la suppression d'une tâche
    public event EventHandler<int> TacheDeleted;
    // Événement pour notifier de la modification d'une tâche
    public event EventHandler<Tache> TacheModified;

    public TacheDetail(Tache tache, ITacheService tacheService)
    {
        InitializeComponent();
        _tacheService = tacheService;
        
        // Vérification de la tâche pour débogage
        if (tache == null)
        {
            Debug.WriteLine("Erreur: La tâche transmise est null!");
            DisplayAlert("Erreur", "Impossible de charger les détails de la tâche", "OK");
            return;
        }
        
        // Création du ViewModel et assignation du contexte de binding
        var services = Application.Current.Handler.MauiContext.Services;
        var sousTacheService = services.GetRequiredService<ISousTacheService>();
        var sessionService = services.GetRequiredService<ISessionService>();

        _viewModel = new TacheDetailViewModel(tache, tacheService, sousTacheService, sessionService);
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        // Forcer le rafraîchissement de l'interface
        OnPropertyChanged(nameof(Tache));
    }

    private async void OnModifierClicked(object sender, EventArgs e)
    {
        var modifierTachePage = new ModifierTache(_viewModel.Tache, _tacheService);
        modifierTachePage.TacheModified += (sender, tacheModifiee) =>
        {
            TacheModified?.Invoke(this, tacheModifiee);
        };
        
        await Navigation.PushAsync(modifierTachePage);
    }

    private async void OnSupprimerClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Supprimer", "Êtes-vous sûr de vouloir supprimer cette tâche ?", "Oui", "Non");
        if (confirm)
        {
            try
            {
                await _tacheService.DeleteTacheAsync(_viewModel.Tache.Id_Tache);
                await DisplayAlert("Succès", "La tâche a été supprimée avec succès", "OK");
                
                // Déclencher l'événement de suppression
                TacheDeleted?.Invoke(this, _viewModel.Tache.Id_Tache);
                
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Erreur", "Impossible de supprimer la tâche", "OK");
            }
        }
    }

    private async void OnSousTacheStatusChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is SousTache sousTache)
        {
            await _viewModel.ToggleSousTacheStatusAsync(sousTache);
        }
    }
}