namespace SneakerCollection.Contracts.Sneaker.ListSneakers;

public record ListSneakersRequest(
  string? FilterValue,
  string? SortBy
);