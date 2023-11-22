using SneakerCollection.Application.Sneakers.Commands.AddSneaker;
using SneakerCollection.Application.UnitTests.TestUtils.Constants;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;

public static class AddSneakerCommandUtils
{
  public static readonly User _mockUser = CreateMockUser();
  public static AddSneakerCommand AddSneakerCommandWithValidUser() =>
    new AddSneakerCommand(
      _mockUser.Id.Value,
      Constants.Sneaker.Name,
      Constants.Sneaker.Brand,
      Constants.Sneaker.Price,
      Constants.Sneaker.Size,
      Constants.Sneaker.Year,
      Constants.Sneaker.Rate);

  public static AddSneakerCommand AddSneakerCommandWithInvalidUser() =>
    new AddSneakerCommand(
      Guid.NewGuid(),
      Constants.Sneaker.Name,
      Constants.Sneaker.Brand,
      Constants.Sneaker.Price,
      Constants.Sneaker.Size,
      Constants.Sneaker.Year,
      Constants.Sneaker.Rate);

  public static User CreateMockUser() =>
    User.Create(Constants.User.Email, Constants.User.Password);
}