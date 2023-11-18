using SneakerCollection.Domain.Entities;

namespace SneakerCollection.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
  string GenerateToken(User user);
}