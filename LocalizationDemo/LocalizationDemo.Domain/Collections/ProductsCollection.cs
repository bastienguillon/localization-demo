using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;

namespace LocalizationDemo.Domain.Collections;

public sealed class ProductsCollection(IProductsRepository productsRepository)
{
    public Task<IReadOnlyCollection<LocalizedProduct>> GetAllAsync(string? search)
        => productsRepository.GetAllAsync(search);

    public Task<LocalizedProduct?> GetByIdAsync(int id)
        => productsRepository.GetByIdAsync(id);

    public async Task<LocalizedProduct?> UpdateByIdAsync(int id, ProductUpdateCandidate candidate)
    {
        var product = await GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }
        
        // The actual update is handled by the repository :/ 
        return await productsRepository.UpdateByIdAsync(id, candidate);
    }
}