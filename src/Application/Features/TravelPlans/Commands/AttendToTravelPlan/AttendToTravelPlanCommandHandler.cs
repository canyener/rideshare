using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.TravelPlans.Commands.AttendToTravelPlan;

public class AttendToTravelPlanCommandHandler : IRequestHandler<AttendToTravelPlanCommand, AttendToTravelPlanResponseDTO>
{
  #region "Fields"

  private readonly ITravelPlanRepository _travelPlanRepository;

  #endregion

  #region "Constructors"

  public AttendToTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository)
  {
    _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
  }

  #endregion

  #region "Handlers"
  public async Task<AttendToTravelPlanResponseDTO> Handle(AttendToTravelPlanCommand request, CancellationToken cancellationToken)
  {
    return await _travelPlanRepository.AttendToTravelPlan(request.TravelPlanId);
  }

  #endregion
}