using Microsoft.Maui.Controls;
using TaskMaster.Models;

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
            var detailPage = new ProjetDetail
            {
                BindingContext = projet
            };

            await Navigation.PushAsync(detailPage);
        }
    }
}
