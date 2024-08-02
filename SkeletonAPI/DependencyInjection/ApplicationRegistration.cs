using Microsoft.Extensions.Configuration;
using SkeletonAPI.DataAccess;

namespace SkeletonAPI.DependencyInjection;

public static class ApplicationRegistration
{
    public static void RegisterServices(this IServiceCollection services, IHostEnvironment env, IConfiguration configuration)
    {
        services.Configure<MongoConfig>(config =>
        {
            IConfigurationSection section = configuration.GetRequiredSection("MongoConfig");
            section.Bind(config);
        });

        //Repositories
        services.AddTransient<UserRepository>();
    }
}
