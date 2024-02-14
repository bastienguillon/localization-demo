using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Domain.Ports;

public interface IProductsRepositoryV2
{
    Task<IReadOnlyCollection<Product>> GetAllAsync(string? search);
}