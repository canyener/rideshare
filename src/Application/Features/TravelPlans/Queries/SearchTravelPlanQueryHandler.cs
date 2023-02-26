using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.TravelPlans.Queries;

public class SearchTravelPlanQueryHandler : IRequestHandler<SearchTravelPlanQuery, List<SearchTravelPlanDTO>>
{
  #region "Fields"

  private readonly ITravelPlanRepository _travelPlanRepository;
  private readonly IMapper _mapper;

  #endregion

  #region "Constructors"

  public SearchTravelPlanQueryHandler(ITravelPlanRepository travelPlanRepository, IMapper mapper)
  {
    _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  #endregion

  #region  "Handlers"

  public async Task<List<SearchTravelPlanDTO>> Handle(SearchTravelPlanQuery request, CancellationToken cancellationToken)
  {
    var travelPlans = await _travelPlanRepository
      .GetAsync(p => p.DepartureCity == request.DepartureCity
                && p.DestinationCity == request.DestinationCity
                && p.DepartureDate > DateTime.Now
                && p.IsActive == true);

    return _mapper.Map<List<SearchTravelPlanDTO>>(travelPlans);
  }

  #endregion
}