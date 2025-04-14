using System.Windows.Input;
using Microsoft.Maui.Controls;
using TaskMaster.Services;

namespace TaskMaster.ViewModels;

public class ConnexionViewModel
{
    private IAuthService? _authService;
    private ISessionService? _sessionService;
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public ICommand LoginCommand { get; }
    public ICommand NavigateToInscriptionCommand { get; }

    public ConnexionViewModel()
    {
        LoginCommand = new Command(async () => await LoginAsync());
        NavigateToInscriptionCommand = new Command(async () => await NavigateToInscriptionAsync());
    }

    private async Task LoginAsync()
    {
        if (_authService == null || _sessionService == null)
        {
            await Shell.Current.DisplayAlert("Erreur", "Service non initialisé", "OK");
            return;
        }

        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            await Shell.Current.DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
            return;
        }

        var user = await _authService.LoginAsync(Email, Password);
        
        if (user != null)
        {
            _sessionService.SetCurrentUser(user);
            await Shell.Current.DisplayAlert("Succès", "Connexion réussie !", "OK");
            await Shell.Current.GoToAsync("//Accueil");
        }
        else
        {
            await Shell.Current.DisplayAlert("Erreur", "Email ou mot de passe incorrect", "OK");
        }
    }

    private async Task NavigateToInscriptionAsync()
    {
        await Shell.Current.DisplayAlert("Info", "Vous allez être redirigé à la page d'inscription !", "OK");
        await Shell.Current.GoToAsync("//Inscription");
    }

    public void Initialize(IAuthService authService, ISessionService sessionService)
    {
        _authService = authService;
        _sessionService = sessionService;
    }
}
