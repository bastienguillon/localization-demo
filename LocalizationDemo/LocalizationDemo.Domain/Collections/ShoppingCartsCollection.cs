using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Models.ShoppingCarts;
using LocalizationDemo.Domain.Ports;

namespace LocalizationDemo.Domain.Collections;

public sealed class ShoppingCartsCollection(IShoppingCartsRepository repository)
{
    public Task<LocalizedShoppingCart?> GetByIdAsync(Guid id)
        => repository.GetByIdAsync(id);
}