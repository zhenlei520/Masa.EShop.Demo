using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using Masa.EShop.Service.Catalog.Domain.Aggregates;

namespace Masa.EShop.Service.Catalog.Domain.Repositories;

public interface ICatalogItemRepository : IRepository<CatalogItem, int>
{
    
}
