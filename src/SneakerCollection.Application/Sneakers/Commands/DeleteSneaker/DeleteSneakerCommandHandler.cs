using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Commands.DeleteSneaker;

public class DeleteSneakerCommandHandler : IRequestHandler<DeleteSneakerCommand, ErrorOr<DeleteSneakerResult>>
{

  private readonly ISneakerRepository _sneakerRepository;
  private readonly IUserRepository _userRepository;

  public DeleteSneakerCommandHandler(
    ISneakerRepository sneakerRepository,
    IUserRepository userRepository
    )
  {
    _sneakerRepository = sneakerRepository;
    _userRepository = userRepository;
  }

  public Task<ErrorOr<DeleteSneakerResult>> Handle(
    DeleteSneakerCommand command,
    CancellationToken cancellationToken)
  {
    if (_userRepository.GetUserById(command.UserId) is not User)
      return Task.FromResult<ErrorOr<DeleteSneakerResult>>(Errors.User.UserNotFound);

    if (_sneakerRepository.GetSneakerById(command.SneakerId) is not Sneaker sneaker)
      return Task.FromResult<ErrorOr<DeleteSneakerResult>>(Errors.Sneaker.SneakerNotFound);

    if (sneaker.UserId != command.UserId)
      return Task.FromResult<ErrorOr<DeleteSneakerResult>>(Errors.Sneaker.SneakerNotOwnedByUser);

    _sneakerRepository.Delete(sneaker.Id);

    return Task.FromResult<ErrorOr<DeleteSneakerResult>>(new DeleteSneakerResult(
      sneaker.Id
    ));
  }
}
