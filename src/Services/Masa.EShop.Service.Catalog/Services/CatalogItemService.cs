namespace Masa.EShop.Service.Catalog.Services;

public class CatalogItemService : ServiceBase
{
    public Task AddAsync(IEventBus eventBus, CatalogItemCommand command, CancellationToken cancellationToken)
    {
        return eventBus.PublishAsync(command, cancellationToken);
    }

    public async Task<PaginatedListBase<CatalogListItemDto>> GetListAsync(IEventBus eventBus,
        CancellationToken cancellationToken,
        string? name = null,
        int page = 1,
        int pageSize = 20)
    {
        var query = new CatalogItemsQuery()
        {
            Name = name,
            Page = page,
            PageSize = pageSize
        };
        await eventBus.PublishAsync(query, cancellationToken);
        return query.Result;
    }
}
