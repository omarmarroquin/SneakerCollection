namespace SneakerCollection.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  public AuthenticationResult Login(string email, string password)
  {
    return new AuthenticationResult(
      Guid.NewGuid(),
      email,
      "token"
    );
  }

  public AuthenticationResult Register(string email, string password)
  {
    return new AuthenticationResult(
      Guid.NewGuid(),
      email,
      "token"
    );
  }
}