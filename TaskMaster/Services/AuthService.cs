using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

namespace TaskMaster.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(string name, string firstname, string email, string password);
}

public class AuthService : IAuthService
{
    private readonly TaskMasterContext _context;

    public AuthService(TaskMasterContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterAsync(string name, string firstname, string email, string password)
    {
        try
        {
            // Vérifier si l'email existe déjà
            if (await _context.Utilisateurs.AnyAsync(u => u.Email == email))
                return false;

            // Créer le nouvel utilisateur
            var user = new Utilisateur
            {
                Nom = name,
                Prenom = firstname,
                Email = email,
                MotDePasse = password // Note: En production, il faudrait hasher le mot de passe
            };

            _context.Utilisateurs.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
} 