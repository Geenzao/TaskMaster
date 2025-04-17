using TaskMaster.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TaskMaster.Services
{
    public interface ISousTacheService
    {
        Task<SousTache> CreateSousTacheAsync(string titre, DateTime dateEcheance, int tacheId, int userId);
        Task<List<SousTache>> GetSousTachesForTacheAsync(int tacheId);
        Task<SousTache> UpdateSousTacheStatusAsync(int sousTacheId, string nouveauStatut);
        Task DeleteSousTacheAsync(int sousTacheId);
    }

    public class SousTacheService : ISousTacheService
    {
        private readonly TaskMasterContext _context;

        public SousTacheService(TaskMasterContext context)
        {
            _context = context;
        }

        public async Task<SousTache> CreateSousTacheAsync(string titre, DateTime dateEcheance, int tacheId, int userId)
        {
            var tache = await _context.Taches.FindAsync(tacheId);
            var utilisateur = await _context.Utilisateurs.FindAsync(userId);

            if (tache == null || utilisateur == null)
                throw new Exception("Tâche ou utilisateur non trouvé");

            var sousTache = new SousTache
            {
                Titre = titre,
                DateEcheance = dateEcheance,
                Statut = "À faire",
                Id_Tache = tacheId,
                Tache = tache,
                Id_Utilisateur = userId,
                Utilisateur = utilisateur
            };

            _context.SousTaches.Add(sousTache);
            await _context.SaveChangesAsync();
            return sousTache;
        }

        public async Task<List<SousTache>> GetSousTachesForTacheAsync(int tacheId)
        {
            Debug.WriteLine($"=== Récupération des sous-tâches pour la tâche {tacheId} ===");
            var sousTaches = await _context.SousTaches
                .Include(st => st.Tache)
                .Include(st => st.Utilisateur)
                .Where(st => st.Id_Tache == tacheId)
                .ToListAsync();

            Debug.WriteLine($"Nombre de sous-tâches trouvées : {sousTaches.Count}");
            foreach (var st in sousTaches)
            {
                Debug.WriteLine($"=== Sous-tâche de la base de données ===");
                Debug.WriteLine($"ID: {st.Id_SousTache}");
                Debug.WriteLine($"Titre: '{st.Titre}'");
                Debug.WriteLine($"Statut: {st.Statut}");
                Debug.WriteLine($"Date d'échéance: {st.DateEcheance}");
                Debug.WriteLine("================================");
            }

            return sousTaches;
        }

        public async Task<SousTache> UpdateSousTacheStatusAsync(int sousTacheId, string nouveauStatut)
        {
            var sousTache = await _context.SousTaches.FindAsync(sousTacheId);
            if (sousTache == null)
                throw new Exception("Sous-tâche non trouvée");

            sousTache.Statut = nouveauStatut;
            await _context.SaveChangesAsync();
            return sousTache;
        }

        public async Task DeleteSousTacheAsync(int sousTacheId)
        {
            var sousTache = await _context.SousTaches.FindAsync(sousTacheId);
            if (sousTache != null)
            {
                _context.SousTaches.Remove(sousTache);
                await _context.SaveChangesAsync();
            }
        }
    }
} 