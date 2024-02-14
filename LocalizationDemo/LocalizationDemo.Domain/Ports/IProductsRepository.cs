using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Domain.Ports;

public interface IProductsRepository
{
    Task<IReadOnlyCollection<LocalizedProduct>> GetAllAsync(string? search);
    Task<LocalizedProduct?> GetByIdAsync(int id);
    Task<LocalizedProduct?> UpdateByIdAsync(int id, ProductUpdateCandidate candidate);
}