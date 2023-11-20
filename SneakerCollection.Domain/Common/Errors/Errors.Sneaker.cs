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
  }
}