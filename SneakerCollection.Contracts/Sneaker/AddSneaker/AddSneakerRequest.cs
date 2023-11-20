namespace SneakerCollection.Contracts.Sneaker.AddSneaker;

public record AddSneakerRequest(
  Guid UserId,
  string Name,
  string Brand,
  int Price,
  int Size,
  int Year,
  int Rate
);
