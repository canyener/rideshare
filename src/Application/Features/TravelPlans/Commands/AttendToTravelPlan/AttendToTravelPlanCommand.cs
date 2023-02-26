using MediatR;

namespace Application.Features.TravelPlans.Commands.AttendToTravelPlan;

public class AttendToTravelPlanCommand : IRequest<AttendToTravelPlanResponseDTO>
{
  public int TravelPlanId { get; set; }
}