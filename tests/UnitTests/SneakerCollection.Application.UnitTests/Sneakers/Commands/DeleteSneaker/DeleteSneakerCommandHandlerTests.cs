using FluentAssertions;
using Moq;
using SneakerCollection.Application.Authentication.Commands.DeleteSneaker;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;
using SneakerCollection.Application.UnitTests.TestUtils.Extensions;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.DeleteSneaker
{
  public class DeleteSneakerCommandHandlerTests
  {
    private readonly Mock<ISneakerRepository> _mockSneakerRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly DeleteSneakerCommandHandler _handler;
    private static readonly User _mockUser = DeleteSneakerCommandUtils._mockUser;
    private static readonly List<Sneaker> _mockSneakers = DeleteSneakerCommandUtils._mockSneakers;

    public DeleteSneakerCommandHandlerTests()
    {
      _mockSneakerRepository = new Mock<ISneakerRepository>();
      _mockUserRepository = new Mock<IUserRepository>();
      _handler = new DeleteSneakerCommandHandler(_mockSneakerRepository.Object, _mockUserRepository.Object);

      _mockUserRepository.Setup(x => x.GetUserById(_mockUser.Id.Value)).Returns(_mockUser);
      _mockSneakerRepository.Setup(x => x.GetSneakerById(_mockSneakers.First().Id.Value)).Returns(_mockSneakers.First());
    }

    [Theory]
    [MemberData(nameof(ValidateDeleteSneakerCommandsWithUserAndSnekaerValid))]
    public async Task HandleDeleteSneakerCommandHandler_WhenUserAndSneakerAreValid(DeleteSneakerCommand deleteSneakerCommand)
    {

      var result = await _handler.Handle(deleteSneakerCommand, default);

      result.IsError.Should().BeFalse();
      result.Value.ValidateDeletedFrom(deleteSneakerCommand);
      _mockSneakerRepository.Verify(x => x.Delete(result.Value.SneakerId));
    }

    public static IEnumerable<object[]> ValidateDeleteSneakerCommandsWithUserAndSnekaerValid()
    {
      yield return new[] { DeleteSneakerCommandUtils.DeleteSneakerCommandWithUserAndSneakerValid() };
    }

    [Theory]
    [MemberData(nameof(ValidateDeleteSneakerCommandsWithUserInvalidAndSneakerValid))]
    public async Task HandleDeleteSneakerCommandHandler_WhenUserOrSneakerAreInvalid(DeleteSneakerCommand deleteSneakerCommand)
    {

      var result = await _handler.Handle(deleteSneakerCommand, default);

      result.IsError.Should().BeTrue();
    }

    public static IEnumerable<object[]> ValidateDeleteSneakerCommandsWithUserInvalidAndSneakerValid()
    {
      yield return new[] { DeleteSneakerCommandUtils.DeleteSneakerCommandWithUserInvalidAndSneakerValid() };
      yield return new[] { DeleteSneakerCommandUtils.DeleteSneakerCommandWithUserValidAndSneakerInvalid() };
      yield return new[] { DeleteSneakerCommandUtils.DeleteSneakerCommandWithSneakerNotBelogsToUser() };
    }
  }
}