namespace Masa.EShop.Service.Catalog.Services;

public class HealthService : ServiceBase
{
    public IResult Get() => Results.Ok("success");

    public IResult GetFailed() => throw new UserFriendlyException(errorCode: "CustomFailed");
}
