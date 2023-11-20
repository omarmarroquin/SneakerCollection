using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;

public class DeleteSneakerCommandValidator : AbstractValidator<DeleteSneakerCommand>
{

  public DeleteSneakerCommandValidator()
  {
    RuleFor(x => x.SneakerId).NotEmpty();
  }
}