using Microsoft.Extensions.Logging;
using SharedLibrary.Models;
using TeacherOverview.Views;

namespace TeacherOverview
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

#if DEBUG
    		builder.Logging.AddDebug();

            // Legger til services
            builder.Services.AddSingleton(new Apiservice());
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<DebriefsPage>();
#endif

            return builder.Build();
        }
    }
}
