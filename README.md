# Claude Account Monitor

A lightweight, cross-platform tool for monitoring and tracking Claude account settings and configuration.

## Overview

Claude Account Monitor is a developer-oriented tool designed to provide visibility into Claude account configuration and settings.

The project allows users to inspect and monitor their account environment, detect configuration changes, and maintain awareness of important settings over time. The goal is to help developers maintain better operational awareness of their Claude account environment.

This project is independent and is not affiliated with or endorsed by Anthropic.

## Architecture

The solution follows a multi-UI MVVM architecture with three projects sharing a single Core library:

| Project | Target | Namespace | Description |
|---|---|---|---|
| `Claude-Account-Monitor.Core` | `net8.0` | `ClaudeAccountMonitor.Core` | Platform-agnostic business logic, models, and services |
| `Claude-Account-Monitor` | `net8.0-windows` | `ClaudeAccountMonitor` | WPF desktop UI |
| `Claude-Account-Monitor.Maui` | Multi-target | `ClaudeAccountMonitor.Maui` | .NET MAUI cross-platform UI |
| `Claude-Account-Monitor.Tests` | `net8.0-windows` | `ClaudeAccountMonitor.Tests` | xUnit test suite for the WPF project |

**Key design decisions:**
- Dependency Injection via `Microsoft.Extensions.DependencyInjection`
- ViewModels powered by `CommunityToolkit.Mvvm` (`ObservableObject`, `RelayCommand`)
- `IMonitorService` abstraction in Core — WPF polls it every 1 second via `DispatcherTimer`; internally the service uses a `PeriodicTimer` at 5-second intervals

## Features

- Monitor Claude account settings
- Detect configuration changes
- Track account configuration over time
- Simple and developer-friendly interface
- Lightweight and easy to run locally
- Cross-platform support (Windows WPF + .NET MAUI)
- Extensible architecture for additional monitoring capabilities

## Use Cases

Claude Account Monitor may be useful if you want to:

- Observe configuration changes in your Claude account
- Maintain visibility into account settings
- Track configuration over time
- Build tooling around Claude account monitoring
- Experiment with automation and observability for Claude services

## Project Status

This project is currently in early development. Features and architecture may evolve as the project grows.

## Installation

Clone the repository:

```bash
git clone https://github.com/Startrek1977/Claude-Account-Monitor.git
cd Claude-Account-Monitor
```

## Building

To build the entire solution:

```bash
dotnet build src/Claude-Account-Monitor.sln
```

To build only the WPF app:

```bash
dotnet build src/Claude-Account-Monitor/Claude-Account-Monitor.csproj
```

## Testing

The project includes a test suite using xUnit.

### Running Tests

To run all tests:

```bash
dotnet test src/Claude-Account-Monitor.sln
```

To run tests with detailed output:

```bash
dotnet test src/Claude-Account-Monitor.sln --logger "console;verbosity=detailed"
```

To run tests with code coverage (requires additional tooling):

```bash
dotnet test src/Claude-Account-Monitor.sln /p:CollectCoverage=true
```

### Test Project

- **Location:** `src/Claude-Account-Monitor.Tests/`
- **Framework:** xUnit 2.6.x
- **Target Framework:** `net8.0-windows`

### Test Coverage

The test project includes unit tests for:
- Application initialization and lifecycle
- Main window instantiation and functionality
- Core dashboard components

Tests are automatically executed in the CI/CD pipeline on every push and pull request to the `main` branch.

## CI/CD

The project uses GitHub Actions (`.github/workflows/dotnet-desktop.yml`) to:
1. Restore NuGet packages (with caching)
2. Run the test suite in both `Debug` and `Release` configurations
3. Publish the WPF app
4. Upload build artifacts

## Contributing

Contributions are welcome. Please open an issue or pull request on GitHub.
