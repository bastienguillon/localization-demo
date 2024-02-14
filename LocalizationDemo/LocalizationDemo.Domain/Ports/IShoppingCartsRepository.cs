using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Models.Shopping;

namespace LocalizationDemo.Domain.Ports;

public interface IShoppingCartsRepository
{
    Task<LocalizedShoppingCart?> GetByIdAsync(Guid id);
}