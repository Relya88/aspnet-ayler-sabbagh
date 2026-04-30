using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence;

//ansvararr för att skapa db + lägga in testdata
public static class PersistenceDatabaseInitializer
{
    public static async Task InititalizeAsync(IServiceProvider sp, IHostEnvironment env, CancellationToken ct = default)
    {
        using var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        if (env.IsDevelopment())
        {
            await context.Database.EnsureDeletedAsync(ct);
            await context.Database.EnsureCreatedAsync(ct);
        }
        else
        {
            await context.Database.MigrateAsync(ct);
        }

        // testdata ska läggas in om tom, tog hjälp av chatgpt
        if (!context.Memberships.Any())
        {
            context.Memberships.AddRange(
                new MembershipEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Standard",
                    Price = 299,
                    Description = "Basic access to gym equipment"
                },
                new MembershipEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Premium",
                    Price = 499,
                    Description = "Access to all classes and gym"
                }
            );

            await context.SaveChangesAsync(ct);
        }
    }
}
