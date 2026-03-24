using ClaudeAccountMonitor.Core.Abstractions;
using ClaudeAccountMonitor.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClaudeAccountMonitor.Maui.ViewModels;

public sealed partial class MainViewModel : ObservableObject, IDisposable
{
    private readonly IMonitorService _monitor;
    private readonly IDispatcherTimer _pollTimer;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(StartCommand))]
    [NotifyCanExecuteChangedFor(nameof(StopCommand))]
    private bool _isRunning;

    [ObservableProperty]
    private string _statusText = "Idle";

    public MainViewModel(IMonitorService monitor)
    {
        _monitor = monitor;
        var dispatcher = Application.Current?.Dispatcher
            ?? throw new InvalidOperationException("Application.Current is not available.");
        _pollTimer = dispatcher.CreateTimer();
        _pollTimer.Interval = TimeSpan.FromSeconds(1);
        _pollTimer.Tick += (_, _) => Refresh();
        _pollTimer.Start();
    }

    [RelayCommand(CanExecute = nameof(CanStart))]
    private async Task StartAsync()
    {
        await _monitor.StartAsync();
        Refresh();
    }

    private bool CanStart() => !IsRunning;

    [RelayCommand(CanExecute = nameof(CanStop))]
    private async Task StopAsync()
    {
        await _monitor.StopAsync();
        Refresh();
    }

    private bool CanStop() => IsRunning;

    private void Refresh()
    {
        IsRunning = _monitor.IsRunning;
        MonitorStatus status = _monitor.GetCurrentStatus();
        StatusText = $"[{status.State}] {status.Message}";
    }

    public void Dispose()
    {
        _pollTimer.Stop();
    }
}
