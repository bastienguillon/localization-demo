using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Models.ShoppingCarts;
using LocalizationDemo.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Repositories;

public sealed class ShoppingCartsRepository(LocalizationDemoContext dbContext) : IShoppingCartsRepository
{
    public Task<LocalizedShoppingCart?> GetByIdAsync(Guid id)
        => dbContext
            .Set<LocalizedShoppingCart>()
            .Include(sc => sc.Products)
                .ThenInclude(scp => scp.Product)
            .FirstOrDefaultAsync(sc => sc.Id.ToString() == id.ToString());
}