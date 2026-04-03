using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Abstractions;

namespace Ordering.API.Interceptor
{
    public class AuditEntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntites(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await UpdateEntites(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task UpdateEntites(DbContext? ctx)
        {
            foreach(var data in ctx.ChangeTracker.Entries<IEntity>())
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedAt = DateTime.UtcNow;
                    data.Entity.CreatedBy = "Tharun";
                }
                if (data.State == EntityState.Modified)
                {
                    data.Entity.LastModifiedBy = "Tharun";
                    data.Entity.LastModified = DateTime.UtcNow;
                }

            }
        }
    }
}
