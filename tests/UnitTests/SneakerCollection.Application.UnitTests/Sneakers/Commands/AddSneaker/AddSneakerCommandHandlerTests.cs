using FluentAssertions;
using Moq;
using SneakerCollection.Application.Authentication.Commands.AddSneaker;
using SneakerCollection.Application.Sneakers.Commands.AddSneaker;
using SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;
using SneakerCollection.Application.UnitTests.TestUtils.Extensions;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.AddSneaker
{
  public class AddSneakerCommandHandlerTests
  {
    private readonly Mock<ISneakerRepository> _mockSneakerRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly AddSneakerCommandHandler _handler;

    public AddSneakerCommandHandlerTests()
    {
      _mockSneakerRepository = new Mock<ISneakerRepository>();
      _mockUserRepository = new Mock<IUserRepository>();
      _handler = new AddSneakerCommandHandler(_mockSneakerRepository.Object, _mockUserRepository.Object);

      var _mockUser = AddSneakerCommandUtils._mockUser;
      _mockUserRepository.Setup(x => x.GetUserById(_mockUser.Id.Value)).Returns(_mockUser);
    }

    [Theory]
    [MemberData(nameof(ValidateAddSneakerCommandsWithValidUser))]
    public async Task HandleAddSneakerCommandHandler_WhenUserIsValid(AddSneakerCommand addSneakerCommand)
    {

      var result = await _handler.Handle(addSneakerCommand, default);

      result.IsError.Should().BeFalse();
      result.Value.ValidateCreatedFrom(addSneakerCommand);
      _mockSneakerRepository.Verify(x => x.Add(result.Value.Sneaker));
    }

    public static IEnumerable<object[]> ValidateAddSneakerCommandsWithValidUser()
    {
      yield return new[] { AddSneakerCommandUtils.AddSneakerCommandWithValidUser() };
    }

    [Theory]
    [MemberData(nameof(ValidateAddSneakerCommandsWithInvalidUser))]
    public async Task HandleAddSneakerCommandHandler_WhenUserIsInValid(AddSneakerCommand addSneakerCommand)
    {
      var result = await _handler.Handle(addSneakerCommand, default);

      result.IsError.Should().BeTrue();
    }

    public static IEnumerable<object[]> ValidateAddSneakerCommandsWithInvalidUser()
    {
      yield return new[] { AddSneakerCommandUtils.AddSneakerCommandWithInvalidUser() };
    }
  }
}