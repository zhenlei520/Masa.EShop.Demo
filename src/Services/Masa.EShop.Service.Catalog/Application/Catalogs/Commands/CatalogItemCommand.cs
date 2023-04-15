using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Commands;

namespace Masa.EShop.Service.Catalog.Application.Catalogs.Commands;

public record CatalogItemCommand : Command
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = string.Empty;

    /// <summary>
    /// Seed data: 6d99e4d5-dc38-42e2-9a7d-4da6e9008031
    /// </summary>
    public Guid CatalogBrandId { get; set; }

    /// <summary>
    /// Seed data: 1
    /// </summary>
    public int CatalogTypeId { get; set; }
}
