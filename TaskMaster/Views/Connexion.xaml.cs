using TaskMaster.ViewModels;
using Microsoft.Maui.Controls;

namespace TaskMaster.Views
{
    public partial class Connexion : ContentPage
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private async void OnNavigateToInscriptionTapped(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("Info", "Vous allez être redirigé à la page d'inscription !", "OK");
            await Shell.Current.GoToAsync("//Inscription");
        }
    }
}