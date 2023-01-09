using Masa.BuildingBlocks.Caching;
using Masa.BuildingBlocks.Data.UoW;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using Masa.BuildingBlocks.Dispatcher.Events;
using Masa.BuildingBlocks.Dispatcher.IntegrationEvents;
using Masa.EShop.Service.Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
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
    //         .UseEventBus())
    .AddDomainEventBus(options =>
    {
        options.UseIntegrationEventBus(integrationEventBus =>
                integrationEventBus
                    .UseDapr()
                    .UseEventLog<CatalogDbContext>())
            .UseEventBus()
            .UseUoW<CatalogDbContext>()
            .UseRepository<CatalogDbContext>();
    });

var app = builder.AddServices();

app.MapGet("/", () => "Hello World!");

app.Run();
