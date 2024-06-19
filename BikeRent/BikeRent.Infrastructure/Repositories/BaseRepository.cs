using BikeRent.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BikeRent.Infrastructure.Repositories
{
    internal abstract class BaseRepository<T> : IAsyncRepository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext dbContext;

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<T>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(Guid.Parse(id)), cancellationToken);
        }

        public async Task<T?> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await dbContext.AddAsync(entity, cancellationToken);

            return entity;
        }

    }
}
