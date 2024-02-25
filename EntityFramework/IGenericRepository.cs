using PizzaMauiApp.API.Core.EntityFramework.Specifications;

namespace PizzaMauiApp.API.Core.EntityFramework;

public interface IGenericRepository<T>
    where T : BaseModel
{
    Task<T?> GetByIdAsync(Guid id);
    
    Task<IReadOnlyList<T?>> ListAllAsync(ISpecification<T> specification);

    Task<T?> GetEntityWithSpecification(ISpecification<T> specification);

    Task<IReadOnlyList<T?>> ListAsyncWithSpecification(ISpecification<T> specification);
    
    Task<int> CountAsync(ISpecification<T> specification);
}