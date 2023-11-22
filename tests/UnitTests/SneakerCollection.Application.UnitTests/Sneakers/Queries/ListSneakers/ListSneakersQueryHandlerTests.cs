using FluentAssertions;
using Moq;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Application.UnitTests.Sneakers.Commands.TestsUtils;
using SneakerCollection.Application.UnitTests.TestUtils.Extensions;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Persistence;

namespace SneakerCollection.Application.UnitTests.Sneakers.Queries.ListSneakers
{
  public class ListSneakersQueryHandlerTests
  {
    private readonly Mock<ISneakerRepository> _mockSneakerRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly ListSneakersQueryHandler _handler;
    private static readonly User _mockUser = ListSneakersQueryUtils._mockUser;
    private static readonly List<Sneaker> _mockSneakers = ListSneakersQueryUtils._mockSneakers;

    public ListSneakersQueryHandlerTests()
    {
      _mockSneakerRepository = new Mock<ISneakerRepository>();
      _mockUserRepository = new Mock<IUserRepository>();
      _handler = new ListSneakersQueryHandler(_mockSneakerRepository.Object, _mockUserRepository.Object);

      _mockUserRepository.Setup(x => x.GetUserById(_mockUser.Id.Value)).Returns(_mockUser);
      _mockSneakerRepository.Setup(x => x.ListSneakersByUserId(_mockUser.Id.Value)).Returns(_mockSneakers.Except(_mockSneakers.Where(s => s.UserId != _mockUser.Id.Value))
      .ToList());
    }

    [Theory]
    [MemberData(nameof(ValidateListSneakersQuerysWithValidUser))]
    public async Task HandleListSneakersQueryHandler_WhenUserIsValid(ListSneakersQuery listSneakersQuery)
    {

      var result = await _handler.Handle(listSneakersQuery, default);

      result.IsError.Should().BeFalse();
      result.Value.Sneakers.Count.Should().Be(1);
      result.Value.ValidateListFrom(listSneakersQuery);
      _mockSneakerRepository.Verify(x => x.ListSneakersByUserId(listSneakersQuery.UserId));
    }

    public static IEnumerable<object[]> ValidateListSneakersQuerysWithValidUser()
    {
      yield return new[] { ListSneakersQueryUtils.ListSneakersQueryWithUserValid() };
    }

    [Theory]
    [MemberData(nameof(ValidateListSneakersQuerysWithInvalidUser))]
    public async Task HandleListSneakersQueryHandler_WhenUserIsInvalid(ListSneakersQuery listSneakersQuery)
    {
      var result = await _handler.Handle(listSneakersQuery, default);

      result.IsError.Should().BeTrue();
    }

    public static IEnumerable<object[]> ValidateListSneakersQuerysWithInvalidUser()
    {
      yield return new[] { ListSneakersQueryUtils.ListSneakersQueryWithUserInvalid() };
    }
  }
}