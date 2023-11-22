namespace SneakerCollection.Contracts.Sneaker.UpdateSneaker;

public record UpdateSneakerRouteParamsRequest(
  Guid SneakerId
);
public record UpdateSneakerRequest(
  string Name,
  string Brand,
  int Price,
  int Size,
  int Year,
  int Rate
);
