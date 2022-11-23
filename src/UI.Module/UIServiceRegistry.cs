using Lamar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgrammingWithPalermo.ChurchBulletin.Core;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess.Mappings;
using ProgrammingWithPalermo.ChurchBulletin.UI.Api;
using ProgrammingWithPalermo.ChurchBulletin.UI.Server;

namespace UI.Module;

public class UiServiceRegistry : ServiceRegistry
{
    public UiServiceRegistry()
    {
        this.AddScoped<DbContext, DataContext>();
        this.AddDbContextFactory<DataContext>();
        this.AddDbContextFactory<DbContext>();
        this.AddTransient<IDatabaseConfiguration, DatabaseConfiguration>();

        Scan(scanner =>
        {
            scanner.WithDefaultConventions();
            scanner.AssemblyContainingType<CanConnectToDatabaseHealthCheck>();
            scanner.AssemblyContainingType<HealthCheck>();
        });

        this.AddHealthChecks()
            .AddCheck<CanConnectToDatabaseHealthCheck>("DataAccess")
            .AddCheck<HealthCheck>("API");
    }
}