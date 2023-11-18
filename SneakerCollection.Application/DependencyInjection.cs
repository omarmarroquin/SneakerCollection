using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Services;
using SneakerCollection.Application.Services.Authentication;

namespace SneakerCollection.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();

    return services;
  }
}