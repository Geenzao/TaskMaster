using Microsoft.Extensions.Logging;
using TaskMaster.ViewModels;
using TaskMaster.Views;

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

            // Enregistrement des pages
            builder.Services.AddTransient<Inscription>();
            builder.Services.AddTransient<Connexion>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
