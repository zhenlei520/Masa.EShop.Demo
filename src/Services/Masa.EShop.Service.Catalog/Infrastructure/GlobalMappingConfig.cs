using Mapster;
using Masa.EShop.Contracts.Catalog.Dto;
using Masa.EShop.Service.Catalog.Domain.Aggregates;

namespace Masa.EShop.Service.Catalog.Infrastructure;

public static class GlobalMappingConfig
{
    public static void Mapping()
    {
        MappingCatalogItemToCatalogListItemDto();
    }

    private static void MappingCatalogItemToCatalogListItemDto()
    {
        TypeAdapterConfig<CatalogItem, CatalogListItemDto>
            .NewConfig()
            .Map(dest => dest.CatalogTypeName, catalogItem => catalogItem.CatalogType.Name)
            .Map(dest => dest.CatalogBrandName, catalogItem => catalogItem.CatalogBrand.Brand);
    }
}
