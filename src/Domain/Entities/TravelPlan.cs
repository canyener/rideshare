using Domain.Common;

namespace Domain.Entities;

public class TravelPlan : EntityBase
{
  public int AvailableSeatCount { get; set; }

  public string Email { get; set; }

  public string DepartureCity { get; set; }
  public string DestinationCity { get; set; }

  public string Description { get; set; }

  public bool IsActive { get; set; }

  public DateTime DepartureDate { get; set; }
}