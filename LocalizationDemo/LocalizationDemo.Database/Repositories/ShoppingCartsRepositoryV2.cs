using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Models.ShoppingCarts;
using LocalizationDemo.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Repositories;

public sealed class ShoppingCartsRepositoryV2(LocalizationDemoContext dbContext) : IShoppingCartsRepositoryV2
{
    public Task<ShoppingCart?> GetByIdAsync(Guid id)
        => dbContext
            .Set<ShoppingCart>()
            .Include(sc => sc.Products)
                .ThenInclude(scp => scp.Product)
            .FirstOrDefaultAsync(sc => sc.Id.ToString() == id.ToString());
}