using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.TravelPlans.Commands.ChangeTravelPlanStatus;

public class ChangeTravelPlanStatusCommandHandler : IRequestHandler<ChangeTravelPlanStatusCommand, bool>
{
  #region "Fields"

  private readonly ITravelPlanRepository _travelPlanRepository;

  #endregion

  #region "Constructors"

  public ChangeTravelPlanStatusCommandHandler(ITravelPlanRepository travelPlanRepository)
  {
    _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
  }

  #endregion

  #region "Handlers"

  public async Task<bool> Handle(ChangeTravelPlanStatusCommand request, CancellationToken cancellationToken)
  {
    return await _travelPlanRepository.ChangeTravelPlanStatus(request.Id, request.TravelPlanStatus);
  }

  #endregion
}