using Domain;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure;

public class AggregateInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        foreach (var entry in eventData.Context!.ChangeTracker.Entries())
        {
            if (entry.Entity is IAggregateState state)
            {
                entry.CurrentValues.SetValues(state.Root!.GetState());
            }
        }

        return base.SavingChanges(eventData, result);
    }
}