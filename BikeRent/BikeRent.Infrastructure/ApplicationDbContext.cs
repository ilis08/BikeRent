using BikeRent.Application.Exceptions;
using BikeRent.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
            : base(options)
        {
            this.publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                await PublishDomainEventsAsync();

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency exception occured.", ex);
            }
        }

        private async Task PublishDomainEventsAsync()
        {
            var entities = ChangeTracker
                .Entries<Entity>()
                .Select(entry => entry.Entity)

                .ToList();

            var domainEvents = entities.SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                return domainEvents;
            }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await publisher.Publish(domainEvent);
            }

            foreach (var entity in entities)
            {
                entity.ClearDomainEvents();
            }
        }
    }
}
