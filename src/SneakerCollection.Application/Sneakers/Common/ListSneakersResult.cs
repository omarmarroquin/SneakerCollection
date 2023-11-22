using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Common;

public record ListSneakersResult(
  List<Sneaker> Sneakers
);