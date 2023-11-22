using System.Data;
using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;

public class UpdateSneakerCommandValidator : AbstractValidator<UpdateSneakerCommand>
{

  public UpdateSneakerCommandValidator()
  {
    RuleFor(x => x.SneakerId).NotEmpty();
    RuleFor(x => x.UserId).NotEmpty();
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.Brand).NotEmpty();
    RuleFor(x => x.Price).NotEmpty();
    RuleFor(x => x.Size).NotEmpty();
    RuleFor(x => x.Year).NotEmpty();
    RuleFor(x => x.Rate).NotEmpty();
  }
}