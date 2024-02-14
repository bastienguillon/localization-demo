using System.Text.Json.Serialization;
using LocalizationDemo.Database.Repositories;
using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Abstractions;
using LocalizationDemo.Domain.Collections;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;
using LocalizationDemo.Domain.Services;
using LocalizationDemo.Web.Helpers;
using LocalizationDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<JsonOptions>(options => { options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
    .AddScoped<ContentCultureAccessor>()
    .AddSqlite<LocalizationDemoContext>(builder.Configuration.GetConnectionString("DefaultConnection"))

    //
    // V1
    // 

    // Products
    .AddScoped<IProductsRepository, ProductsRepository>()
    .AddScoped<ProductsCollection>()
    // Shopping carts
    .AddScoped<IShoppingCartsRepository, ShoppingCartsRepository>()
    .AddScoped<ShoppingCartsCollection>()

    //
    // V2
    //

    // Products
    .AddScoped<IProductsRepositoryV2, ProductsRepositoryV2>()
    .AddScoped<ProductsCollectionV2>();

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseMiddleware<CurrentContentCultureSetterMiddleware>();

// Get all products
app.MapGet("/api/products", async (
        [FromQuery] string? search,
        ProductsCollection collection
    ) =>
    {
        var products = await collection.GetAllAsync(search);
        return products
            .Select(product => new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.UsdPrice,
                product.Category
            ));
    })
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
    .WithOpenApi();

// Update single product
app.MapPut("/api/products/{id}", async (
    int id,
    [FromBody] ProductUpdateCandidate candidate,
    ProductsCollection collection
) =>
{
    var updatedProduct = await collection.UpdateByIdAsync(id, candidate);
    return updatedProduct is null
        ? Results.NotFound()
        : Results.Ok(new ProductDto(
                updatedProduct.Id,
                updatedProduct.Name,
                updatedProduct.Description,
                updatedProduct.UsdPrice,
                updatedProduct.Category
            )
        );
});

// Get single shopping cart
app.MapGet("/api/shopping-carts/{id}", async (
        Guid id,
        ShoppingCartsCollection collection
    ) =>
    {
        var shoppingCart = await collection.GetByIdAsync(id);
        return shoppingCart is null
            ? Results.NotFound()
            : Results.Ok(
                new ShoppingCartDto(
                    shoppingCart.Id,
                    shoppingCart.Products.Select(scp => new ProductDto(
                        scp.Product.Id,
                        scp.Product.Name,
                        scp.Product.Description,
                        scp.Product.UsdPrice,
                        scp.Product.Category
                    ))
                )
            );
    })
    .WithOpenApi();

// Get all products v2
app.MapGet("/api/v2/products", async (
        [FromQuery] string? search,
        ProductsCollectionV2 collection,
        ContentCultureAccessor contentCultureAccessor
    ) =>
    {
        var products = await collection.GetAllAsync(search);
        return products
            .Select(product => new ProductDto(
                product.Id,
                product
                    .Translations
                    .GetBestTranslation(contentCultureAccessor.ContentCulture)
                    .Name,
                product
                    .Translations
                    .GetBestTranslation(contentCultureAccessor.ContentCulture)
                    .Description,
                product.UsdPrice,
                product.Category
            ));
    })
    .WithOpenApi();


app.Run();