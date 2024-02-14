using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;

namespace LocalizationDemo.Domain.Collections;

public sealed class ProductsCollectionV2(IProductsRepositoryV2 productsRepository)
{
    public Task<IReadOnlyCollection<Product>> GetAllAsync(string? search)
        => productsRepository.GetAllAsync(search);
    
}