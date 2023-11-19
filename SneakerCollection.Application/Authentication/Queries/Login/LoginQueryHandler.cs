using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Services;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.Entities;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Commands.Register;

public class LoginQueryHandle : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public LoginQueryHandle(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
  {
    // Check if user don't exists or password is incorrect
    if (_userRepository.GetUserByEmail(command.Email) is not User user || (user.Password != command.Password))
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
}
