using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TaskMaster.ViewModels;

public class ConnexionViewModel
{
    public ICommand NavigateToInscriptionCommand { get; }

    public ConnexionViewModel()
    {
        NavigateToInscriptionCommand = new Command(async () => await NavigateToInscriptionAsync());
    }

    private async Task NavigateToInscriptionAsync()
    {
        await Shell.Current.DisplayAlert("Info", "Vous allez être redirigé à la page d'inscription !", "OK");
        await Shell.Current.GoToAsync("//Inscription");
    }
}
