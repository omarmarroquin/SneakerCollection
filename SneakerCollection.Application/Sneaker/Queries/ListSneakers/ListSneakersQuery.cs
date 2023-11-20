using ErrorOr;
using MediatR;
using SneakerCollection.Application.Services;

namespace SneakerCollection.Application.Authentication.Commands.Register;

public record ListSneakersQuery(
  Guid UserId,
  string? FilterValue,
  string? SortBy
) : IRequest<ErrorOr<ListSneakersResult>>;