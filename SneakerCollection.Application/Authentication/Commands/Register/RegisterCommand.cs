using ErrorOr;
using MediatR;
using SneakerCollection.Application.Services;

namespace SneakerCollection.Application.Authentication.Commands.Register;

public record RegisterCommand(
  string Email,
  string Password
) : IRequest<ErrorOr<AuthenticationResult>>;