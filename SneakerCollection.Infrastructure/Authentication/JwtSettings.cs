namespace SneakerCollection.Infrastructure.Authentication;

public class JwtSettings
{
  public const string SectionName = "JwtSettings";
  public required string Secret { get; set; }
  public int ExpirationInMinutes { get; set; }
  public required string Issuer { get; set; }
  public required string Audience { get; set; }
}