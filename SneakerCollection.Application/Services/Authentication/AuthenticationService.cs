using ErrorOr;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.Entities;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public ErrorOr<AuthenticationResult> Login(string email, string password)
  {
    // Check if user don't exists or password is incorrect
    if (_userRepository.GetUserByEmail(email) is not User user || (user.Password != password))
    {
      return Errors.Authentication.InvalidCredentials;
    }

    // Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      token
    );
  }

  public ErrorOr<AuthenticationResult> Register(string email, string password)
  {
    // 1. Check if user already exists
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      return Errors.User.DuplicateEmail;
    }

    // 2. Create user (geneate unique id, hash password, etc.)
    var user = new User
    {
      Email = email,
      Password = password
    };
    _userRepository.Add(user);

    // 3. Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      token
    );
  }
}