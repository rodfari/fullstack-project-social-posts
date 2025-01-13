using Core.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.pgSQL;

public class DbInitializer
{
    public static void SeedData(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetRequiredService<DataContext>());
    }

    private static void SeedData(DataContext dataContext)
    {
        // dataContext.Database.EnsureCreated();
        // dataContext.Database.Migrate();

        if (dataContext.User.Any())
        {
            Console.WriteLine("already have data - no need to seed");
            return;
        }

        var usuarios = new List<User>()
            {
                new(){  Username = "Rodrigo", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},    
                new(){  Username = "Maria", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},  
                new(){  Username = "Jeniffer", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Hector", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Ronney", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Bruna", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Carla", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Jhony", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "James", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
            };

        dataContext.AddRange(usuarios);
        dataContext.SaveChanges();
        Console.WriteLine("Users created");
    }
}