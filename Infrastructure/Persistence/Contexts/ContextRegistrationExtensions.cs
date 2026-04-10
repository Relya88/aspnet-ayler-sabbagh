using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence.Contexts;

public static class ContextRegistrationExtension
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            //databas för utvecklingsmiljön
            Console.WriteLine("Delevopment Enviroment");
            services.AddSingleton<SqliteConnection>(_ =>
            {
                var connection = new SqliteConnection("Data Source=:memory:");
                connection.Open();
                return connection;
            });

            services.AddDbContext<DataContext>((sp, options) =>
            {
                var connection = sp.GetRequiredService<SqliteConnection>();
                options.UseSqlite(connection);
            });
        }
        else
        {
            //databas för produktionsmiljön
            Console.WriteLine("Production Environment");

            services.AddDbContext<DataContext>((sp, options) =>
            {
                var connection = configuration.GetConnectionString("ProductionDatabaseUri")
                    ?? throw new ArgumentException("Production Database Uri not Provided");

                options.UseSqlServer(connection);
            });

        }

        return services;
    }
}