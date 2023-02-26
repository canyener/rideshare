using MediatR;

namespace Application.Features.TravelPlans.Commands.CreateTravelPlan;

public class CreateTravelPlanCommand : IRequest<int>
{
  public int AvailableSeatCount { get; set; }

  public string Email { get; set; }
  public string DepartureCity { get; set; }
  public string DestinationCity { get; set; }
  public string Description { get; set; }

  public DateTime DepartureDate { get; set; }
}