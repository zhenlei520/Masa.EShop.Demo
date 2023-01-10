using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;
using Masa.EShop.Service.Catalog.Domain.Events;

namespace Masa.EShop.Service.Catalog.Domain.Aggregates;

public class CatalogItem : FullAggregateRoot<Guid, int>
{
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public string PictureFileName { get; private set; } = "";

    private int _catalogTypeId;

    public CatalogType CatalogType { get; private set; } = null!;

    private Guid _catalogBrandId;

    public CatalogBrand CatalogBrand { get; private set; } = null!;

    public int AvailableStock { get; private set; }

    public int RestockThreshold { get; private set; }

    public int MaxStockThreshold { get; private set; }

    public bool OnReorder { get; private set; }

    public CatalogItem(Guid id, Guid catalogBrandId, int catalogTypeId, string name, string description, decimal price, string pictureFileName) : base(id)
    {
        _catalogBrandId = catalogBrandId;
        _catalogTypeId = catalogTypeId;
        Name = name;
        Description = description;
        Price = price;
        PictureFileName = pictureFileName;
        AddCatalogItemDomainEvent();
    }

    private void AddCatalogItemDomainEvent()
    {
        var domainEvent = this.Map<CatalogItemCreatedDomainEvent>();
        domainEvent.CatalogBrandId = _catalogBrandId;
        domainEvent.CatalogTypeId = _catalogTypeId;
        AddDomainEvent(domainEvent);
    }
}
