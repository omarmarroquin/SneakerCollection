using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Commands.AddSneaker;

public class AddSneakerCommandValidator : AbstractValidator<AddSneakerCommand>
{

  public AddSneakerCommandValidator()
  {
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.Brand).NotEmpty();
    RuleFor(x => x.Price).NotEmpty();
    RuleFor(x => x.Size).NotEmpty();
    RuleFor(x => x.Year).NotEmpty();
    RuleFor(x => x.Rate).NotEmpty();
  }
}