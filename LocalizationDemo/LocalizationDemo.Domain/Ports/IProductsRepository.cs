using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Domain.Ports;

public interface IProductsRepository
{
    Task<IReadOnlyCollection<LocalizedProduct>> GetAllAsync();
    Task<LocalizedProduct?> GetByIdAsync(int id);
}