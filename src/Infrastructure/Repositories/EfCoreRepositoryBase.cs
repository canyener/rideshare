using System.Linq.Expressions;
using Application.Contracts.Persistence;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// This class is a wrapper class for EF Core implementation of IAsyncRepository.
/// </summary>
/// <typeparam name="T">Any object derived from EntityBase.</typeparam>
public class EfCoreRepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
{
  #region "Fields"

  protected readonly RideShareContext _dbContext;

  #endregion

  #region "Constructors"

  public EfCoreRepositoryBase(RideShareContext dbContext)
  {
    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  #endregion

  #region "Methods"

  public async Task<T> AddAsync(T entity)
  {
    _dbContext.Set<T>().Add(entity);

    await _dbContext.SaveChangesAsync();

    return entity;
  }

  public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
  {
    return await _dbContext.Set<T>().Where(predicate).ToListAsync();
  }

  #endregion
}