using Core.Domain.Contracts;
using Infrastructure.Persistence.mySQL.Repository;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.mySQL;
public static class MySQLRegistration
{
    public static IServiceCollection AddPostgresPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseMySQL(connectionString);
        });
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostsRepository, PostsRepository>();

        return services;
    }
}