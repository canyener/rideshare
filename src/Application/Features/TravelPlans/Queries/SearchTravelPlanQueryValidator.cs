using FluentValidation;

namespace Application.Features.TravelPlans.Queries;

public class SearchTravelPlanQueryValidator : AbstractValidator<SearchTravelPlanQuery>
{
  public SearchTravelPlanQueryValidator()
  {
    RuleFor(p => p.DepartureCity)
    .NotEmpty()
    .WithMessage("DepartureCity cannot be empty");

    RuleFor(p => p.DestinationCity)
    .NotEmpty()
    .WithMessage("DepartureCity cannot be empty");
  }
}