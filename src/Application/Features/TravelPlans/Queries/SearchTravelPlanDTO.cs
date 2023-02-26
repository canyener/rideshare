namespace Application.Features.TravelPlans.Queries;

public class SearchTravelPlanDTO
{
  public int Id { get; set; }

  public string DepartureCity { get; set; }
  public string DestinationCity { get; set; }
  public int AvailableSeatCount { get; set; }

  public bool IsActive { get; set; }

  public string Description { get; set; }

  public DateTime DepartureDate { get; set; }
}