using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Infrastructure.Persistence;

public class SneakerRepository : ISneakerRepository
{
  private static readonly List<Sneaker> _sneaker = new();

  public List<Sneaker> ListSneakersByUserId(Guid userId)
  {
    return _sneaker
      .Except(_sneaker.Where(s => s.UserId != userId))
      .ToList();
  }

  public Sneaker? GetSneakerById(Guid sneakerId)
  {
    return _sneaker.FirstOrDefault(s => s.Id.Value == sneakerId);
  }

  public void Add(Sneaker sneaker)
  {
    _sneaker.Add(sneaker);
  }

  public void Delete(Sneaker sneaker)
  {
    _sneaker.Remove(sneaker);
  }
  public void Update(Sneaker sneaker)
  {
    var sneakerIndex = _sneaker.FindIndex(s => s.Id == sneaker.Id);
    _sneaker[sneakerIndex] = sneaker;
  }
}