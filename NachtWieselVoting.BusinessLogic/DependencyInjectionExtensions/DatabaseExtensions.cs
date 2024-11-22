using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NachtWieselVoting.Data.Contexts;

namespace NachtWieselVoting.BusinessLogic.DependencyInjectionExtensions;

public static class DatabaseExtensions
{
    public static IHostApplicationBuilder AddDatabase(this IHostApplicationBuilder builder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        string sectionName = builder.Environment.EnvironmentName switch
        {
            "DevServer" => "DeployConnection",
            "Production" => "DeployConnection",
            _ => "DefaultConnection",
        };

        var connectionString = builder.Configuration.GetConnectionString(sectionName);

        builder.Services.AddDbContextFactory<NachtWieselVotingDbContext>(options =>
        {
            options.UseNpgsql(connectionString, innerOptions =>
            {
                innerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });

        return builder;
    }

    public static void MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<NachtWieselVotingDbContext>>();
            using var context = dbFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
