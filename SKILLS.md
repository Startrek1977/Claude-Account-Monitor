# Skills

This document describes the technical skills and capabilities demonstrated by the Claude Account Monitor project.

## Languages & Platforms

- **C# 12** with nullable reference types and implicit usings
- **.NET 8** (cross-platform core + WPF + MAUI)
- **XAML** (WPF and .NET MAUI)

## Frameworks & Libraries

- **WPF** (`net8.0-windows`) — desktop UI for Windows
- **.NET MAUI** (multi-target: Android, iOS, macOS Catalyst, Windows) — cross-platform mobile/desktop UI
- **CommunityToolkit.Mvvm** — MVVM source generators (`[ObservableProperty]`, `[RelayCommand]`, `ObservableObject`)
- **Microsoft.Extensions.DependencyInjection** — dependency injection container
- **Microsoft.Extensions.Logging** / `Logging.Abstractions` — structured logging abstractions
- **xUnit** 2.6 + **Xunit.StaFact** — unit testing with STA thread support for WPF UI tests

## Architecture Skills

- **Multi-project solution** — shared Core library consumed by WPF and MAUI UIs
- **MVVM pattern** — clean separation of View, ViewModel, and Model layers
- **Dependency Injection** — constructor injection, service registration via extension methods
- **Abstraction-driven design** — `IMonitorService` interface decouples UI from implementation
- **Async/await** — `Task`-based async for service start/stop; `PeriodicTimer` for background polling
- **IAsyncDisposable** — proper async resource cleanup for long-running services

## DevOps & CI/CD Skills

- **GitHub Actions** — automated CI pipeline (`.github/workflows/dotnet-desktop.yml`)
- **Matrix builds** — parallel `Debug` and `Release` configuration builds
- **NuGet caching** — `actions/cache` to speed up dependency restore across runs
- **Artifact publishing** — `actions/upload-artifact` for built binaries
- **Branch protection rules** — enforced via `.github/workflows/branch-name-rules.yml`

## Testing Skills

- **Unit testing** with xUnit
- **STA-thread UI tests** with `Xunit.StaFact` for WPF window instantiation
- **Test coverage** for application lifecycle, window creation, and UI component validation

## Code Quality

- Nullable reference types (`#nullable enable`) throughout
- `sealed` classes for concrete implementations
- File-scoped namespace declarations
- Source-generated boilerplate via `CommunityToolkit.Mvvm` attributes
