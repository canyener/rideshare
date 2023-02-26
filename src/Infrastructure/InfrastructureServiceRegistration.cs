using Application.Contracts.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

/// <summary>
/// This class is responsible for Infrastructure Layer Dependency Injection.
/// </summary>
public static class InsfrastructureServiceRegistration
{
  /// <summary>
  /// Method that injects all dependencies of Infrastructure Layer.
  /// </summary>
  /// <param name="services">Represents IServiceCollection comes from Microsoft.Extensions.DependencyInjection namespace.</param>
  /// <param name="configuration">Represents IConfiguration comes from Microsoft.Extensions.Configuration namespace.</param>
  /// <returns>Returns a collection of services composed by Infrastructure Layer.</returns>
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<RideShareContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("RideShareConnectionString"))
    );

    // Use typeof here because we need to pass assembly info to AspNet DI tool so it can manage all types under IAsyncRepository<T>. (E.x.: Mediator needs that.)
    services.AddScoped(typeof(IAsyncRepository<>), typeof(EfCoreRepositoryBase<>));

    services.AddScoped<ITravelPlanRepository, TravelPlanRepository>();

    return services;
  }
}