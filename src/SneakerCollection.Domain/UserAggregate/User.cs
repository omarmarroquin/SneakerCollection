using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
  public string Email { get; set; } = null!;
  public string Password { get; set; } = null!;

  private User(UserId userId, string email, string password) : base(userId)
  {
    Email = email;
    Password = password;
  }

  public static User Create(string email, string password)
  {
    return new(UserId.CreateUnique(), email, password);
  }
}