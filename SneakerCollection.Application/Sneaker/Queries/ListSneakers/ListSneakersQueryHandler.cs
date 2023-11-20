using ErrorOr;
using MediatR;
using SneakerCollection.Application.Services;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.Authentication.Commands.Register;

public class ListSneakersQueryHandle : IRequestHandler<ListSneakersQuery, ErrorOr<ListSneakersResult>>
{
  private readonly ISneakerRepository _sneakerRepository;

  public ListSneakersQueryHandle(ISneakerRepository sneakerRepository)
  {
    _sneakerRepository = sneakerRepository;
  }

  public Task<ErrorOr<ListSneakersResult>> Handle(
    ListSneakersQuery command,
    CancellationToken cancellationToken)
  {
    var listSneakers = _sneakerRepository.ListSneakersByUserId(command.UserId);

    return Task.FromResult<ErrorOr<ListSneakersResult>>(new ListSneakersResult(
      listSneakers
    ));
  }
}
