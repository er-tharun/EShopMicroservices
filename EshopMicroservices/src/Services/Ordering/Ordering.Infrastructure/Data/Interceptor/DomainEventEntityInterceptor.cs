using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Abstractions;

namespace Ordering.API.Interceptor
{
    public class DomainEventEntityInterceptor
        (IMediator mediator): SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        public async Task TriggerDomainEventsAsync(DbContext? context)
        {
            if (context == null) return;
            var aggregates = context.ChangeTracker
                                .Entries<IAggregate>()
                                .Where(a => a.Entity.DomainEvents.Any())
                                .Select(a => a.Entity);
            var domanEvents = aggregates
                                .SelectMany(o => o.DomainEvents)
                                .ToList();

            aggregates.ToList().ForEach(a => a.ClearDomainEvents());

            foreach (var domainEvent in domanEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
