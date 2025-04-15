using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskMaster.Models;
using TaskMaster.Services;
using TaskMaster.Views;

namespace TaskMaster.ViewModels
{
    public class ProjetDetailViewModel
    {
        private readonly ITacheService _tacheService;
        private readonly ISessionService _sessionService;
        private readonly int _projetId;

        public ObservableCollection<Tache> Taches { get; } = new();
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }
        public string Priorite { get; set; }
        public DateTime DateEcheance { get; set; } = DateTime.Now.AddDays(7);

        public ICommand CreateTacheCommand { get; }
        public ICommand NavigateToTacheDetailCommand { get; }
        public ICommand DeleteTacheCommand { get; }

        public ProjetDetailViewModel(ITacheService tacheService, ISessionService sessionService, int projetId)
        {
            _tacheService = tacheService;
            _sessionService = sessionService;
            _projetId = projetId;

            CreateTacheCommand = new Command(async () => await CreateTacheAsync());
            NavigateToTacheDetailCommand = new Command<Tache>(async (tache) => await NavigateToTacheDetailAsync(tache));
            DeleteTacheCommand = new Command<Tache>(async (tache) => await DeleteTacheAsync(tache));
            LoadTaches();
        }

        private async void LoadTaches()
        {
            var taches = await _tacheService.GetTachesForProjetAsync(_projetId);
            Taches.Clear();
            foreach (var tache in taches)
            {
                Taches.Add(tache);
            }
        }

        private async Task CreateTacheAsync()
        {
            if (_sessionService.CurrentUser == null) return;

            if (string.IsNullOrWhiteSpace(Titre) || string.IsNullOrWhiteSpace(Description))
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez remplir tous les champs obligatoires", "OK");
                return;
            }

            try
            {
                var tache = await _tacheService.CreateTacheAsync(
                    Titre,
                    Description,
                    Categorie ?? "Général",
                    Priorite ?? "Normale",
                    DateEcheance,
                    _sessionService.CurrentUser.Id_Utilisateur,
                    _projetId
                );

                Taches.Add(tache);
                
                // Réinitialiser les champs
                Titre = string.Empty;
                Description = string.Empty;
                Categorie = string.Empty;
                Priorite = string.Empty;
                DateEcheance = DateTime.Now.AddDays(7);

                await Shell.Current.DisplayAlert("Succès", "Tâche créée avec succès !", "OK");
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Erreur", "Impossible de créer la tâche", "OK");
            }
        }

        private async Task NavigateToTacheDetailAsync(Tache tache)
        {
            if (tache == null) return;
            
            await Shell.Current.Navigation.PushAsync(new TacheDetail(tache));
        }

        private async Task DeleteTacheAsync(Tache tache)
        {
            if (tache == null) return;

            bool confirm = await Shell.Current.DisplayAlert(
                "Confirmation",
                $"Êtes-vous sûr de vouloir supprimer la tâche \"{tache.Titre}\" ?",
                "Oui",
                "Non");

            if (!confirm) return;

            try
            {
                await _tacheService.DeleteTacheAsync(tache.Id_Tache);
                Taches.Remove(tache);
                await Shell.Current.DisplayAlert("Succès", "Tâche supprimée avec succès", "OK");
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Erreur", "Impossible de supprimer la tâche", "OK");
            }
        }
    }
} 