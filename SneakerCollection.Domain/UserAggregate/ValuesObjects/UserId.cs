using SneakerCollection.Domain.Common.Models;

namespace SneakerCollection.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
  public Guid Value { get; }

  public UserId(Guid value)
  {
    Value = value;
  }

  public static UserId CreateUnique()
  {
    return new(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}