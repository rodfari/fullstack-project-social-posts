using Application.Contracts;
using Core.Application.Contracts;
using Core.Application.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class ApplicationRegistration {

   public static IServiceCollection AddApplicationService(this IServiceCollection services){
         services.AddScoped<IPostHandler, PostHandlers>();
         services.AddScoped<IRepostHandler, RepostHandler>();
         services.AddScoped<IUserHandler, UserHandler>();
         return services;
   }
}