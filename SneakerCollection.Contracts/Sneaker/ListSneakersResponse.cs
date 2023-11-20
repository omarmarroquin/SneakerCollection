namespace SneakerCollection.Contracts.Sneaker;

public record SneakerResponse(
  Guid Id,
  Guid UserId,
  string Name,
  string Brand,
  int Price,
  int Size,
  int Year,
  int Rate,
  DateTime CreatedAt,
  DateTime UpdatedAt
);

public record ListSneakersResponse(
  List<SneakerResponse> Sneakers
);