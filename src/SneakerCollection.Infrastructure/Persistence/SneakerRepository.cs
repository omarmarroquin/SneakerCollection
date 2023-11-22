using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;

namespace SneakerCollection.Infrastructure.Persistence;

public class SneakerRepository : ISneakerRepository
{
  private static readonly List<Sneaker> _sneakers = new();

  public List<Sneaker> ListSneakersByUserId(Guid userId)
  {
    return _sneakers
      .Except(_sneakers.Where(s => s.UserId != userId))
      .ToList();
  }

  public Sneaker? GetSneakerById(Guid sneakerId)
  {
    return _sneakers.FirstOrDefault(s => s.Id.Value == sneakerId);
  }

  public void Add(Sneaker sneaker)
  {
    _sneakers.Add(sneaker);
  }

  public void Delete(SneakerId sneakerId)
  {
    var sneakerIndex = _sneakers.FindIndex(s => s.Id == sneakerId);
    _sneakers.RemoveAt(sneakerIndex);
  }
  public void Update(Sneaker sneaker)
  {
    var sneakerIndex = _sneakers.FindIndex(s => s.Id == sneaker.Id);
    _sneakers[sneakerIndex] = sneaker;
  }
}