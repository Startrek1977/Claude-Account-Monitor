using ClaudeAccountMonitor.Core.Abstractions;
using ClaudeAccountMonitor.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Threading;

namespace ClaudeAccountMonitor.ViewModels;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly IMonitorService _monitor;
    private readonly DispatcherTimer _pollTimer;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(StartCommand))]
    [NotifyCanExecuteChangedFor(nameof(StopCommand))]
    private bool _isRunning;

    [ObservableProperty]
    private string _statusText = "Idle";

    public MainViewModel(IMonitorService monitor)
    {
        _monitor = monitor;
        _pollTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
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
}
