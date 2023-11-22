namespace SneakerCollection.Contracts.Sneaker.AddSneaker;

public record AddSneakerRequest(
  string Name,
  string Brand,
  int Price,
  int Size,
  int Year,
  int Rate
);
