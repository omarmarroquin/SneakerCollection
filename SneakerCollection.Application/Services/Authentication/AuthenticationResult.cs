namespace SneakerCollection.Application.Services;

public record AuthenticationResult(
  Guid Id,
  string Email,
  string Token
);