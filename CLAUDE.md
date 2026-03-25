# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Claude Account Monitor is a .NET 8.0 WPF desktop application for monitoring and tracking Claude account settings and configuration. It is a Windows-only application using WPF UI framework.

## Project Structure

```
src/
├── Claude-Account-Monitor.sln          # Solution file
├── Claude-Account-Monitor/              # Main WPF application
│   ├── Claude-Account-Monitor.csproj
│   ├── App.xaml(.cs)                   # Application entry point
│   └── MainWindow.xaml(.cs)            # Main window
└── Claude-Account-Monitor.Tests/        # xUnit test project
    ├── Claude-Account-Monitor.Tests.csproj
    ├── UnitTest1.cs                    # MainWindow tests
    └── AppTests.cs                     # Application tests
```

## Build Commands

All commands should be run from the `src/` directory:

```bash
# Build the solution
dotnet build Claude-Account-Monitor.sln

# Build in Release mode
dotnet build Claude-Account-Monitor.sln -c Release

# Run the application
dotnet run --project Claude-Account-Monitor/Claude-Account-Monitor.csproj

# Watch mode (auto-rebuild on changes)
dotnet watch run --project Claude-Account-Monitor.sln
```

## Test Commands

```bash
# Run all tests
dotnet test Claude-Account-Monitor.sln

# Run tests with detailed output
dotnet test Claude-Account-Monitor.sln --logger "console;verbosity=detailed"

# Run tests with code coverage
dotnet test Claude-Account-Monitor.sln /p:CollectCoverage=true

# Run a specific test class
dotnet test Claude-Account-Monitor.sln --filter "FullyQualifiedName~MainWindowTests"
```

## CI/CD

GitHub Actions workflows are configured in `.github/workflows/`:

- **dotnet-desktop.yml**: Builds, tests, and packages the application on push/PR to main. Uses MSBuild for packaging and expects signing certificate secrets (`Base64_Encoded_Pfx`, `Pfx_Key`).
- **branch-name-rules.yml**: Validates branch names are under 50 characters.

## Development Notes

- **Target Framework**: .NET 8.0-windows (Windows-only)
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Test Framework**: xUnit 2.6.x with Xunit.StaFact for WPF thread affinity
- **IDE**: VS Code tasks are configured in `.vscode/tasks.json` (build, publish, watch)
- **Namespace**: `Claude_Account_Monitor` (note underscores replacing hyphens)

## Architecture

This is a standard WPF application following the MVVM pattern (currently minimal implementation):

- **App.xaml**: Application resources and startup configuration
- **MainWindow.xaml**: Main UI window (currently empty Grid)
- Tests use `Xunit.StaFact` for WPF components requiring STA thread

## Git Hooks

Branch names are limited to 50 characters via GitHub Actions validation.
