# Claude Account Monitor

A lightweight tool for monitoring and tracking Claude account settings and configuration.

## Overview

Claude Account Monitor is a developer-oriented tool designed to provide visibility into Claude account configuration and settings.

The project allows users to inspect and monitor their account environment, detect configuration changes, and maintain awareness of important settings over time.

The goal of this tool is to help developers maintain better operational awareness of their Claude account environment.

This project is independent and is not affiliated with or endorsed by Anthropic.

## Features

- Monitor Claude account settings
- Detect configuration changes
- Track account configuration over time
- Simple and developer-friendly interface
- Lightweight and easy to run locally
- Extensible architecture for additional monitoring capabilities

## Use Cases

Claude Account Monitor may be useful if you want to:

- Observe configuration changes in your Claude account
- Maintain visibility into account settings
- Track configuration over time
- Build tooling around Claude account monitoring
- Experiment with automation and observability for Claude services

## Project Status

This project is currently in early development.

Features and architecture may evolve as the project grows.

## Installation

Clone the repository:

```bash
git clone https://github.com/Startrek1977/Claude-Account-Monitor.git
cd Claude-Account-Monitor
```

## Building

To build the project:

```bash
dotnet build src/Claude-Account-Monitor.sln
```

## Testing

The project includes a comprehensive test suite using xUnit to ensure code quality and maintain stability.

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
- **Target Framework:** .NET 8.0 for Windows

### Test Coverage

The test project includes unit tests for:
- Application initialization and lifecycle
- Main window instantiation and functionality
- Core dashboard components

Tests are automatically executed in the CI/CD pipeline on every push and pull request to the main branch.