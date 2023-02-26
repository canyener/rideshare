using MediatR;

namespace Application.Features.TravelPlans.Commands.ChangeTravelPlanStatus;

public class ChangeTravelPlanStatusCommand : IRequest<bool>
{
  public int Id { get; set; }
  public bool TravelPlanStatus { get; set; }
}