using ClaudeAccountMonitor.Core.Models;

namespace ClaudeAccountMonitor.Core.Abstractions;

public interface IMonitorService
{
    bool IsRunning { get; }
    MonitorStatus GetCurrentStatus();
    Task StartAsync(CancellationToken ct = default);
    Task StopAsync();
}
