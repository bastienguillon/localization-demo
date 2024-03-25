using LocalizationDemo.Domain.Models.ShoppingCarts;

namespace LocalizationDemo.Domain.Ports;

public interface IShoppingCartsRepositoryV2
{
    Task<ShoppingCart?> GetByIdAsync(Guid id);
}