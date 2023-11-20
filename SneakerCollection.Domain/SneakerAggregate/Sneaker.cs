using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.User.ValuesObjects;

namespace SneakerCollection.Domain.Entities;

public sealed class Sneaker : AggregateRoot<SneakerId>
{
  public UserId UserId { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string Brand { get; set; } = null!;
  public int Price { get; set; }
  public int Size { get; set; }
  public int Year { get; set; }
  public int Rate { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public Sneaker(
    SneakerId senakerId,
    UserId userId,
    string name,
    string brand,
    int price,
    int size,
    int rate,
    DateTime createdAt,
    DateTime updatedAt) : base(senakerId)
  {
    UserId = userId;
    Name = name;
    Brand = brand;
    Price = price;
    Size = size;
    Rate = rate;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public static Sneaker Create(
    UserId userId,
    string name,
    string brand,
    int price,
    int size,
    int rate)
  {
    return new(
      SneakerId.CreateUnique(),
      userId,
      name,
      brand,
      price,
      size,
      rate,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}