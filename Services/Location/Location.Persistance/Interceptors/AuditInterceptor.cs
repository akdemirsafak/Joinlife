using Location.Domain.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Location.Persistance.Interceptors;

public sealed class AuditInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var entries = eventData.Context.ChangeTracker.Entries()
            .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((IAuditableEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                ((IAuditableEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Deleted)
            {
                ((IAuditableEntity)entry.Entity).DeletedAt = DateTime.UtcNow;
                entry.State = EntityState.Modified;
            }
        }

        return base.SavingChanges(eventData, result);
    }
}
