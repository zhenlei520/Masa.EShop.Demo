using Microsoft.EntityFrameworkCore;

namespace Masa.EShop.Service.Catalog.Infrastructure;

public class CatalogDbContext : MasaDbContext<CatalogDbContext>
{
    public CatalogDbContext(MasaDbContextOptions<CatalogDbContext> options) : base(options)
    {

    }
    
    protected override void OnModelCreatingExecuting(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        base.OnModelCreatingExecuting(builder);
    }
}
