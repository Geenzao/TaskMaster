using System.Windows.Input;
using Microsoft.Maui.Controls;
using TaskMaster.Services;

namespace TaskMaster.ViewModels
{
    public class DashboardViewModel
    {
        private readonly ISessionService _sessionService;
        
        public string WelcomeMessage => $"Bienvenue {_sessionService.CurrentUser?.Prenom} {_sessionService.CurrentUser?.Nom}";
        public ICommand LogoutCommand { get; }

        public DashboardViewModel(ISessionService sessionService)
        {
            _sessionService = sessionService;
            LogoutCommand = new Command(async () => await LogoutAsync());
        }

        private async Task LogoutAsync()
        {
            _sessionService.ClearSession();
            await Shell.Current.GoToAsync("//Connexion");
        }
    }
} 