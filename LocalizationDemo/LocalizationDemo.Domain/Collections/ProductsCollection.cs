using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;

namespace LocalizationDemo.Domain.Collections;

public sealed class ProductsCollection(IProductsRepository productsRepository)
{
    public Task<IReadOnlyCollection<LocalizedProduct>> GetAllAsync()
        => productsRepository.GetAllAsync();

    public Task<LocalizedProduct?> GetByIdAsync(int id)
        => productsRepository.GetByIdAsync(id);
}