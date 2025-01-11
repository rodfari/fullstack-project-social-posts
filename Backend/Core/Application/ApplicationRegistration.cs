using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class ApplicationRegistration {

   public static IServiceCollection AddApplicationService(this IServiceCollection services){
         services.AddMediatR(Assembly.GetExecutingAssembly());
         return services;
   }
}