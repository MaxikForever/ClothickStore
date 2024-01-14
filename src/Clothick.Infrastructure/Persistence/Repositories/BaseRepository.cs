using System.Linq.Expressions;
using Clothick.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public BaseRepository(ApplicationDbContext applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    private ApplicationDbContext ApplicationDbContext { get; }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return ApplicationDbContext.Set<T>().Where(expression).AsNoTracking();
    }

    public IQueryable<T> GetAll()
    {
        return ApplicationDbContext.Set<T>().AsNoTracking();
    }

    public async Task CreateAsync(T entity)
    {
        await ApplicationDbContext.Set<T>().AddAsync(entity);
    }

    public void UpdateAsync(T entity)
    {
        ApplicationDbContext.Set<T>().Update(entity);
    }

    public void DeleteAsync(T entity)
    {
        ApplicationDbContext.Set<T>().Remove(entity);
    }

    public Task SaveAsync()
    {
        return ApplicationDbContext.SaveChangesAsync();
    }
}