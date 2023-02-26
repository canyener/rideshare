using Application.Features.TravelPlans.Commands.AttendToTravelPlan;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ITravelPlanRepository : IAsyncRepository<TravelPlan>
{
  /// <summary>
  /// Method that updates given travel plan's status.
  /// </summary>
  /// <param name="travelPlanId">Represents travel plan.</param>
  /// <param name="newTravelPlanStatus">Represents travel plan status to be updated.</param>
  /// <returns>Returns true if change operation is successful, false otherwise.</returns>
  Task<bool> ChangeTravelPlanStatus(int travelPlanId, bool newTravelPlanStatus);

  /// <summary>
  /// Method that adds given user to travel plan.
  /// </summary>
  /// <param name="travelPlanId">Represents travel plan.</param>
  /// <returns>Returns response as <type>AttendToTravelPlanResponseDTO</type> if attendance is successful or not.</returns>
  Task<AttendToTravelPlanResponseDTO> AttendToTravelPlan(int travelPlanId);
}