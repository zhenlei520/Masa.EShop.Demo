namespace Masa.EShop.Service.Catalog.Infrastructure.Extensions;

public static class HostExtensions
{
    public static async Task MigrateDbContextAsync<TContext>(this IHost host, Func<TContext, IServiceProvider, Task> seeder) where TContext : DbContext
    {
        await using var scope = host.Services.CreateAsyncScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<TContext>();
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
            await context.Database.MigrateAsync();
        
        await seeder(context, services);
    }
}
