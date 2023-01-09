using Microsoft.EntityFrameworkCore;

namespace Masa.EShop.Service.Catalog.Infrastructure;

public class CatalogDbContext : MasaDbContext<CatalogDbContext>
{
    public CatalogDbContext(MasaDbContextOptions<CatalogDbContext> options) : base(options)
    {

    }
}
