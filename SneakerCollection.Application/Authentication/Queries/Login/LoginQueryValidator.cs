using FluentValidation;

namespace SneakerCollection.Application.Authentication.Commands.Register;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{

  public LoginQueryValidator()
  {
    RuleFor(x => x.Email).NotEmpty().EmailAddress();
    RuleFor(x => x.Password).NotEmpty();
  }
}