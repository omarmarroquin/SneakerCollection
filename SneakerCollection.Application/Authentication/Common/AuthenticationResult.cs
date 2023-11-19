using SneakerCollection.Domain.Entities;

namespace SneakerCollection.Application.Services;

public record AuthenticationResult(
  User User,
  string Token
);