using Application.Repository.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Hub_API.Settings
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddTenancy(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddScoped<ITenantService, TenantService>();

            services.Configure<TenantSettings>(configuration.GetSection(nameof(TenantSettings)));

            TenantSettings options = new();
            configuration.GetSection(nameof(TenantSettings)).Bind(options);

            var defaultDbProvider = options.Defaults.DBProvider;

            if (defaultDbProvider.ToLower() == "mssql")
            {
                services.AddDbContext<HUB_Context>(m => m.UseSqlServer(connectionString: options.Defaults.ConnectionString));
            }
         
            //using var scope = services.BuildServiceProvider().CreateScope();
            //var dbContext = scope.ServiceProvider.GetRequiredService<HUB_Context>();

            //   dbContext.Database.SetConnectionString(options.Defaults.ConnectionString);
            //Services.AddDbContext<HUB_Context>(options =>
            //    options.UseSqlServer(
            //        builder.Configuration.GetConnectionString(options.Defaults.ConnectionString)));
            //foreach (var tenant in options.Tenants)
            //{
            //    var connectionString = tenant.ConnectionString ?? options.Defaults.ConnectionString;

            //    using var scope = services.BuildServiceProvider().CreateScope();
            //    var dbContext = scope.ServiceProvider.GetRequiredService<HUB_Context>();

            //    dbContext.Database.SetConnectionString(connectionString);

            //    if (dbContext.Database.GetPendingMigrations().Any())
            //    {
            //        dbContext.Database.Migrate();
            //    }
            //}

            return services;
        }
    }
}