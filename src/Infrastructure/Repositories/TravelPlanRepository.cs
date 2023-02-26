using Application.Contracts.Persistence;
using Application.Features.TravelPlans.Commands.AttendToTravelPlan;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class TravelPlanRepository : EfCoreRepositoryBase<TravelPlan>, ITravelPlanRepository
{
  #region "Constructors"

  public TravelPlanRepository(RideShareContext dbContext) : base(dbContext)
  {
  }

  #endregion

  #region "Methods"

  public async Task<AttendToTravelPlanResponseDTO> AttendToTravelPlan(int travelPlanId)
  {
    // Fetch travel plan.
    var travelPlanToAttend = await _dbContext.TravelPlans.FindAsync(travelPlanId);

    // Arrange base response object.
    var response = new AttendToTravelPlanResponseDTO { TravelPlanId = travelPlanId };

    // Check for available seats.
    if (travelPlanToAttend.IsActive && travelPlanToAttend.AvailableSeatCount > 0 && travelPlanToAttend.DepartureDate > DateTime.Now)
    {
      travelPlanToAttend.AvailableSeatCount--;

      await _dbContext.SaveChangesAsync();

      response.StatusCode = 200;
      response.Message = "Successfully attended to travel plan!";
    }
    else
    {
      response.StatusCode = 404;
      response.Message = "No available travel plans!";
    }

    return response;
  }

  public async Task<bool> ChangeTravelPlanStatus(int travelPlanId, bool newTravelPlanStatus)
  {
    var travelPlan = await _dbContext.TravelPlans.FindAsync(travelPlanId);

    travelPlan.IsActive = newTravelPlanStatus;

    return await _dbContext.SaveChangesAsync() > 0;
  }
  
  #endregion
}