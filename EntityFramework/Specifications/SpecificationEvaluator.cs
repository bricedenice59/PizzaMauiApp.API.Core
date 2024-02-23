using Microsoft.EntityFrameworkCore;

namespace PizzaMauiApp.API.Shared.EntityFramework.Specifications;

public class SpecificationEvaluator<TEntity> where TEntity: BaseModel
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
    {
        var finalQuery = inputQuery;
        if (specification.WhereCriteria != null)
        {
            finalQuery = finalQuery.Where(specification.WhereCriteria);
        }
        
        if (specification.OrderBy != null)
        {
            finalQuery = finalQuery.OrderBy(specification.OrderBy);
        }
        
        if (specification.OrderByDescending != null)
        {
            finalQuery = finalQuery.OrderByDescending(specification.OrderByDescending);
        }
        
        if (specification.IsPaginationEnabled)
        {
            finalQuery = finalQuery.Skip(specification.Skip).Take(specification.Take);
        }

        if (specification.Includes.Any())
        {
            finalQuery = specification.Includes.Aggregate(finalQuery, (current, include) => current.Include(include));
        }

        if(!specification.HasEntityTracking)
            finalQuery = finalQuery.AsNoTracking();

        return finalQuery;
    }
}