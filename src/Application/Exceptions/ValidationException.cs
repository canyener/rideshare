using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException : ApplicationException
{
  #region "Properties"

  public IDictionary<string, string[]> Errors { get; set; }

  #endregion
  
  #region "Constructors"

  public ValidationException()
    :base("One or more validation errors occured.")
  {
    Errors = new Dictionary<string, string[]>();
  }

  public ValidationException(IEnumerable<ValidationFailure> validationFailures)
    :this()
  {
    Errors = validationFailures
       .GroupBy(p => p.PropertyName, p => p.ErrorMessage)
       .ToDictionary(validationFailureGroup => validationFailureGroup.Key, validationFailureGroup => validationFailureGroup.ToArray());
  } 

  #endregion
}