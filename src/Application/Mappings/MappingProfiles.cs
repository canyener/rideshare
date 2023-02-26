using Application.Features.TravelPlans.Commands.CreateTravelPlan;
using Application.Features.TravelPlans.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<TravelPlan, CreateTravelPlanCommand>().ReverseMap();
    CreateMap<SearchTravelPlanDTO, TravelPlan>().ReverseMap();
  }
}