namespace SneakerCollection.Domain.Entities;

public class User
{
  public Guid Id { get; } = Guid.NewGuid();
  public string Email { get; set; } = null!;
  public string Password { get; set; } = null!;
}