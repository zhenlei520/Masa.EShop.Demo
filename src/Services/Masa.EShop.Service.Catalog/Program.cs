var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMapster()
    .AddSequentialGuidGenerator()
    .AddMasaDbContext<CatalogDbContext>(dbContextBuilder =>
    {
        dbContextBuilder
            .UseSqlite()
            .UseFilter();
    })
    .AddMultilevelCache(distributedCacheOptions =>
    {
        distributedCacheOptions.UseStackExchangeRedisCache();
    })
    // .AddIntegrationEventBus(integrationEventBus =>
    //     integrationEventBus
    //         .UseDapr()
    //         .UseEventLog<CatalogDbContext>()
    //         .UseEventBus(eventBusBuilder => eventBusBuilder.UseMiddleware(new[] { typeof(ValidatorMiddleware<>), typeof(LoggingMiddleware<>) })))
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
    .AddDomainEventBus(options =>
    {
        options.UseIntegrationEventBus(integrationEventBus => integrationEventBus.UseDapr().UseEventLog<CatalogDbContext>())
            .UseEventBus(eventBusBuilder => eventBusBuilder.UseMiddleware(typeof(LoggingMiddleware<>)))
            .UseUoW<CatalogDbContext>()
            .UseRepository<CatalogDbContext>();
    })
    .AddI18n();

GlobalMappingConfig.Mapping();

var app = builder.AddServices();

app.UseI18n();

app.UseMasaExceptionHandler();

await app.MigrateDbContextAsync<CatalogDbContext>(async (context, serviceProvider) =>
{
    await CatalogDbContextSeed.SeedAsync(context, serviceProvider);
});

app.MapGet("/", () => "Hello World!");

app.Run();
