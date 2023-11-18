using ErrorOr;

namespace SneakerCollection.Application.Services;

public interface IAuthenticationService
{
  ErrorOr<AuthenticationResult> Login(string email, string password);
  ErrorOr<AuthenticationResult> Register(string email, string password);
}