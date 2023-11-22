using ErrorOr;
using MediatR;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Queries.Login;

public class LoginQueryHandle : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public LoginQueryHandle(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
  {
    if (_userRepository.GetUserByEmail(command.Email) is not User user || (user.Password != command.Password))
      return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.Authentication.InvalidCredentials);

    var token = _jwtTokenGenerator.GenerateToken(user);

    return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(
      user,
      token
    ));
  }
}
