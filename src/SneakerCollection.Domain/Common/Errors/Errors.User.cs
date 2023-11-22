using ErrorOr;

namespace SneakerCollection.Domain.Common.Errors;

public static partial class Errors
{
  public static class User
  {
    public static Error DuplicateEmail = Error.Conflict(
      code: "User.DuplicateEmail",
      description: "Email already exists."
    );

    public static Error UserNotFound = Error.NotFound(
      code: "User.UserNotFound",
      description: "User not found."
    );
  }
}