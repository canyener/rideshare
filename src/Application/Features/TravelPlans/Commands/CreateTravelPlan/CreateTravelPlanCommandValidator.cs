using FluentValidation;

namespace Application.Features.TravelPlans.Commands.CreateTravelPlan;

public class CreateTravelPlanCommandValidator : AbstractValidator<CreateTravelPlanCommand>
{
  public CreateTravelPlanCommandValidator()
  {
    RuleFor(p => p.Email)
    .NotEmpty()
    .WithMessage("Email can not be empty");

    RuleFor(p => p.DepartureCity)
    .NotEmpty()
    .WithMessage("DepartureCity can not be empty");

    RuleFor(p => p.DestinationCity)
    .NotEmpty()
    .WithMessage("DestinationCity cannot be empty");

    RuleFor(p => p.AvailableSeatCount)
    .GreaterThan(0)
    .WithMessage("AvailableSeatCount must be greater than 0")
    .NotEmpty()
    .WithMessage("AvailableSeatCount cannot be empty");

    RuleFor(p => p.DepartureDate)
    .GreaterThan(DateTime.Now)
    .WithMessage("DepartureDate should be greater than today")
    .NotEmpty()
    .WithMessage("DepartureDate cannot be empty");
  }
}