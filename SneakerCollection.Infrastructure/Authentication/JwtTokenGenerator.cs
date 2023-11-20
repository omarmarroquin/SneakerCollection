using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Domain.Entities;

namespace SneakerCollection.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
  private readonly JwtSettings _jwtSettings;
  private readonly IDateTimeProvider _dateTimeProvider;

  public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> JwtOptions)
  {
    _dateTimeProvider = dateTimeProvider;
    _jwtSettings = JwtOptions.Value;
  }

  public string GenerateToken(User user)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_jwtSettings.Secret)
      ),
      SecurityAlgorithms.HmacSha256
    );

    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
      new Claim(JwtRegisteredClaimNames.Email, user.Email),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var securityToken = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
      claims: claims,
      signingCredentials: signingCredentials
    );

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}