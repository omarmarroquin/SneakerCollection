namespace SneakerCollection.Contracts.Sneaker.AddSneaker;

public record AddSneakerResponse(
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
