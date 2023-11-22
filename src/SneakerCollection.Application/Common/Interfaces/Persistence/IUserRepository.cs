using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Infrastructure.Persistence;

public interface IUserRepository
{
  User? GetUserByEmail(string email);
  User? GetUserById(Guid id);
  void Add(User user);
}
