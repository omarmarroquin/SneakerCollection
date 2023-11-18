using SneakerCollection.Application.Common.Interfaces.Authentication;
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

  public AuthenticationResult Login(string email, string password)
  {
    // Check if user already exists
    if (_userRepository.GetUserByEmail(email) is not User user)
    {
      throw new Exception("User does not exist");
    }

    // Check if password is correct
    if (user.Password != password)
    {
      throw new Exception("Password is incorrect");
    }

    // Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      token
    );
  }

  public AuthenticationResult Register(string email, string password)
  {
    // 1. Check if user already exists
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      throw new Exception("User already exists");
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