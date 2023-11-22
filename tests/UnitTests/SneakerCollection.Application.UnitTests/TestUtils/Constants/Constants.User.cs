using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
  public static class User
  {
    public static readonly UserId Id = UserId.Create(Guid.NewGuid().ToString());
    public const string Email = "test@test.com";
    public const string Password = "Test1234!";
  }
}
