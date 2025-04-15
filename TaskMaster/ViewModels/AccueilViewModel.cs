using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.ViewModels
{
    public class AccueilViewModel
    {
        private readonly IProjetService _projetService;
        private readonly ISessionService _sessionService;
        
        public ObservableCollection<Projet> Projets { get; } = new();
        public ICommand CreateProjetCommand { get; }
        public ICommand LogoutCommand { get; }

        public string NewProjetNom { get; set; }
        public string NewProjetDescription { get; set; }

        public AccueilViewModel(IProjetService projetService, ISessionService sessionService)
        {
            _projetService = projetService;
            _sessionService = sessionService;
            
            CreateProjetCommand = new Command(async () => await CreateProjetAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());

            LoadProjets();
        }

        private async void LoadProjets()
        {
            if (_sessionService.CurrentUser == null) return;

            var projets = await _projetService.GetProjetsForUserAsync(_sessionService.CurrentUser.Id_Utilisateur);
            Projets.Clear();
            foreach (var projet in projets)
            {
                Projets.Add(projet);
            }
        }

        private async Task CreateProjetAsync()
        {
            if (_sessionService.CurrentUser == null) return;
            if (string.IsNullOrWhiteSpace(NewProjetNom) || string.IsNullOrWhiteSpace(NewProjetDescription))
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
                return;
            }

            try
            {
                var projet = await _projetService.CreateProjetAsync(
                    NewProjetNom,
                    NewProjetDescription,
                    _sessionService.CurrentUser.Id_Utilisateur
                );

                Projets.Add(projet);
                NewProjetNom = string.Empty;
                NewProjetDescription = string.Empty;

                await Shell.Current.DisplayAlert("Succès", "Projet créé avec succès !", "OK");
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Erreur", "Impossible de créer le projet", "OK");
            }
        }

        private async Task LogoutAsync()
        {
            _sessionService.ClearSession();
            await Shell.Current.DisplayAlert("Info", "Vous avez été déconnecté !", "OK");
            await Shell.Current.GoToAsync("//Connexion");
        }
    }
} 