using Microsoft.Maui.Controls;
using TaskMaster.Models;

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
            await Navigation.PushAsync(new TacheDetail(tache));
        }
    }
}
