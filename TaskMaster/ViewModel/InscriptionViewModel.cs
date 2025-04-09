using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TaskMaster.ViewModels;

public class InscriptionViewModel
{
    public ICommand NavigateToLoginCommand { get; }

    public InscriptionViewModel()
    {
        NavigateToLoginCommand = new Command(async () => await NavigateToLoginAsync());
    }

    private async Task NavigateToLoginAsync()
    {
        await Shell.Current.DisplayAlert("Info", "Vous allez être redirigé à la page de connexion !", "OK");
        await Shell.Current.GoToAsync("//Login");
    }
}
