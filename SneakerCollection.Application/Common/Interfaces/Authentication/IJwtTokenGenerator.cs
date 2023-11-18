namespace SneakerCollection.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
  string GenerateToken(Guid userId, string email);
}