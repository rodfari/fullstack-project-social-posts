using Core.Domain.Contracts;
using Infrastructure.Persistence.pgSQL.Repository;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.pgSQL;
public static class PostgresRegistration
{
    public static IServiceCollection AddPostgresPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IRepostRepository, RepostRepository>();
        services.AddScoped<IDailyPostLimitRepository, DailyPostLimitRepository>();

        return services;
    }
}