using System.Linq.Expressions;

namespace BikeRent.Domain.Abstractions
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<List<T>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<T?> AddAsync(T entity, CancellationToken cancellationToken = default);
    }
}
