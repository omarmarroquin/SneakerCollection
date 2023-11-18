using SneakerCollection.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Application.Services;

namespace SneakerCollection.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }
}
