using Microsoft.Maui.Controls;
using TaskMaster.Models;
using TaskMaster.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TaskMaster.Views;

public partial class ProjetComponent : Frame
{
    public ProjetComponent()
    {
        InitializeComponent();
    }

    private async void OnProjetTapped(object sender, EventArgs e)
    {
        if (BindingContext is Projet projet)
        {
            // Récupérer les services nécessaires
            var tacheService = Application.Current.Handler.MauiContext.Services.GetRequiredService<ITacheService>();
            var sessionService = Application.Current.Handler.MauiContext.Services.GetRequiredService<ISessionService>();

            // Créer la page de détail avec les dépendances
            var detailPage = new ProjetDetail(projet, tacheService, sessionService);

            await Navigation.PushAsync(detailPage);
        }
    }
}
