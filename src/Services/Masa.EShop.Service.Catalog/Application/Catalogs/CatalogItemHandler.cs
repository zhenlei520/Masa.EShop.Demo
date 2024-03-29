﻿namespace Masa.EShop.Service.Catalog.Application.Catalogs;

public class CatalogItemHandler
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CatalogItemHandler(ICatalogItemRepository catalogItemRepository)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    /// <summary>
    /// 创建商品处理程序
    /// </summary>
    [EventHandler]
    public async Task AddAsync(
        CatalogItemCommand command,
        CancellationToken cancellationToken)
    {
        var catalogItem = new CatalogItem(command.Name, command.Description, command.Price, command.PictureFileName);
        catalogItem.SetCatalogBrand(command.CatalogBrandId);
        catalogItem.SetCatalogType(command.CatalogTypeId);
        await _catalogItemRepository.AddAsync(catalogItem, cancellationToken);
    }

    /// <summary>
    /// 查询处理程序
    /// </summary>
    [EventHandler]
    public async Task GetListAsync(CatalogItemsQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<CatalogItem, bool>> condition = catalogItem => true;
        condition = condition.And(!query.Name.IsNullOrWhiteSpace(), catalogItem => catalogItem.Name.Contains(query.Name!));

        var catalogItems = await _catalogItemRepository.GetPaginatedListAsync(condition, new PaginatedOptions(query.Page, query.PageSize), cancellationToken);

        query.Result = new PaginatedListBase<CatalogListItemDto>()
        {
            Total = catalogItems.Total,
            TotalPages = catalogItems.TotalPages,
            Result = catalogItems.Result.Map<List<CatalogListItemDto>>()
        };
    }
}
