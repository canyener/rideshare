using System.Reflection;
using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// This class is responsible for Application Layer Dependency Injection.
/// </summary>
public static class ApplicationServiceRegistration
{
  /// <summary>
  /// Method that injects all dependencies of Application Layer.
  /// </summary>
  /// <param name="services">Represents IServiceCollection comes from Microsoft.Extensions.DependencyInjection namespace</param>
  /// <returns>Returns a collection of services composed by Application Layer.</returns>
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());

    /* 
     * Application may NOT be dependent on FluentValidation library. 
     * Since it's a cross cutting concern, I added this way, otherwise we could have build a seperate validation layer.
     */
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    // Add pipeline behaviours.
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

    return services;
  }
}