using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Common;

public record DeleteSneakerResult(
  SneakerId SneakerId);