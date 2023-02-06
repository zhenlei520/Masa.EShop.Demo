using Masa.EShop.Contracts.Catalog.Request;

namespace Masa.EShop.Service.Catalog.Application.Catalogs.Queries;

public record CatalogItemsQuery : ItemsQueryBase<PaginatedListBase<CatalogListItemDto>>
{
    public string? Name { get; set; }
    
    /// <summary>
    /// 存储查询结果
    /// </summary>
    public override PaginatedListBase<CatalogListItemDto> Result { get; set; } = default!;
}
