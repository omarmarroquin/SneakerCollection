using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Services;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.Entities;
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

  public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
  {
    // 1. Check if user already exists
    if (_userRepository.GetUserByEmail(command.Email) is not null)
    {
      return Errors.User.DuplicateEmail;
    }

    // 2. Create user (geneate unique id, hash password, etc.)
    var user = new User
    {
      Email = command.Email,
      Password = command.Password
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
