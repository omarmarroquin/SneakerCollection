using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;

public class DeleteSneakerCommandValidator : AbstractValidator<DeleteSneakerCommand>
{

  public DeleteSneakerCommandValidator()
  {
    RuleFor(x => x.UserId).NotEmpty();
    RuleFor(x => x.SneakerId).NotEmpty();
  }
}