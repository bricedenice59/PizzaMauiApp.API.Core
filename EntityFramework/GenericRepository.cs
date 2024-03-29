using Microsoft.EntityFrameworkCore;
using PizzaMauiApp.API.Core.EntityFramework.Specifications;

namespace PizzaMauiApp.API.Core.EntityFramework;

public class GenericRepository<T> : IGenericRepository<T>
    where T: BaseModel
{
    private readonly DbContext _dbContext;

    public GenericRepository(DbContext context)
    {
        _dbContext = context;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T?>> ListAllAsync(ISpecification<T> specification)
    {
        var query = ApplySpecification(specification);
        return await query.ToListAsync();
    }

    public async Task<T?> GetEntityWithSpecification(ISpecification<T> specification)
    {
        var query = ApplySpecification(specification);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T?>> ListAsyncWithSpecification(ISpecification<T> specification)
    {
        var query = ApplySpecification(specification);
        return await query.ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> specification)
    {
        var query = ApplySpecification(specification);
        return await query.CountAsync();
    }

    private IQueryable<T?> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
    }
}