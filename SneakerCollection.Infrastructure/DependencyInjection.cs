using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Services;
using SneakerCollection.Application.Services.Authentication;

namespace SneakerCollection.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();

    return services;
  }
}