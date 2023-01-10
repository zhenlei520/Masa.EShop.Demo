using Masa.BuildingBlocks.Ddd.Domain.SeedWork;
using Masa.EShop.Service.Catalog.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Masa.EShop.Service.Catalog.Infrastructure;

public static class CatalogDbContextSeed
{
#pragma warning disable S2178
    
    /// <summary>
    /// 迁移种子数据
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
            new("Lonsid")
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
