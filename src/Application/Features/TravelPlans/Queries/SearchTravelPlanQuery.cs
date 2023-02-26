using MediatR;

namespace Application.Features.TravelPlans.Queries;

public class SearchTravelPlanQuery : IRequest<List<SearchTravelPlanDTO>>
{
  public string DepartureCity { get; set; }
  public string DestinationCity { get; set; }
}