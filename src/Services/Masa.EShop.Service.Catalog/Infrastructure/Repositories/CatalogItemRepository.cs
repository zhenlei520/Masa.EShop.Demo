using System.Linq.Expressions;
using Masa.BuildingBlocks.Caching;
using Masa.BuildingBlocks.Data.UoW;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using Masa.Contrib.Ddd.Domain.Repository.EFCore;
using Masa.EShop.Service.Catalog.Domain.Aggregates;
using Masa.EShop.Service.Catalog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Masa.EShop.Service.Catalog.Infrastructure.Repositories;

public class CatalogItemRepository : Repository<CatalogDbContext, CatalogItem, Guid>, ICatalogItemRepository
{
    /// <summary>
    /// 使用多级缓存
    /// </summary>
    private readonly IMultilevelCacheClient _multilevelCacheClient;

    public CatalogItemRepository(CatalogDbContext context, IUnitOfWork unitOfWork, IMultilevelCacheClient multilevelCacheClient) : base(context, unitOfWork)
    {
        _multilevelCacheClient = multilevelCacheClient;
    }

    public override async Task<CatalogItem?> FindAsync(Guid id, CancellationToken cancellationToken = default)
    {
        TimeSpan? timeSpan = null;
        var catalogInfo = await _multilevelCacheClient.GetOrSetAsync(id.ToString(), () =>
        {
            var info = Context.Set<CatalogItem>()
                .Include(catalogItem => catalogItem.CatalogType)
                .Include(catalogItem => catalogItem.CatalogBrand)
                .AsSplitQuery()
                .FirstOrDefaultAsync(catalogItem => catalogItem.Id == id, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();

            if (info != null)
                return new CacheEntry<CatalogItem>(info, TimeSpan.FromDays(3))
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                };

            timeSpan = TimeSpan.FromSeconds(5);
            return new CacheEntry<CatalogItem>(info);
        }, timeSpan == null ? null : new CacheEntryOptions(timeSpan));
        return catalogInfo;
    }

    public override Task<List<CatalogItem>> GetPaginatedListAsync(
        Expression<Func<CatalogItem, bool>> predicate,
        int skip,
        int take,
        Dictionary<string, bool>? sorting = null,
        CancellationToken cancellationToken = default)
    {
        sorting ??= new Dictionary<string, bool>();
        return Context.Set<CatalogItem>()
            .Include(catalogItem => catalogItem.CatalogType)
            .Include(catalogItem => catalogItem.CatalogBrand)
            .OrderBy(sorting).Skip(skip).Take(take).ToListAsync(cancellationToken);
    }
}
