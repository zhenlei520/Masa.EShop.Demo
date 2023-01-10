using Masa.BuildingBlocks.Ddd.Domain.Events;
using Masa.EShop.Contracts.Catalog.IntegrationEvents;

namespace Masa.EShop.Service.Catalog.Domain.Events;

public record CatalogItemCreatedDomainEvent : CatalogItemCreatedIntegrationEvent, IIntegrationDomainEvent
{
}
