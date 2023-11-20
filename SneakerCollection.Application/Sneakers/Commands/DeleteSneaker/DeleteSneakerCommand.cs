using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;

namespace SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;

public record DeleteSneakerCommand(
  Guid SneakerId,
  Guid UserId
) : IRequest<ErrorOr<DeleteSneakerResult>>;
