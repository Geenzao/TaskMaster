using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskMaster.Models;
using TaskMaster.Services;
using TaskMaster.Views;
using System.Linq;

namespace TaskMaster.ViewModels
{
    public class ProjetDetailViewModel
    {
        private readonly ITacheService _tacheService;
        private readonly ISessionService _sessionService;
        private readonly int _projetId;

        // Collections existantes et filtrées
        private ObservableCollection<Tache> _allTaches = new();
        public ObservableCollection<Tache> Taches { get; } = new();

        // Propriétés de filtrage
        private string _selectedStatut;
        public string SelectedStatut
        {
            get => _selectedStatut;
            set
            {
                _selectedStatut = value;
                ApplyFilters();
            }
        }

        private string _selectedPriorite;
        public string SelectedPriorite
        {
            get => _selectedPriorite;
            set
            {
                _selectedPriorite = value;
                ApplyFilters();
            }
        }

        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get => _selectedCategorie;
            set
            {
                _selectedCategorie = value;
                ApplyFilters();
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                ApplyFilters();
            }
        }

        // Options pour les filtres
        public List<string> Statuts { get; } = new List<string> { "Tous", "À faire", "En cours", "Terminé" };
        public List<string> Priorites { get; } = new List<string> { "Toutes", "Basse", "Normale", "Haute", "Urgente" };
        public List<string> Categories { get; private set; } = new List<string> { "Toutes" };

        // Commande de tri
        public ICommand SortByDateCommand { get; }
        private bool _isAscendingDate = true;

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

            // Initialiser les filtres
            SelectedStatut = "Tous";
            SelectedPriorite = "Toutes";
            SelectedCategorie = "Toutes";

            // Ajouter la commande de tri
            SortByDateCommand = new Command(SortByDate);

            LoadTaches();
        }

        private async void LoadTaches()
        {
            var taches = await _tacheService.GetTachesForProjetAsync(_projetId);
            _allTaches.Clear();
            foreach (var tache in taches)
            {
                _allTaches.Add(tache);
            }

            // Mettre à jour la liste des catégories disponibles
            UpdateCategoriesList();
            
            // Appliquer les filtres
            ApplyFilters();
        }

        private void UpdateCategoriesList()
        {
            var categories = _allTaches.Select(t => t.Categorie).Distinct().ToList();
            Categories = new List<string> { "Toutes" };
            Categories.AddRange(categories);
        }

        private void ApplyFilters()
        {
            var filteredTaches = _allTaches.AsEnumerable();

            // Appliquer la recherche textuelle
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var searchLower = SearchText.ToLower();
                filteredTaches = filteredTaches.Where(t => 
                    t.Titre.ToLower().Contains(searchLower) || 
                    t.Description.ToLower().Contains(searchLower));
            }

            // Appliquer le filtre de statut
            if (SelectedStatut != "Tous")
            {
                filteredTaches = filteredTaches.Where(t => t.Statut == SelectedStatut);
            }

            // Appliquer le filtre de priorité
            if (SelectedPriorite != "Toutes")
            {
                filteredTaches = filteredTaches.Where(t => t.Priorite == SelectedPriorite);
            }

            // Appliquer le filtre de catégorie
            if (SelectedCategorie != "Toutes")
            {
                filteredTaches = filteredTaches.Where(t => t.Categorie == SelectedCategorie);
            }

            // Appliquer le tri par date
            filteredTaches = _isAscendingDate 
                ? filteredTaches.OrderBy(t => t.DateEcheance)
                : filteredTaches.OrderByDescending(t => t.DateEcheance);

            // Mettre à jour la collection observable
            Taches.Clear();
            foreach (var tache in filteredTaches)
            {
                Taches.Add(tache);
            }
        }

        private void SortByDate()
        {
            _isAscendingDate = !_isAscendingDate;
            ApplyFilters();
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
            
            var tacheDetailPage = new TacheDetail(tache, _tacheService);
            
            tacheDetailPage.TacheDeleted += (sender, tacheId) =>
            {
                var tacheToRemove = Taches.FirstOrDefault(t => t.Id_Tache == tacheId);
                if (tacheToRemove != null)
                {
                    Taches.Remove(tacheToRemove);
                }
            };

            tacheDetailPage.TacheModified += (sender, tacheModifiee) =>
            {
                var index = Taches.IndexOf(Taches.FirstOrDefault(t => t.Id_Tache == tacheModifiee.Id_Tache));
                if (index != -1)
                {
                    Taches[index] = tacheModifiee;
                }
            };
            
            await Shell.Current.Navigation.PushAsync(tacheDetailPage);
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