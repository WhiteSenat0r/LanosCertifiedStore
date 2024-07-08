using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Commands.Common;

public class SaveChangesCommand(ApplicationDatabaseContext context)
{
    public async Task<int> Execute(CancellationToken cancellationToken)
    {
       return await context.SaveChangesAsync(cancellationToken);
    }
}