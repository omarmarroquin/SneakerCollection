using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Infrastructure.Authentication;
using SneakerCollection.Infrastructure.Services;

namespace SneakerCollection.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    Microsoft.Extensions.Configuration.IConfiguration configuration)
  {
    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    return services;
  }
}