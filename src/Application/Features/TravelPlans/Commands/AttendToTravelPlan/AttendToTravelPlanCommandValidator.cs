using FluentValidation;

namespace Application.Features.TravelPlans.Commands.AttendToTravelPlan;

public class AttendToTravelPlanCommandValidator : AbstractValidator<AttendToTravelPlanCommand>
{
  public AttendToTravelPlanCommandValidator()
  {
    RuleFor(p => p.TravelPlanId)
    .NotEmpty()
    .WithMessage("TravelPlanId cannot be empty");
  }
}