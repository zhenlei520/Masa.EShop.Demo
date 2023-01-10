using Masa.BuildingBlocks.Ddd.Domain.Events;
using Masa.Contrib.Ddd.Domain;

namespace Masa.EShop.Service.Catalog.Domain.Services;

public class CatalogItemDomainService : DomainService
{
    public CatalogItemDomainService(IDomainEventBus eventBus) : base(eventBus)
    {
    }
}
