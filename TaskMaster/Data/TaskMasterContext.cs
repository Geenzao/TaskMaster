using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Models
{
    public class TaskMasterContext : DbContext
    {
        public TaskMasterContext(DbContextOptions<TaskMasterContext> options) : base(options)
        {
        }
        
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<SousTache> SousTaches { get; set; }
        public DbSet<Commentaires> Commentaires { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<Participer> Participers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}