namespace SneakerCollection.Contracts.Sneaker.UpdateSneaker;

public record UpdateSneakerResponse(
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
