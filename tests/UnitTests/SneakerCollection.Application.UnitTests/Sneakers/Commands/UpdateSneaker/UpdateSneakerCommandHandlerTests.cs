using FluentAssertions;
using Moq;
using SneakerCollection.Application.Authentication.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;
using SneakerCollection.Application.UnitTests.TestUtils.Extensions;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.UpdateSneaker
{
  public class UpdateSneakerCommandHandlerTests
  {
    private readonly Mock<ISneakerRepository> _mockSneakerRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UpdateSneakerCommandHandler _handler;
    private static readonly User _mockUser = UpdateSneakerCommandUtils._mockUser;
    private static readonly List<Sneaker> _mockSneakers = UpdateSneakerCommandUtils._mockSneakers;

    public UpdateSneakerCommandHandlerTests()
    {
      _mockSneakerRepository = new Mock<ISneakerRepository>();
      _mockUserRepository = new Mock<IUserRepository>();
      _handler = new UpdateSneakerCommandHandler(_mockSneakerRepository.Object, _mockUserRepository.Object);

      _mockUserRepository.Setup(x => x.GetUserById(_mockUser.Id.Value)).Returns(_mockUser);
      _mockSneakerRepository.Setup(x => x.GetSneakerById(_mockSneakers.First().Id.Value)).Returns(_mockSneakers.First());
    }

    [Theory]
    [MemberData(nameof(ValidateUpdateSneakerCommandsWithUserAndSnekaerValid))]
    public async Task HandleUpdateSneakerCommandHandler_WhenUserAndSneakerAreValid(UpdateSneakerCommand deleteSneakerCommand)
    {

      var result = await _handler.Handle(deleteSneakerCommand, default);

      result.IsError.Should().BeFalse();
      result.Value.ValidateUpdatedFrom(deleteSneakerCommand);
      _mockSneakerRepository.Verify(x => x.Update(result.Value.Sneaker));
    }

    public static IEnumerable<object[]> ValidateUpdateSneakerCommandsWithUserAndSnekaerValid()
    {
      yield return new[] { UpdateSneakerCommandUtils.UpdateSneakerCommandWithUserAndSneakerValid() };
    }

    [Theory]
    [MemberData(nameof(ValidateUpdateSneakerCommandsWithUserInvalidAndSneakerValid))]
    public async Task HandleUpdateSneakerCommandHandler_WhenUserOrSneakerAreInvalid(UpdateSneakerCommand deleteSneakerCommand)
    {

      var result = await _handler.Handle(deleteSneakerCommand, default);

      result.IsError.Should().BeTrue();
    }

    public static IEnumerable<object[]> ValidateUpdateSneakerCommandsWithUserInvalidAndSneakerValid()
    {
      yield return new[] { UpdateSneakerCommandUtils.UpdateSneakerCommandWithUserInvalidAndSneakerValid() };
      yield return new[] { UpdateSneakerCommandUtils.UpdateSneakerCommandWithUserValidAndSneakerInvalid() };
      yield return new[] { UpdateSneakerCommandUtils.UpdateSneakerCommandWithSneakerNotBelogsToUser() };
    }
  }
}