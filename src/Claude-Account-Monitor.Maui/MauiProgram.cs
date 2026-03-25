using ClaudeAccountMonitor.Core.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClaudeAccountMonitor.Maui;

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
            });

        builder.Services.AddClaudeAccountMonitorCore();
        builder.Services.AddSingleton<ViewModels.MainViewModel>();
        builder.Services.AddTransient<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
