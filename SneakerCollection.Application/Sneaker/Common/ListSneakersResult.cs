using SneakerCollection.Domain.Entities;

namespace SneakerCollection.Application.Services;

public record ListSneakersResult(
  List<Sneaker> Sneakers
);