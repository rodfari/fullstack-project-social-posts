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

        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    private static void SeedData(DataContext dataContext)
    {
        dataContext.Database.EnsureCreated();
        dataContext.Database.Migrate();

        if (dataContext.User.Any())
        {
            Console.WriteLine("already have data - no need to seed");
            return;
        }

        var usuarios = new List<User>()
            {
                new(){ Id = 1, Username = "Rodrigo"},
                new(){ Id = 2, Username = "Maria"},
                new(){ Id = 3, Username = "Jeniffer"}
            };
        dataContext.AddRange(usuarios);
    }
}