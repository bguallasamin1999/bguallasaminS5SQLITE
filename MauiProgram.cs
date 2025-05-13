using bguallasaminS5.Repositorio;
using Microsoft.Extensions.Logging;

namespace bguallasaminS5
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
            string dbPath = FileAccesHelper.GetLocalFilePath("personas.db");
            builder.Services.AddSingleton<PersonaRepositorio>
                (s => ActivatorUtilities.CreateInstance<PersonaRepositorio>(s,dbPath));
/*
#if DEBUG
            builder.Logging.AddDebug();
#endif*/

            return builder.Build();
        }
    }
}
