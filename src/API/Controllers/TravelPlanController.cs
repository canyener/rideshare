using Application.Features.TravelPlans.Commands.AttendToTravelPlan;
using Application.Features.TravelPlans.Commands.ChangeTravelPlanStatus;
using Application.Features.TravelPlans.Commands.CreateTravelPlan;
using Application.Features.TravelPlans.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/travelplans")]
public class TravelPlanController : ControllerBase
{
  #region "Fields"

  private readonly IMediator _mediator;

  #endregion

  #region "Constructors"

  public TravelPlanController(IMediator mediator)
  {
    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
  }

  #endregion

  #region "Actions"

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreateTravelPlan(CreateTravelPlanCommand command)
  {
    var result = await _mediator.Send(command);

    return Ok(result);
  }

  [HttpGet("/search")]
  [ProducesResponseType(typeof(List<SearchTravelPlanDTO>), StatusCodes.Status200OK)]
  public async Task<ActionResult<List<SearchTravelPlanDTO>>> Search(string departureCity, string destinationCity)
  {
    // Create query.
    var searchTravelPlanQuery = new SearchTravelPlanQuery
    {
      DepartureCity = departureCity,
      DestinationCity = destinationCity
    };

    var travelPlanList = await _mediator.Send(searchTravelPlanQuery);

    return Ok(travelPlanList);
  }

  [HttpPut("{id}/attend")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> AttendTo(int id)
  {
    // Create command.
    var command = new AttendToTravelPlanCommand { TravelPlanId = id };

    var result = await _mediator.Send(command);

    return new JsonResult(new
    {
      TravelPlanId = result.TravelPlanId,
      Message = result.Message
    })
    { StatusCode = result.StatusCode };
  }

  [HttpPut("{id}/change/{status}")]
  public async Task<ActionResult<bool>> ChangeStatus(int id, bool status)
  {
    var command = new ChangeTravelPlanStatusCommand { Id = id, TravelPlanStatus = status };

    var result = await _mediator.Send(command);

    return Ok(result);
  }

  #endregion
}