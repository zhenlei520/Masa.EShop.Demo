namespace Masa.EShop.Service.Catalog.Application.Catalogs.Queries;

public class CatalogItemsQueryValidator : AbstractValidator<CatalogItemsQuery>
{
    public CatalogItemsQueryValidator()
    {
        RuleFor(command => command.Page).GreaterThan(1).WithMessage("页码错误");
        RuleFor(command => command.PageSize).GreaterThan(0).WithMessage("页大小错误");
    }
}
