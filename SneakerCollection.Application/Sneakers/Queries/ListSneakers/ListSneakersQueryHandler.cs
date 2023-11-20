using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers;

public class ListSneakersQueryHandle : IRequestHandler<ListSneakersQuery, ErrorOr<ListSneakersResult>>
{
  private readonly ISneakerRepository _sneakerRepository;
  private readonly IUserRepository _userRepository;

  public ListSneakersQueryHandle(ISneakerRepository sneakerRepository, IUserRepository userRepository)
  {
    _sneakerRepository = sneakerRepository;
    _userRepository = userRepository;
  }

  public Task<ErrorOr<ListSneakersResult>> Handle(
    ListSneakersQuery command,
    CancellationToken cancellationToken)
  {
    if (_userRepository.GetUserById(command.UserId) is not User user)
      return Task.FromResult<ErrorOr<ListSneakersResult>>(Errors.User.UserNotFound);

    List<Sneaker> listSneakers = _sneakerRepository.ListSneakersByUserId(user.Id.Value);

    return Task.FromResult<ErrorOr<ListSneakersResult>>(new ListSneakersResult(
      listSneakers
    ));
  }
}
