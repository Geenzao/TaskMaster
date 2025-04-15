using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;
using TaskMaster.ViewModels;
using TaskMaster.Views;
using TaskMaster.Services;

namespace TaskMaster
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Enregistrement des ViewModels
            builder.Services.AddTransient<InscriptionViewModel>();
            builder.Services.AddTransient<ConnexionViewModel>();
            builder.Services.AddTransient<AccueilViewModel>();

            // Enregistrement des pages
            builder.Services.AddTransient<Inscription>();
            builder.Services.AddTransient<Connexion>();
            builder.Services.AddTransient<Accueil>();
            
            // Enregistrement des services
            builder.Services.AddScoped<IAuthService, AuthService>(); // Ajout du service d'authentification
            builder.Services.AddSingleton<ISessionService, SessionService>();
            builder.Services.AddScoped<IProjetService, ProjetService>();
            builder.Services.AddScoped<ITacheService, TacheService>();

            var connectionString = "server=localhost;port=3306;database=taskmanager;user=root;password=";

            builder.Services.AddDbContext<TaskMasterContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Initialisation de la base de données
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TaskMasterContext>();
                db.Database.Migrate();
            }

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
