using System.ComponentModel;

namespace SneakerCollection.Contracts.Sneaker;

public record ListSneakersRequest(
  string? FilterValue,
  string? SortBy
);