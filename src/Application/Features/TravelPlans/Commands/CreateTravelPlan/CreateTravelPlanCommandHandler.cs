using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TravelPlans.Commands.CreateTravelPlan;

public class CreateTravelPlanCommandHandler : IRequestHandler<CreateTravelPlanCommand, int>
{
  #region "Fields"

  private readonly ITravelPlanRepository _travelPlanRepository;
  private readonly IMapper _mapper;

  #endregion

  #region "Constructors"

  public CreateTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository, IMapper mapper)
  {
    _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  #endregion

  #region "Handlers"

  public async Task<int> Handle(CreateTravelPlanCommand request, CancellationToken cancellationToken)
  {
    var travelPlanToAdd = _mapper.Map<TravelPlan>(request);

    travelPlanToAdd.IsActive = true;

    var result = await _travelPlanRepository.AddAsync(travelPlanToAdd);

    return result.Id;
  }

  #endregion
}