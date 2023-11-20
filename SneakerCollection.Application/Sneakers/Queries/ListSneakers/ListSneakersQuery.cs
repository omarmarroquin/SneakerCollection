using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;

namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers;

public record ListSneakersQuery(
  Guid UserId,
  string? FilterValue,
  string? SortBy
) : IRequest<ErrorOr<ListSneakersResult>>;