using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
  public static class Sneaker
  {
    public static readonly SneakerId Id = SneakerId.Create(Guid.NewGuid().ToString());
    public static readonly UserId UserId = UserId.Create(Guid.NewGuid().ToString());
    public const string Name = "Test Sneaker";
    public const string Brand = "Test Brand";
    public const int Size = 10;
    public const int Price = 100;
    public const int Year = 2022;
    public const int Rate = 5;

    public static string NameFromIndex(int index) => $"{Name} {index}";
    public static string BrandFromIndex(int index) => $"{Brand} {index}";
    public static int SizeFromIndex(int index) => Size + index;
    public static int PriceFromIndex(int index) => Price + index;
    public static int YearFromIndex(int index) => Year + index;
    public static int RateFromIndex(int index) => Rate + index;
  }
}
