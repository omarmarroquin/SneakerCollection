namespace SneakerCollection.Contracts.Authentication;

public record RegisterRequest(
  string Email,
  string Password
);