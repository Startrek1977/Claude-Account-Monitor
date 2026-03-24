using ClaudeAccountMonitor.ViewModels;
using ClaudeAccountMonitor.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace ClaudeAccountMonitor;

public partial class App : Application
{
    private ServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        services.AddLogging();
        services.AddClaudeAccountMonitorCore();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();

        var window = _serviceProvider.GetRequiredService<MainWindow>();
        window.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
        window.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }
}

