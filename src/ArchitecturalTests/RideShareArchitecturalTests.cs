using FluentAssertions;
using NetArchTest.Rules;

namespace ArchitecturalTests;

public class RideShareArchitecturalTests
{
  private const string DomainNamespace = "Domain";
  private const string ApplicationNamespace = "Application";
  private const string InfrastructureNamespace = "Infrastructure";
  private const string ApiNamespace = "API";

  [Fact]
  public void Domain_Should_Not_HaveDependencyOnOtherProjects()
  {
    // Arrange
    var assembly = typeof(Domain.Common.EntityBase).Assembly;

    // Domain should not be referencing these projects.
    var otherProjects = new[]
    {
      InfrastructureNamespace,
      ApplicationNamespace,
      ApiNamespace
    };

    // Act
    var testResult = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(otherProjects)
      .GetResult();

    // Assert
    testResult.IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Application_Should_Not_HaveDependencyOnOtherProjects()
  {
    // Arrange
    var assembly = typeof(Application.Exceptions.ValidationException).Assembly;

    // Application should not be referencing ALL OF these projects.
    var otherProjects = new[]
    {
      ApiNamespace, 
      InfrastructureNamespace
    };

    // Act
    var testResult = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(otherProjects)
      .GetResult();


    // Assert
    testResult.IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void API_Should_Not_HaveDependencyOnOtherProjects()
  {
    // Arrange
    var assembly = typeof(API.Controllers.TravelPlanController).Assembly;

    // API should not be referencing ALL OF these projects.
    var otherProjects = new[]
    {
      DomainNamespace
    };

    // Act
    var testResult = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(otherProjects)
      .GetResult();


    // Assert
    testResult.IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
  {
    // Arrange
    var assembly = typeof(Infrastructure.Persistence.RideShareContext).Assembly;

    // Infrastructure should not be referencing ALL OF these projects.
    var otherProjects = new[]
    {
      DomainNamespace,
      ApiNamespace
    };

    // Act
    var testResult = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(otherProjects)
      .GetResult();


    // Assert
    testResult.IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Controllers_Should__HaveDependencyOnMediatR()
  {
    // Arrange
    var assembly = typeof(API.Controllers.TravelPlanController).Assembly;

    // Act
    var testResult = Types
      .InAssembly(assembly)
      .That()
      .HaveNameEndingWith("Controller")
      .Should()
      .HaveDependencyOn("MediatR")
      .GetResult();

    // Assert
    testResult.IsSuccessful.Should().BeTrue();
  }

}