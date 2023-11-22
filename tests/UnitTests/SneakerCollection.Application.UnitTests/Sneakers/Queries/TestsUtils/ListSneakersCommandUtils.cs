using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Application.UnitTests.TestUtils.Constants;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;

public static class ListSneakersQueryUtils
{
  public static readonly User _mockUser = CreateMockUser();
  public static readonly List<Sneaker> _mockSneakers = CreateMockListSneakers(5);
  public static ListSneakersQuery ListSneakersQueryWithUserValid() =>
    new ListSneakersQuery(
      _mockUser.Id.Value,
      null,
      null);
  public static ListSneakersQuery ListSneakersQueryWithUserInvalid() =>
    new ListSneakersQuery(
      Guid.NewGuid(),
      null,
      null);

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
