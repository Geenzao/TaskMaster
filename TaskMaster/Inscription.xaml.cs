using TaskMaster.ViewModels;
using Microsoft.Maui.Controls;

namespace TaskMaster.Views
{
    public partial class Inscription : ContentPage
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private async void OnNavigateToConnexionTapped(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("Info", "Vous allez être redirigé à la page de connexion !", "OK");
            await Shell.Current.GoToAsync("//Connexion");
        }
    }
}