namespace Masa.EShop.Service.Catalog.Infrastructure;

public static class CatalogDbContextSeed
{
#pragma warning disable S2178

    /// <summary>
    /// Migrate seed data
    /// </summary>
    /// <param name="catalogDbContext"></param>
    /// <param name="serviceProvider"></param>
    public static async Task SeedAsync(CatalogDbContext catalogDbContext, IServiceProvider serviceProvider)
    {
        var dataUpdate =
            await catalogDbContext.EnumerationSeed() |
            await catalogDbContext.CatalogBrandSeedAsync();

        if (dataUpdate)
            await catalogDbContext.SaveChangesAsync();
    }
#pragma warning disable S2178

    private static async Task<bool> CatalogBrandSeedAsync(this CatalogDbContext dbContext)
    {
        if (await dbContext.IsExistAsync<CatalogBrand>())
            return false;

        var catalogBrands = new List<CatalogBrand>()
        {
            new(Guid.Parse("6d99e4d5-dc38-42e2-9a7d-4da6e9008031"), "Lonsid")
        };
        await dbContext.Set<CatalogBrand>().AddRangeAsync(catalogBrands);
        return true;
    }

    private static Task<bool> IsExistAsync<TEntity>(this CatalogDbContext dbContext) where TEntity : class
        => dbContext.Set<TEntity>().AnyAsync();

    private static Task<bool> EnumerationSeed(this CatalogDbContext dbContext)
        => dbContext.EnumerationSeedCoreAsync<CatalogType>();

    private static async Task<bool> EnumerationSeedCoreAsync<T>(this CatalogDbContext dbContext) where T : Enumeration
    {
        if (await dbContext.Set<T>().AnyAsync())
            return false;

        var list = Enumeration.GetAll<T>();
        dbContext.Set<T>().AddRange(list);
        return true;
    }
}
