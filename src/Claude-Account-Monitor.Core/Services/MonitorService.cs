using ClaudeAccountMonitor.Core.Abstractions;
using ClaudeAccountMonitor.Core.Models;
using Microsoft.Extensions.Logging;

namespace ClaudeAccountMonitor.Core.Services;

public sealed class MonitorService : IMonitorService, IAsyncDisposable
{
    private readonly ILogger<MonitorService> _logger;
    private CancellationTokenSource? _cts;
    private Task? _loopTask;
    private MonitorStatus _current = new()
    {
        Timestamp = DateTimeOffset.UtcNow,
        State = "Idle",
        Message = "Not started."
    };

    public bool IsRunning => _loopTask is { IsCompleted: false };

    public MonitorService(ILogger<MonitorService> logger)
    {
        _logger = logger;
    }

    public MonitorStatus GetCurrentStatus() => _current;

    public Task StartAsync(CancellationToken ct = default)
    {
        if (IsRunning)
            return Task.CompletedTask;

        _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
        _loopTask = RunLoopAsync(_cts.Token);
        _logger.LogInformation("Monitor started.");
        return Task.CompletedTask;
    }

    public async Task StopAsync()
    {
        if (_cts is not null)
        {
            await _cts.CancelAsync();
            if (_loopTask is not null)
            {
                try
                {
                    await _loopTask.ConfigureAwait(false);
                }
                catch (OperationCanceledException) { }
            }
        }

        _current = new MonitorStatus
        {
            Timestamp = DateTimeOffset.UtcNow,
            State = "Idle",
            Message = "Stopped."
        };
        _logger.LogInformation("Monitor stopped.");
    }

    private async Task RunLoopAsync(CancellationToken ct)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        try
        {
            while (await timer.WaitForNextTickAsync(ct))
            {
                _current = new MonitorStatus
                {
                    Timestamp = DateTimeOffset.UtcNow,
                    State = "Running",
                    Message = $"Last checked: {DateTimeOffset.UtcNow:T}"
                };
                _logger.LogDebug("Monitor tick at {Time}", _current.Timestamp);
            }
        }
        catch (OperationCanceledException)
        {
            // Expected on stop
        }
    }

    public async ValueTask DisposeAsync()
    {
        await StopAsync();
        _cts?.Dispose();
    }
}
