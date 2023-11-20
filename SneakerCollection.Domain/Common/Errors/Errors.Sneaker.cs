using ErrorOr;

namespace SneakerCollection.Domain.Common.Errors;

public static partial class Errors
{
  public static class Sneaker
  {
    public static Error SneakerNotFound = Error.NotFound(
      code: "Sneaker.SneakerNotFound",
      description: "Sneaker not found."
    );

    public static Error SneakerNotOwnedByUser = Error.Unauthorized(
      code: "Sneaker.SneakerNotOwnedByUser",
      description: "Sneaker not owned by user."
    );
  }
}