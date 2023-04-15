var builder = WebApplication.CreateBuilder(args);

#region Register Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDaprStarter(); //If you don't have dapr locally and don't use integration events for the time being, you can temporarily comment
}

builder.Services
    .AddMapster()
    .AddSequentialGuidGenerator()
    .Configure<AuditEntityOptions>(options => options.UserIdType = typeof(int))//When this parameter is not set, the default user id is Guid type
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

app.UseMasaExceptionHandler(options =>
{
    options.ExceptionHandler = contextException =>
    {
        //Custom exception handling
    };
});

#region Use Swaager

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#endregion

await app.MigrateDbContextAsync<CatalogDbContext>(async (context, serviceProvider) =>
{
    await CatalogDbContextSeed.SeedAsync(context, serviceProvider);
});

app.MapGet("/", () => "Hello World!");

app.Run();
