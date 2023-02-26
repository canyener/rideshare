using System.Linq.Expressions;
using Domain.Common;

namespace Application.Contracts.Persistence;

/// <summary>
/// This repository interface is a wrapper for the relational database operations.
/// This interface gives us flexibility to change ORM tool and test db related operations easier.
/// </summary>
/// <typeparam name="T">Represents object derived from <type>EntityBase</type></typeparam>
public interface IAsyncRepository<T> where T : EntityBase
{
  /// <summary>
  /// Generic method that fetches data by given condition.
  /// </summary>
  /// <param name="predicate">Represents condition expression.</param>
  /// <returns>Returns <type>IReadOnlyList</type> of <type>T</type>.</returns>
  Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

  /// <summary>
  /// Inserts new <type>T</type> to database.
  /// </summary>
  /// <param name="entity">Represents entity to be created.</param>
  /// <returns>Returns created entity as <type>T</type>.</returns>
  Task<T> AddAsync(T entity);
}