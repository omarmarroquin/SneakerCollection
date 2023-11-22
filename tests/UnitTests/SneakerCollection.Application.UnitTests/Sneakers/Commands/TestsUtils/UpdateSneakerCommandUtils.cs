using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.UnitTests.TestUtils.Constants;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;

public static class UpdateSneakerCommandUtils
{
  public static readonly User _mockUser = CreateMockUser();
  public static readonly List<Sneaker> _mockSneakers = CreateMockListSneakers(5);
  public static UpdateSneakerCommand UpdateSneakerCommandWithUserAndSneakerValid() =>
    new UpdateSneakerCommand(
      _mockUser.Id.Value,
      _mockSneakers.First().Id.Value,
      Constants.Sneaker.Name,
      Constants.Sneaker.Brand,
      Constants.Sneaker.Price,
      Constants.Sneaker.Size,
      Constants.Sneaker.Year,
      Constants.Sneaker.Rate);
  public static UpdateSneakerCommand UpdateSneakerCommandWithUserInvalidAndSneakerValid() =>
    new UpdateSneakerCommand(
      Guid.NewGuid(),
      _mockSneakers.First().Id.Value,
      Constants.Sneaker.Name,
      Constants.Sneaker.Brand,
      Constants.Sneaker.Price,
      Constants.Sneaker.Size,
      Constants.Sneaker.Year,
      Constants.Sneaker.Rate);
  public static UpdateSneakerCommand UpdateSneakerCommandWithUserValidAndSneakerInvalid() =>
    new UpdateSneakerCommand(
      _mockUser.Id.Value,
      Guid.NewGuid(),
      Constants.Sneaker.Name,
      Constants.Sneaker.Brand,
      Constants.Sneaker.Price,
      Constants.Sneaker.Size,
      Constants.Sneaker.Year,
      Constants.Sneaker.Rate);
  public static UpdateSneakerCommand UpdateSneakerCommandWithSneakerNotBelogsToUser() =>
    new UpdateSneakerCommand(
      _mockUser.Id.Value,
      _mockSneakers.ElementAt(2).Id.Value,
      Constants.Sneaker.Name,
      Constants.Sneaker.Brand,
      Constants.Sneaker.Price,
      Constants.Sneaker.Size,
      Constants.Sneaker.Year,
      Constants.Sneaker.Rate);

  public static User CreateMockUser() =>
    User.Create(Constants.User.Email, Constants.User.Password);

  public static List<Sneaker> CreateMockListSneakers(int skeanerCount) =>
    Enumerable.Range(0, skeanerCount)
      .Select(index => Sneaker.Create(
        index == 0 ? _mockUser.Id.Value : Guid.NewGuid(),
        Constants.Sneaker.NameFromIndex(index),
        Constants.Sneaker.BrandFromIndex(index),
        Constants.Sneaker.PriceFromIndex(index),
        Constants.Sneaker.SizeFromIndex(index),
        Constants.Sneaker.YearFromIndex(index),
        Constants.Sneaker.RateFromIndex(index))).ToList();
}
