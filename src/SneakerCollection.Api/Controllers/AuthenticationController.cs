using SneakerCollection.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using SneakerCollection.Application.Authentication.Commands.Register;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Authentication.Queries.Login;

namespace SneakerCollection.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id.Value,
            authResult.User.Email,
            authResult.Token
        );
    }
}
