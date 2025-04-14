using System.Windows.Input;
using Microsoft.Maui.Controls;
using TaskMaster.Services;

namespace TaskMaster.ViewModels;

public class InscriptionViewModel
{
    private readonly IAuthService _authService;
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
    public ICommand NavigateToLoginCommand { get; }
    public ICommand RegisterCommand { get; }

    public InscriptionViewModel(IAuthService authService)
    {
        _authService = authService;
        NavigateToLoginCommand = new Command(async () => await NavigateToLoginAsync());
        RegisterCommand = new Command(async () => await RegisterAsync());
    }

    private async Task NavigateToLoginAsync()
    {
        await Shell.Current.DisplayAlert("Info", "Vous allez être redirigé à la page de connexion !", "OK");
        await Shell.Current.GoToAsync("//Login");
    }

    private async Task RegisterAsync()
    {
        if (Password != ConfirmPassword)
        {
            await Shell.Current.DisplayAlert("Erreur", "Les mots de passe ne correspondent pas", "OK");
            return;
        }

        var result = await _authService.RegisterAsync(Name, FirstName, Email, Password);
        
        if (result)
        {
            await Shell.Current.DisplayAlert("Succès", "Inscription réussie !", "OK");
            await Shell.Current.GoToAsync("//Login");
        }
        else
        {
            await Shell.Current.DisplayAlert("Erreur", "L'inscription a échoué", "OK");
        }
    }
}
