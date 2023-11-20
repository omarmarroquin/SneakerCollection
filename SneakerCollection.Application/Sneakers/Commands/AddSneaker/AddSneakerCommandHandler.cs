using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Commands.AddSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Commands.AddSneaker;

public class AddSneakerCommandHandle : IRequestHandler<AddSneakerCommand, ErrorOr<AddSneakerResult>>
{

  private readonly ISneakerRepository _sneakerRepository;
  private readonly IUserRepository _userRepository;

  public AddSneakerCommandHandle(
    ISneakerRepository sneakerRepository,
    IUserRepository userRepository
    )
  {
    _sneakerRepository = sneakerRepository;
    _userRepository = userRepository;
  }

  public Task<ErrorOr<AddSneakerResult>> Handle(
    AddSneakerCommand command,
    CancellationToken cancellationToken)
  {
    if (_userRepository.GetUserById(command.UserId) is not User)
      return Task.FromResult<ErrorOr<AddSneakerResult>>(Errors.User.UserNotFound);

    var sneaker = Sneaker.Create(
      command.UserId,
      command.Name,
      command.Brand,
      command.Size,
      command.Price,
      command.Year,
      command.Rate);

    _sneakerRepository.Add(sneaker);

    return Task.FromResult<ErrorOr<AddSneakerResult>>(new AddSneakerResult(
      sneaker
    ));
  }
}
