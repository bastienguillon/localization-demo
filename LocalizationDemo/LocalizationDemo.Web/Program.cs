using System.Text.Json.Serialization;
using LocalizationDemo.Database.Repositories;
using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Collections;
using LocalizationDemo.Domain.Ports;
using LocalizationDemo.Domain.Services;
using LocalizationDemo.Web.Helpers;
using LocalizationDemo.Web.Models;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<JsonOptions>(options => { options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
    .AddScoped<ContentCultureAccessor>()
    .AddSqlite<LocalizationDemoContext>(builder.Configuration.GetConnectionString("DefaultConnection"))
    .AddScoped<IProductsRepository, ProductsRepository>()
    .AddScoped<ProductsCollection>();

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseMiddleware<CurrentContentCultureSetterMiddleware>();

// Get all products
app.MapGet("/api/products", async (
        ProductsCollection collection
    ) =>
    {
        var products = await collection.GetAllAsync();
        return products
            .Select(product => new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.UsdPrice,
                product.Category
            ));
    })
    .WithName("GetAllProducts")
    .WithOpenApi();

// Get single product
app.MapGet("/api/products/{id}", async (
        int id,
        ProductsCollection collection
    ) =>
    {
        var product = await collection.GetByIdAsync(id);
        return product is null
            ? Results.NotFound()
            : Results.Ok(new ProductDto(
                    product.Id,
                    product.Name,
                    product.Description,
                    product.UsdPrice,
                    product.Category
                )
            );
    })
    .WithName("GetSingleProduct")
    .WithOpenApi();

app.Run();