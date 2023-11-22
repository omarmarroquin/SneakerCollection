using SneakerCollection.Domain.Common.Models;

namespace SneakerCollection.Domain.SneakerAggregate.ValueObjects;

public sealed class SneakerId : ValueObject
{
  public Guid Value { get; }

  public SneakerId(Guid value)
  {
    Value = value;
  }

  public static SneakerId Create(string value)
  {
    return new SneakerId(Guid.Parse(value));
  }

  public static SneakerId CreateUnique()
  {
    return new(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}