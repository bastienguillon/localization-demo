using LocalizationDemo.Domain.Collections;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace LocalizationDemo.Web;

public static class ApiV1
{
    public const string BaseProductEndpoint = "/api/products";
    
    public static WebApplication MapApiV1Endpoints(this WebApplication app)
    {
        return app
            .MapProductEndpoints()
            .MapShoppingCartEndpoints();
    }

    private static WebApplication MapProductEndpoints(this WebApplication app)
    {
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
            .WithTags("v1")
            .WithOpenApi();

        // Get single product
        app.MapGet("/api/products/{id:int}", async (
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
            .WithTags("v1")
            .WithOpenApi();

        // Update single product
        app.MapPut("/api/products/{id:int}", async (
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
            })
            .WithTags("v1")
            .WithOpenApi();
        return app;
    }

    private static WebApplication MapShoppingCartEndpoints(this WebApplication app)
    {
        // Get single shopping cart
        app.MapGet("/api/shopping-carts/{id:guid}", async (
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
            .WithTags("v1")
            .WithOpenApi();

        return app;
    }
}