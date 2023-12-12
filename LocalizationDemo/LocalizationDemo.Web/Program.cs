using LocalizationDemo.Database.Repositories;
using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Collections;
using LocalizationDemo.Domain.Ports;
using LocalizationDemo.Domain.Services;
using LocalizationDemo.Web.Helpers;
using LocalizationDemo.Web.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
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
app.MapGet("/api/products", async (ProductsCollection collection) =>
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
    .WithName("GetProducts")
    .WithOpenApi();

app.Run();
