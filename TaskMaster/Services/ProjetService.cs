using TaskMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Services
{
    public interface IProjetService
    {
        Task<List<Projet>> GetProjetsForUserAsync(int userId);
        Task<Projet> CreateProjetAsync(string nom, string description, int userId);
    }

    public class ProjetService : IProjetService
    {
        private readonly TaskMasterContext _context;

        public ProjetService(TaskMasterContext context)
        {
            _context = context;
        }

        public async Task<List<Projet>> GetProjetsForUserAsync(int userId)
        {
            return await _context.Participers
                .Where(p => p.Id_Utilisateur == userId)
                .Join(_context.Projets,
                    p => p.Id_Projet,
                    proj => proj.Id_Projet,
                    (p, proj) => proj)
                .ToListAsync();
        }

        public async Task<Projet> CreateProjetAsync(string nom, string description, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var projet = new Projet
                {
                    Nom = nom,
                    Description = description
                };

                _context.Projets.Add(projet);
                await _context.SaveChangesAsync();

                var participer = new Participer
                {
                    Id_Utilisateur = userId,
                    Id_Projet = projet.Id_Projet,
                    Id_Tache = -1
                };

                _context.Participers.Add(participer);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return projet;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
} 