using LocalizationDemo.Domain.Abstractions;
using LocalizationDemo.Domain.Collections;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Services;
using LocalizationDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationDemo.Web;

public static class ApiV2
{
    public static WebApplication MapApiV2Endpoints(this WebApplication app)
    {
        return app
            .MapProductEndpoints();
    }

    private static WebApplication MapProductEndpoints(this WebApplication app)
    {
        // Get all products
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
            .WithTags("v2")
            .WithOpenApi();

        // Get single product
        app.MapGet("/api/v2/products/{id:int}", async (
                int id,
                ProductsCollectionV2 collection,
                ContentCultureAccessor contentCultureAccessor
            ) =>
            {
                var product = await collection.GetByIdAsync(id);
                return product is null
                    ? Results.NotFound()
                    : Results.Ok(new ProductDto(
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
                        )
                    );
            })
            .WithTags("v2")
            .WithOpenApi();

        // Update single product
        app.MapPut("/api/v2/products/{id:int}", async (
                int id,
                [FromBody] ProductUpdateCandidate candidate,
                ProductsCollectionV2 collection,
                ContentCultureAccessor contentCultureAccessor
            ) =>
            {
                var updatedProduct = await collection.UpdateByIdAsync(id, candidate);
                return updatedProduct is null
                    ? Results.NotFound()
                    : Results.Ok(new ProductDto(
                            updatedProduct.Id,
                            updatedProduct
                                .Translations
                                .GetBestTranslation(contentCultureAccessor.ContentCulture)
                                .Name,
                            updatedProduct
                                .Translations
                                .GetBestTranslation(contentCultureAccessor.ContentCulture)
                                .Description,
                            updatedProduct.UsdPrice,
                            updatedProduct.Category
                        )
                    );
            })
            .WithTags("v2")
            .WithOpenApi();

        return app;
    }
}