using LocalizationDemo.Domain.Models.ShoppingCarts;
using LocalizationDemo.Domain.Ports;

namespace LocalizationDemo.Domain.Collections;

public sealed class ShoppingCartsCollectionV2(IShoppingCartsRepositoryV2 repository)
{
    public Task<ShoppingCart?> GetByIdAsync(Guid id)
        => repository.GetByIdAsync(id);
}