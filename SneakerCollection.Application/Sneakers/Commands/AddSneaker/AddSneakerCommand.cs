using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;

namespace SneakerCollection.Application.Sneakers.Commands.AddSneaker;

public record AddSneakerCommand(
  Guid UserId,
  string Name,
  string Brand,
  int Price,
  int Size,
  int Year,
  int Rate
) : IRequest<ErrorOr<AddSneakerResult>>;