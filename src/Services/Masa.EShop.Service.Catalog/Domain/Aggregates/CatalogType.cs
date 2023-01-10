﻿using Masa.BuildingBlocks.Ddd.Domain.SeedWork;

namespace Masa.EShop.Service.Catalog.Domain.Aggregates;

public class CatalogType : Enumeration
{
    public static CatalogType Cap = new(1, "Cap");
    public static CatalogType Mug = new(2, "Mug");
    public static CatalogType Pin = new(3, "Pin");
    public static CatalogType Sticker = new(4, "Sticker");
    public static CatalogType TShirt = new(5, "T-Shirt");

    public CatalogType(int id, string name) : base(id, name)
    {
    }
}