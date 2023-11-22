using ErrorOr;
using MediatR;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Commands.Register;

public class RegisterCommandHandle : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public RegisterCommandHandle(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
  {
    if (_userRepository.GetUserByEmail(command.Email) is not null)
      return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateEmail);

    var user = User.Create(command.Email, command.Password);

    _userRepository.Add(user);

    var token = _jwtTokenGenerator.GenerateToken(user);

    return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(
      user,
      token
    ));
  }
}
