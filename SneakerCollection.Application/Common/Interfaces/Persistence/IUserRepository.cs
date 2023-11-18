using SneakerCollection.Domain.Entities;

namespace SneakerCollection.Infrastructure.Persistence;

public interface IUserRepository
{
  User? GetUserByEmail(string email);
  void Add(User user);
}