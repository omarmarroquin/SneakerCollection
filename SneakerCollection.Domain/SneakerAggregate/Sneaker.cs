using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;

namespace SneakerCollection.Domain.SneakerAggregate;

public sealed class Sneaker : AggregateRoot<SneakerId>
{
  public Guid UserId { get; set; }
  public string Name { get; set; } = null!;
  public string Brand { get; set; } = null!;
  public int Price { get; set; }
  public int Size { get; set; }
  public int Year { get; set; }
  public int Rate { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  private Sneaker(
    SneakerId sneakerId,
    Guid userId,
    string name,
    string brand,
    int price,
    int size,
    int rate,
    int year,
    DateTime createdAt,
    DateTime updatedAt) : base(sneakerId)
  {
    UserId = userId;
    Name = name;
    Brand = brand;
    Price = price;
    Size = size;
    Rate = rate;
    Year = year;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public static Sneaker Create(
    Guid userId,
    string name,
    string brand,
    int price,
    int size,
    int rate,
    int year)
  {
    return new(
      SneakerId.CreateUnique(),
      userId,
      name,
      brand,
      price,
      size,
      rate,
      year,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}