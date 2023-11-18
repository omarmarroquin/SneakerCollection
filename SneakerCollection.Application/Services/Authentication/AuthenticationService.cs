using SneakerCollection.Application.Common.Interfaces.Authentication;

namespace SneakerCollection.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public AuthenticationResult Login(string email, string password)
  {
    // Check if user already exists

    // Create user (geneate unique id, hash password, etc.)

    // Create JWT token
    Guid userId = Guid.NewGuid();
    var token = _jwtTokenGenerator.GenerateToken(userId, email);

    return new AuthenticationResult(
      Guid.NewGuid(),
      email,
      token
    );
  }

  public AuthenticationResult Register(string email, string password)
  {
    // Check if user already exists

    // Create user (geneate unique id, hash password, etc.)

    // Create JWT token
    Guid userId = Guid.NewGuid();
    var token = _jwtTokenGenerator.GenerateToken(userId, email);

    return new AuthenticationResult(
      Guid.NewGuid(),
      email,
      token
    );
  }
}