namespace Masa.EShop.Service.Catalog.Domain.Aggregates;

public class CatalogType : Enumeration
{
    public static CatalogType Cap = new Cap(1, "Cap");
    public static CatalogType Mug = new(2, "Mug");
    public static CatalogType Pin = new(3, "Pin");
    public static CatalogType Sticker = new(4, "Sticker");
    public static CatalogType TShirt = new(5, "T-Shirt");

    public CatalogType(int id, string name) : base(id, name)
    {
    }

    public virtual decimal TotalPrice(decimal price, int num)
    {
        return price * num;
    }
}

public class Cap : CatalogType
{
    public Cap(int id, string name) : base(id, name)
    {
    }

    public override decimal TotalPrice(decimal price, int num)
    {
        return price * num * 0.95m;
    }
}
