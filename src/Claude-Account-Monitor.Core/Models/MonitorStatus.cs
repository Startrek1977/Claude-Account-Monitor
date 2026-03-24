namespace ClaudeAccountMonitor.Core.Models;

public sealed class MonitorStatus
{
    public DateTimeOffset Timestamp { get; init; }
    public string State { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}
