using ClaudeAccountMonitor.Core.Abstractions;
using ClaudeAccountMonitor.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClaudeAccountMonitor.Core.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClaudeAccountMonitorCore(this IServiceCollection services)
    {
        services.AddSingleton<IMonitorService, MonitorService>();
        return services;
    }
}
