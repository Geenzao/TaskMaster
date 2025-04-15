using TaskMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Services
{
    public interface ITacheService
    {
        Task<Tache> CreateTacheAsync(string titre, string description, string categorie, string priorite, 
            DateTime dateEcheance, int userId, int projetId);
        Task<List<Tache>> GetTachesForProjetAsync(int projetId);
        Task DeleteTacheAsync(int tacheId);
        Task<Tache> UpdateTacheAsync(int tacheId, string titre, string description, string categorie, 
            string priorite, string statut, DateTime dateEcheance, string etiquette);
    }

    public class TacheService : ITacheService
    {
        private readonly TaskMasterContext _context;

        public TacheService(TaskMasterContext context)
        {
            _context = context;
        }

        public async Task<Tache> CreateTacheAsync(string titre, string description, string categorie, 
            string priorite, DateTime dateEcheance, int userId, int projetId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var tache = new Tache
                {
                    Titre = titre,
                    Description = description,
                    Categorie = categorie,
                    Priorite = priorite,
                    DateCreation = DateTime.Now,
                    DateEcheance = dateEcheance,
                    Statut = "À faire",
                    Id_Utilisateur = userId,
                    Etiquette = "Normal"
                };

                _context.Taches.Add(tache);
                await _context.SaveChangesAsync();

                var participer = new Participer
                {
                    Id_Utilisateur = userId,
                    Id_Projet = projetId,
                    Id_Tache = tache.Id_Tache
                };

                _context.Participers.Add(participer);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return tache;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Tache>> GetTachesForProjetAsync(int projetId)
        {
            return await _context.Participers
                .Where(p => p.Id_Projet == projetId && p.Id_Tache != null)
                .Join(_context.Taches,
                    p => p.Id_Tache,
                    t => t.Id_Tache,
                    (p, t) => t)
                .Distinct()
                .ToListAsync();
        }

        public async Task DeleteTacheAsync(int tacheId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Supprimer d'abord les enregistrements liés dans la table Participer
                var participations = await _context.Participers
                    .Where(p => p.Id_Tache == tacheId)
                    .ToListAsync();
                _context.Participers.RemoveRange(participations);

                // Supprimer la tâche elle-même
                var tache = await _context.Taches.FindAsync(tacheId);
                if (tache != null)
                {
                    _context.Taches.Remove(tache);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Tache> UpdateTacheAsync(int tacheId, string titre, string description, string categorie, 
            string priorite, string statut, DateTime dateEcheance, string etiquette)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var tache = await _context.Taches.FindAsync(tacheId);
                if (tache == null)
                {
                    throw new Exception("Tâche non trouvée");
                }

                // Créer un historique des modifications
                var historique = new Historique
                {
                    Description = "Modification de la tâche",
                    AncienneValeur = $"Titre: {tache.Titre}, Description: {tache.Description}, Catégorie: {tache.Categorie}, " +
                                   $"Priorité: {tache.Priorite}, Statut: {tache.Statut}, Échéance: {tache.DateEcheance:d}, " +
                                   $"Étiquette: {tache.Etiquette}",
                    NouvelleValeur = $"Titre: {titre}, Description: {description}, Catégorie: {categorie}, " +
                                   $"Priorité: {priorite}, Statut: {statut}, Échéance: {dateEcheance:d}, " +
                                   $"Étiquette: {etiquette}",
                    DateModification = DateTime.Now,
                    Id_Tache = tacheId,
                    Tache = tache
                };

                // Mettre à jour la tâche
                tache.Titre = titre;
                tache.Description = description;
                tache.Categorie = categorie;
                tache.Priorite = priorite;
                tache.Statut = statut;
                tache.DateEcheance = dateEcheance;
                tache.Etiquette = etiquette;

                _context.Historiques.Add(historique);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return tache;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
} 