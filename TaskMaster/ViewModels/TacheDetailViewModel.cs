using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskMaster.Models;
using TaskMaster.Services;
using System.Diagnostics;

namespace TaskMaster.ViewModels
{
    public class TacheDetailViewModel
    {
        private readonly ITacheService _tacheService;
        private readonly ISousTacheService _sousTacheService;
        private readonly ISessionService _sessionService;

        public Tache Tache { get; private set; }
        public ObservableCollection<SousTache> SousTaches { get; } = new();

        // Propriétés pour la nouvelle sous-tâche
        public string NouvelleSousTacheTitre { get; set; }
        public DateTime NouvelleSousTacheEcheance { get; set; } = DateTime.Now.AddDays(1);

        // Commandes
        public ICommand AjouterSousTacheCommand { get; }
        public ICommand ToggleSousTacheStatusCommand { get; }
        public ICommand SupprimerSousTacheCommand { get; }

        public TacheDetailViewModel(Tache tache, ITacheService tacheService, ISousTacheService sousTacheService, ISessionService sessionService)
        {
            Tache = tache;
            _tacheService = tacheService;
            _sousTacheService = sousTacheService;
            _sessionService = sessionService;

            AjouterSousTacheCommand = new Command(async () => await AjouterSousTacheAsync());
            ToggleSousTacheStatusCommand = new Command<SousTache>(async (st) => await ToggleSousTacheStatusAsync(st));
            SupprimerSousTacheCommand = new Command<SousTache>(async (st) => await SupprimerSousTacheAsync(st));

            LoadSousTaches();
        }

        private async void LoadSousTaches()
        {
            try
            {
                Debug.WriteLine("\n=== DÉBUT DU CHARGEMENT DES SOUS-TÂCHES ===");
                Debug.WriteLine($"ID de la tâche parente : {Tache.Id_Tache}");
                
                var sousTaches = await _sousTacheService.GetSousTachesForTacheAsync(Tache.Id_Tache);
                Debug.WriteLine($"Nombre de sous-tâches chargées : {sousTaches.Count}");
                
                foreach (var st in sousTaches)
                {
                    Debug.WriteLine("\n=== DÉTAILS DE LA SOUS-TÂCHE ===");
                    Debug.WriteLine($"Type de l'objet : {st.GetType().FullName}");
                    Debug.WriteLine($"HashCode : {st.GetHashCode()}");
                    Debug.WriteLine($"ID: {st.Id_SousTache}");
                    Debug.WriteLine($"Titre (longueur): '{st.Titre?.Length ?? 0}'");
                    Debug.WriteLine($"Titre (contenu): '{st.Titre}'");
                    Debug.WriteLine($"Titre (null?): {st.Titre == null}");
                    Debug.WriteLine($"Titre (empty?): {string.IsNullOrEmpty(st.Titre)}");
                    Debug.WriteLine($"Titre (whitespace?): {string.IsNullOrWhiteSpace(st.Titre)}");
                    Debug.WriteLine($"Statut: '{st.Statut}'");
                    Debug.WriteLine($"Date d'échéance: {st.DateEcheance}");
                    Debug.WriteLine($"ID Tâche parente: {st.Id_Tache}");
                    Debug.WriteLine($"ID Utilisateur: {st.Id_Utilisateur}");
                    Debug.WriteLine("=== PROPRIÉTÉS DE NAVIGATION ===");
                    Debug.WriteLine($"Tache parente (null?): {st.Tache == null}");
                    if (st.Tache != null)
                        Debug.WriteLine($"Titre de la tâche parente: '{st.Tache.Titre}'");
                    Debug.WriteLine($"Utilisateur (null?): {st.Utilisateur == null}");
                    if (st.Utilisateur != null)
                        Debug.WriteLine($"Utilisateur assigné: {st.Utilisateur.Prenom} {st.Utilisateur.Nom}");
                    Debug.WriteLine("================================\n");
                }
                
                Debug.WriteLine("=== MISE À JOUR DE LA COLLECTION ===");
                SousTaches.Clear();
                foreach (var st in sousTaches)
                {
                    Debug.WriteLine($"Ajout de la sous-tâche à la collection - ID: {st.Id_SousTache}, Titre: '{st.Titre}'");
                    SousTaches.Add(st);
                }
                Debug.WriteLine($"Nombre final de sous-tâches dans la collection: {SousTaches.Count}");
                Debug.WriteLine("=== FIN DU CHARGEMENT DES SOUS-TÂCHES ===\n");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n=== ERREUR LORS DU CHARGEMENT DES SOUS-TÂCHES ===");
                Debug.WriteLine($"Message d'erreur : {ex.Message}");
                Debug.WriteLine($"Type d'erreur : {ex.GetType().FullName}");
                Debug.WriteLine($"Stack trace : {ex.StackTrace}");
                Debug.WriteLine("=== FIN DE L'ERREUR ===\n");
                await Shell.Current.DisplayAlert("Erreur", $"Impossible de charger les sous-tâches : {ex.Message}", "OK");
            }
        }

        private async Task AjouterSousTacheAsync()
        {
            if (string.IsNullOrWhiteSpace(NouvelleSousTacheTitre))
            {
                await Shell.Current.DisplayAlert("Erreur", "Veuillez entrer un titre pour la sous-tâche", "OK");
                return;
            }

            try
            {
                var nouvelleSousTache = await _sousTacheService.CreateSousTacheAsync(
                    NouvelleSousTacheTitre,
                    NouvelleSousTacheEcheance,
                    Tache.Id_Tache,
                    _sessionService.CurrentUser?.Id_Utilisateur ?? 0
                );

                SousTaches.Add(nouvelleSousTache);
                NouvelleSousTacheTitre = string.Empty;
                NouvelleSousTacheEcheance = DateTime.Now.AddDays(1);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erreur", $"Impossible de créer la sous-tâche : {ex.Message}", "OK");
            }
        }

        public async Task ToggleSousTacheStatusAsync(SousTache sousTache)
        {
            try
            {
                var nouveauStatut = sousTache.Statut == "À faire" ? "Terminé" : "À faire";
                await _sousTacheService.UpdateSousTacheStatusAsync(sousTache.Id_SousTache, nouveauStatut);
                sousTache.Statut = nouveauStatut;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erreur", $"Impossible de mettre à jour le statut : {ex.Message}", "OK");
            }
        }

        private async Task SupprimerSousTacheAsync(SousTache sousTache)
        {
            bool confirm = await Shell.Current.DisplayAlert(
                "Confirmation",
                $"Êtes-vous sûr de vouloir supprimer la sous-tâche \"{sousTache.Titre}\" ?",
                "Oui",
                "Non");

            if (!confirm) return;

            try
            {
                await _sousTacheService.DeleteSousTacheAsync(sousTache.Id_SousTache);
                SousTaches.Remove(sousTache);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erreur", $"Impossible de supprimer la sous-tâche : {ex.Message}", "OK");
            }
        }
    }
} 