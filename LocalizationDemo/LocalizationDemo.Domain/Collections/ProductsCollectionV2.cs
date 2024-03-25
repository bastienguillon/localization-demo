using LocalizationDemo.Domain.Abstractions;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;

namespace LocalizationDemo.Domain.Collections;

public sealed class ProductsCollectionV2(
    IProductsRepositoryV2 productsRepository,
    IUnitOfWork unitOfWork
)
{
    public Task<IReadOnlyCollection<Product>> GetAllAsync(string? search)
        => productsRepository.GetAllAsync(search);

    public Task<Product?> GetByIdAsync(int id)
        => productsRepository.GetByIdAsync(id);

    public async Task<Product?> UpdateByIdAsync(int id, ProductUpdateCandidate candidate)
    {
        var product = await GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }

        if (candidate.Translations is not null)
        {
            product.Translations = candidate
                .Translations
                .Select(kvp => new Product.ProductTranslation
                {
                    CultureCode = kvp.Key,
                    Name = kvp.Value.Name,
                    Description = kvp.Value.Description
                })
                .ToList();
        }

        if (candidate.Category is not null)
        {
            product.Category = candidate.Category.Value;
        }

        await unitOfWork.CommitAsync();

        return product;
    }
}