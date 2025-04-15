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
    }
} 