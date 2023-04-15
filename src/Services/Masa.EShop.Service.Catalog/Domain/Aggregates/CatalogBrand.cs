namespace Masa.EShop.Service.Catalog.Domain.Aggregates;

public class CatalogBrand : FullAggregateRoot<Guid, int>
{
    public string Brand { get; private set; } = null!;

    private CatalogBrand(Guid? id = null)
    {
        Id = id ?? IdGeneratorFactory.SequentialGuidGenerator.NewId();
    }

    public CatalogBrand(Guid? id, string brand) : this(id)
    {
        Brand = brand;
    }

    public CatalogBrand(string brand) : this(null, brand)
    {
    }
}
