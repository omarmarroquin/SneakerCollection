using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Infrastructure.Persistence;

public interface ISneakerRepository
{
  List<Sneaker> ListSneakersByUserId(Guid userId);
  Sneaker? GetSneakerById(Guid sneakerId);
  void Add(Sneaker sneaker);
  void Update(Sneaker sneakers);
  void Delete(Sneaker sneaker);
}