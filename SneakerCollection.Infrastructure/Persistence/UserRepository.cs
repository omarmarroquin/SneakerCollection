using SneakerCollection.Domain.Entities;

namespace SneakerCollection.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
  private static readonly List<User> _users = new();
  public void Add(User user)
  {
    _users.Add(user);
  }

  public User? GetUserByEmail(string email)
  {
    return _users.FirstOrDefault(user => user.Email == email);
  }
}