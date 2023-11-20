using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers;

public class ListSneakersQueryValidator : AbstractValidator<ListSneakersQuery>
{

  public ListSneakersQueryValidator()
  {
    RuleFor(x => x.FilterValue);
    RuleFor(x => x.SortBy)
      .Must(x => string.IsNullOrEmpty(x) || x == "size" || x == "year" || x == "price")
      .WithMessage("SortBy must be one of the following: size, year, price");
  }
}