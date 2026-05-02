using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence.Contexts;

public static class ContextRegistrationExtension
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
    {
        // använder samma SQLite-databas i både dev och prod
        Console.WriteLine(env.IsDevelopment() ? "Development Environment" : "Production Environment");

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite("Data Source=app.db");
        });

        return services;
    }
}