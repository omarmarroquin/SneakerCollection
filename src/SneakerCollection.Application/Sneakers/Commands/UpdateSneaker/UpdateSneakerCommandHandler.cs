using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Commands.UpdateSneaker;

public class UpdateSneakerCommandHandler : IRequestHandler<UpdateSneakerCommand, ErrorOr<UpdateSneakerResult>>
{

  private readonly ISneakerRepository _sneakerRepository;
  private readonly IUserRepository _userRepository;

  public UpdateSneakerCommandHandler(
    ISneakerRepository sneakerRepository,
    IUserRepository userRepository
    )
  {
    _sneakerRepository = sneakerRepository;
    _userRepository = userRepository;
  }

  public Task<ErrorOr<UpdateSneakerResult>> Handle(
    UpdateSneakerCommand command,
    CancellationToken cancellationToken)
  {
    if (_userRepository.GetUserById(command.UserId) is not User)
      return Task.FromResult<ErrorOr<UpdateSneakerResult>>(Errors.User.UserNotFound);

    if (_sneakerRepository.GetSneakerById(command.SneakerId) is not Sneaker sneaker)
      return Task.FromResult<ErrorOr<UpdateSneakerResult>>(Errors.Sneaker.SneakerNotFound);

    if (sneaker.UserId != command.UserId)
      return Task.FromResult<ErrorOr<UpdateSneakerResult>>(Errors.Sneaker.SneakerNotOwnedByUser);

    var updatedSneaker = Sneaker.Update(
      sneaker,
      new Sneaker.UpdateSneakerNewData(
        command.Name,
        command.Brand,
        command.Price,
        command.Size,
        command.Year,
        command.Rate
      ));

    _sneakerRepository.Update(updatedSneaker);

    return Task.FromResult<ErrorOr<UpdateSneakerResult>>(new UpdateSneakerResult(
      updatedSneaker
    ));
  }
}
