using Microsoft.Extensions.Logging;
using NovenaTracker.Configuration.Extensions;

namespace NovenaTracker.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "novena_tracker.db");

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.ConfigureNovenaTracke($"Data Source={dbPath}")
                .ConfigureNovenaTrackerViewModels();

            return builder.Build();
        }
    }
}
