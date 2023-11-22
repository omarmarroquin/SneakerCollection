namespace SneakerCollection.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
  public abstract IEnumerable<object> GetEqualityComponents();

  public override bool Equals(object? obj)
  {
    if (obj is null || GetType() != obj.GetType())
      return false;

    var valueObject = (ValueObject)obj;

    return GetEqualityComponents()
      .SequenceEqual(valueObject.GetEqualityComponents());
  }

  public static bool operator ==(ValueObject? left, ValueObject? right)
  {
    if (left is null ^ right is null)
      return false;

    return left?.Equals(right) != false;
  }

  public static bool operator !=(ValueObject? left, ValueObject? right)
  {
    return !(left == right);
  }

  public override int GetHashCode()
  {
    return GetEqualityComponents()
      .Select(x => x?.GetHashCode() ?? 0)
      .Aggregate((x, y) => x ^ y);
  }

  public bool Equals(ValueObject? other)
  {
    return Equals((object?)other);
  }
}
