using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core.Application;

public static class ApplicationRegistration {

   public static IServiceCollection AddApplicationService(this IServiceCollection services){
         services.AddScoped<UseCases.CreatePostUseCase>();
         services.AddScoped<UseCases.RepostUseCase>();
         return services;
   }

}