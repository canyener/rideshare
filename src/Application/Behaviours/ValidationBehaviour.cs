using FluentValidation;
using MediatR;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
{
  #region "Fields"

  private readonly IEnumerable<IValidator<TRequest>> _validators;

  #endregion

  #region "Constructors"

  public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
  {
    _validators = validators ?? throw new ArgumentNullException(nameof(validators));
  }

  #endregion

  #region "Handlers"

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    // Check validators.
    if (_validators.Any())
    {
      // Create validation context.
      var validationContext = new ValidationContext<TRequest>(request);

      // Run all validation tasks in validation context.
      var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

      // Get all validation failures.
      var validationFailures = validationResults
        .SelectMany(p => p.Errors)
        .Where(p => p != null)
        .ToList();

      // Check if any validation failures.
      if (validationFailures.Count > 0)
      {
        throw new ValidationException(validationFailures);
      }
    }

    return await next();
  }

  #endregion
}