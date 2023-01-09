using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace Masa.EShop.Service.Catalog.Domain.Aggregates;

public class CatalogBrand: FullAggregateRoot<int, int>
{
    public string Brand { get; set; } = null!;
}
