using System.Linq.Expressions;

namespace Clothick.Contracts.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

    IQueryable<T> GetAll();

    Task CreateAsync(T entity);

    void UpdateAsync(T entity);

    void DeleteAsync(T entity);

    Task SaveAsync();
}