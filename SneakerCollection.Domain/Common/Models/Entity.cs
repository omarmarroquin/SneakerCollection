namespace SneakerCollection.Domain.Common.Models;

public abstract class Entity<Tid> : IEquatable<Entity<Tid>>
  where Tid : notnull
{
  public Tid Id { get; protected set; } = default!;

  protected Entity(Tid id)
  {
    Id = id;
  }

  public override bool Equals(object? obj)
  {
    return obj is Entity<Tid> entity &&
           EqualityComparer<Tid>.Default.Equals(Id, entity.Id);
  }

  public static bool operator ==(Entity<Tid>? left, Entity<Tid>? right)
  {
    return EqualityComparer<Entity<Tid>>.Default.Equals(left, right);
  }

  public static bool operator !=(Entity<Tid>? left, Entity<Tid>? right)
  {
    return !(left == right);
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }

  public bool Equals(Entity<Tid>? other)
  {
    return Equals((object?)other);
  }
}