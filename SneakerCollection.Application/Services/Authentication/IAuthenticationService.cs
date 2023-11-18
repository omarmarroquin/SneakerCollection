namespace SneakerCollection.Application.Services;

public interface IAuthenticationService
{
  AuthenticationResult Login(string email, string password);
  AuthenticationResult Register(string email, string password);
}