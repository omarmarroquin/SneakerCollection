using FluentAssertions;
using SneakerCollection.Application.Sneakers.Commands.AddSneaker;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.UnitTests.TestUtils.Extensions;

public static partial class SneakerExtentions
{
  public static void ValidateCreatedFrom(this AddSneakerResult sneaker, AddSneakerCommand command)
  {
    sneaker.Sneaker.Id.Should().NotBeNull();
    sneaker.Sneaker.UserId.Should().Be(command.UserId);
    sneaker.Sneaker.Name.Should().Be(command.Name);
    sneaker.Sneaker.Brand.Should().Be(command.Brand);
    sneaker.Sneaker.Size.Should().Be(command.Size);
    sneaker.Sneaker.Price.Should().Be(command.Price);
    sneaker.Sneaker.Year.Should().Be(command.Year);
    sneaker.Sneaker.Rate.Should().Be(command.Rate);
    sneaker.Sneaker.CreatedAt.Should().Be(sneaker.Sneaker.UpdatedAt);

  }

  public static void ValidateDeletedFrom(this DeleteSneakerResult result, DeleteSneakerCommand command)
  {
    result.SneakerId.Value.Should().Be(command.SneakerId);
  }

  public static void ValidateUpdatedFrom(this UpdateSneakerResult result, UpdateSneakerCommand command)
  {
    result.Sneaker.Id.Value.Should().Be(command.SneakerId);
    result.Sneaker.UserId.Should().Be(command.UserId);
    result.Sneaker.Name.Should().Be(command.Name);
    result.Sneaker.Brand.Should().Be(command.Brand);
    result.Sneaker.Size.Should().Be(command.Size);
    result.Sneaker.Price.Should().Be(command.Price);
    result.Sneaker.Year.Should().Be(command.Year);
    result.Sneaker.Rate.Should().Be(command.Rate);
    result.Sneaker.CreatedAt.Should().NotBe(result.Sneaker.UpdatedAt);
  }

  public static void ValidateListFrom(this ListSneakersResult sneakers, ListSneakersQuery query)
  {
    sneakers.Sneakers.ForEach(sneaker =>
    {
      sneaker.Id.Should().NotBeNull();
      sneaker.UserId.Should().Be(query.UserId);
      sneaker.Name.Should().NotBeNullOrEmpty();
      sneaker.Brand.Should().NotBeNullOrEmpty();
    });
  }
}
