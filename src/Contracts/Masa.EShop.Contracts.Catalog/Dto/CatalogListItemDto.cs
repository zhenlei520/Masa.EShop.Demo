﻿namespace Masa.EShop.Contracts.Catalog.Dto;

public class CatalogListItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = "";

    public int CatalogTypeId { get; set; }
    
    public string CatalogTypeName { get; set; }

    public Guid CatalogBrandId { get; set; }
    
    public string CatalogBrandName { get; set; }

    public int AvailableStock { get; set; }
}
