namespace Masa.EShop.Service.Catalog.Infrastructure.Middleware;

public class LoggingMiddleware<TEvent> : EventMiddleware<TEvent>
    where TEvent : IEvent
{
    private readonly ILogger<LoggingMiddleware<TEvent>> _logger;
    public LoggingMiddleware(ILogger<LoggingMiddleware<TEvent>> logger) => _logger = logger;

    public override async Task HandleAsync(TEvent @event, EventHandlerDelegate next)
    {
        _logger.LogInformation("----- Handling command {CommandName} ({@Command})", @event.GetType().GetGenericTypeName(), @event);
        await next();
    }
}
