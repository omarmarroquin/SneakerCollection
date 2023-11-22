using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;

namespace SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;

public record UpdateSneakerCommand(
  Guid UserId,
  Guid SneakerId,
  string Name,
  string Brand,
  int Price,
  int Size,
  int Year,
  int Rate
) : IRequest<ErrorOr<UpdateSneakerResult>>;