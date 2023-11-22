using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.UnitTests.TestUtils.Constants;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;

public static class DeleteSneakerCommandUtils
{
  public static readonly User _mockUser = CreateMockUser();
  public static readonly List<Sneaker> _mockSneakers = CreateMockListSneakers(5);
  public static DeleteSneakerCommand DeleteSneakerCommandWithUserAndSneakerValid() =>
    new DeleteSneakerCommand(
      _mockUser.Id.Value,
      _mockSneakers.First().Id.Value);
  public static DeleteSneakerCommand DeleteSneakerCommandWithUserInvalidAndSneakerValid() =>
    new DeleteSneakerCommand(
      Guid.NewGuid(),
      _mockSneakers.First().Id.Value);
  public static DeleteSneakerCommand DeleteSneakerCommandWithUserValidAndSneakerInvalid() =>
    new DeleteSneakerCommand(
      _mockUser.Id.Value,
      Guid.NewGuid());
  public static DeleteSneakerCommand DeleteSneakerCommandWithSneakerNotBelogsToUser() =>
    new DeleteSneakerCommand(
      _mockUser.Id.Value,
      _mockSneakers.ElementAt(2).Id.Value);

  public static User CreateMockUser() =>
    User.Create(Constants.User.Email, Constants.User.Password);

  public static List<Sneaker> CreateMockListSneakers(int skeanerCount) =>
    Enumerable.Range(0, skeanerCount)
      .Select(index => Sneaker.Create(
        index == 0 ? _mockUser.Id.Value : Guid.NewGuid(),
        Constants.Sneaker.Name,
        Constants.Sneaker.Brand,
        Constants.Sneaker.Price,
        Constants.Sneaker.Size,
        Constants.Sneaker.Year,
        Constants.Sneaker.Rate)).ToList();
}