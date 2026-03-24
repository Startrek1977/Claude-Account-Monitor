# Claude Account Monitor — AI Context (Claude)

Use this file to restore your working context for this repository without re-scanning all source files.

## Project Summary

**Claude Account Monitor** is a .NET 8 developer tool for monitoring Claude account settings and configuration changes. It provides a WPF desktop UI and a .NET MAUI cross-platform UI, both powered by a shared Core library.

This project is independent and is not affiliated with or endorsed by Anthropic.

## Solution Structure

```
src/
├── Claude-Account-Monitor.sln
├── Claude-Account-Monitor/            # WPF UI (net8.0-windows)
│   ├── App.xaml / App.xaml.cs
│   ├── MainWindow.xaml / MainWindow.xaml.cs
│   ├── AssemblyInfo.cs
│   ├── ViewModels/
│   │   └── MainViewModel.cs
│   └── Claude-Account-Monitor.csproj
├── Claude-Account-Monitor.Core/       # Shared logic (net8.0)
│   ├── Abstractions/
│   │   └── IMonitorService.cs
│   ├── DependencyInjection/
│   │   └── ServiceCollectionExtensions.cs
│   ├── Models/
│   │   └── MonitorStatus.cs
│   ├── Services/
│   │   └── MonitorService.cs
│   └── Claude-Account-Monitor.Core.csproj
├── Claude-Account-Monitor.Maui/       # .NET MAUI UI (multi-target)
│   ├── App.xaml / App.xaml.cs
│   ├── AppShell.xaml / AppShell.xaml.cs
│   ├── MainPage.xaml / MainPage.xaml.cs
│   ├── MauiProgram.cs
│   ├── ViewModels/
│   │   └── MainViewModel.cs
│   ├── Platforms/
│   │   ├── Android/
│   │   ├── iOS/
│   │   ├── MacCatalyst/
│   │   └── Windows/
│   └── Claude-Account-Monitor.Maui.csproj
└── Claude-Account-Monitor.Tests/      # xUnit tests (net8.0-windows)
    ├── AppTests.cs
    ├── UnitTest1.cs
    └── Claude-Account-Monitor.Tests.csproj
```

## Namespaces

| Project | Namespace |
|---|---|
| WPF app | `ClaudeAccountMonitor` |
| WPF ViewModels | `ClaudeAccountMonitor.ViewModels` |
| Core library | `ClaudeAccountMonitor.Core` |
| Core Abstractions | `ClaudeAccountMonitor.Core.Abstractions` |
| Core Models | `ClaudeAccountMonitor.Core.Models` |
| Core Services | `ClaudeAccountMonitor.Core.Services` |
| Core DI | `ClaudeAccountMonitor.Core.DependencyInjection` |
| MAUI app | `ClaudeAccountMonitor.Maui` |
| Tests | `ClaudeAccountMonitor.Tests` |

## Key Abstractions

### `IMonitorService` (Core)

```csharp
public interface IMonitorService
{
    bool IsRunning { get; }
    MonitorStatus GetCurrentStatus();
    Task StartAsync(CancellationToken ct = default);
    Task StopAsync();
}
```

### `MonitorStatus` (Core)

```csharp
public sealed class MonitorStatus
{
    public DateTimeOffset Timestamp { get; init; }
    public string State { get; init; }   // e.g. "Idle", "Running"
    public string Message { get; init; }
}
```

## Architecture Patterns

- **MVVM** — ViewModels use `CommunityToolkit.Mvvm` (`ObservableObject`, `[ObservableProperty]`, `[RelayCommand]`)
- **DI** — `Microsoft.Extensions.DependencyInjection`; Core services registered via `AddClaudeAccountMonitorCore()`
- **Polling** — WPF `MainViewModel` polls `IMonitorService` every 1 second via `DispatcherTimer`; `MonitorService` uses `PeriodicTimer` internally at 5-second intervals
- **No events/IObservable** — state is pulled, not pushed

## Key Dependencies

| Package | Version | Used by |
|---|---|---|
| `CommunityToolkit.Mvvm` | 8.3.2 | WPF, MAUI |
| `Microsoft.Extensions.DependencyInjection` | 8.0.1 | WPF, Core |
| `Microsoft.Extensions.Logging` | 8.0.1 | WPF |
| `Microsoft.Extensions.Logging.Abstractions` | 8.0.2 | Core |
| `Microsoft.Extensions.Logging.Debug` | 8.0.1 | MAUI |
| `xunit` | 2.6.6 | Tests |
| `Xunit.StaFact` | 1.1.11 | Tests (STA thread for WPF) |

## Common Commands

```bash
# Build entire solution
dotnet build src/Claude-Account-Monitor.sln

# Run tests
dotnet test src/Claude-Account-Monitor.Tests/Claude-Account-Monitor.Tests.csproj

# Publish WPF app
dotnet publish src/Claude-Account-Monitor/Claude-Account-Monitor.csproj -c Release
```

## CI/CD

GitHub Actions workflow: `.github/workflows/dotnet-desktop.yml`
- Runs on `push` and `pull_request` to `main`
- Matrix: `Debug` and `Release` configurations
- Steps: Checkout → Install .NET → Cache NuGet → Install MAUI workload → Restore → Test → Publish → Upload artifact

## Conventions

- C# 12 / .NET 8, nullable reference types enabled, implicit usings enabled
- File-scoped namespaces
- `sealed` classes preferred for concrete implementations
- `IAsyncDisposable` on services that own background tasks
- Tests use `[StaFact]` (from `Xunit.StaFact`) for WPF UI tests requiring STA thread
