using System.Text.Json.Serialization;
using LocalizationDemo.Database.Repositories;
using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Abstractions;
using LocalizationDemo.Domain.Collections;
using LocalizationDemo.Domain.Ports;
using LocalizationDemo.Domain.Services;
using LocalizationDemo.Web;
using LocalizationDemo.Web.Helpers;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<JsonOptions>(options => { options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
    .AddScoped<ContentCultureAccessor>()
    .AddSqlite<LocalizationDemoContext>(builder.Configuration.GetConnectionString("DefaultConnection"))
    .AddScoped<IUnitOfWork, LocalizationDemoContext>()

    // API V1
    .AddScoped<IProductsRepository, ProductsRepository>()
    .AddScoped<ProductsCollection>()
    .AddScoped<IShoppingCartsRepository, ShoppingCartsRepository>()
    .AddScoped<ShoppingCartsCollection>()
    // API V2
    .AddScoped<IProductsRepositoryV2, ProductsRepositoryV2>()
    .AddScoped<ProductsCollectionV2>()
    .AddScoped<IShoppingCartsRepositoryV2, ShoppingCartsRepositoryV2>()
    .AddScoped<ShoppingCartsCollectionV2>();

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseMiddleware<CurrentContentCultureSetterMiddleware>();

app
    .MapApiV1Endpoints()
    .MapApiV2Endpoints();

app.Run();