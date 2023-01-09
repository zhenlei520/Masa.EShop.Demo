using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace Masa.EShop.Service.Catalog.Domain.Aggregates;

public class CatalogItem : FullAggregateRoot<int, int>
{
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public string PictureFileName { get; private set; } = "";

    public int CatalogTypeId { get; private set; }

    public CatalogType CatalogType { get; private set; } = null!;

    public int CatalogBrandId { get; private set; }

    public CatalogBrand CatalogBrand { get; private set; } = null!;

    public int AvailableStock { get; private set; }

    public int RestockThreshold { get; private set; }

    public int MaxStockThreshold { get; private set; }

    public bool OnReorder { get; private set; }

    public CatalogItem(int catalogBrandId, int catalogTypeId, string name, string description, decimal price, string pictureFileName)
    {
        CatalogBrandId = catalogBrandId;
        CatalogTypeId = catalogTypeId;
        Name = name;
        Description = description;
        Price = price;
        PictureFileName = pictureFileName;
    }
    
    
}
