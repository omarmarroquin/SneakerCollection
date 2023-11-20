using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;

namespace SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;

public record DeleteSneakerCommand(
  Guid UserId,
  Guid SneakerId
) : IRequest<ErrorOr<DeleteSneakerResult>>;
