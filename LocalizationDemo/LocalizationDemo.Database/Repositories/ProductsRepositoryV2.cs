using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Repositories;

public class ProductsRepositoryV2(LocalizationDemoContext dbContext) : IProductsRepositoryV2
{
    public async Task<IReadOnlyCollection<Product>> GetAllAsync(string? search)
    {
        IQueryable<Product> query = dbContext.Set<Product>();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(
                product => product.Translations.Any(
                    translation => EF.Functions.Like(translation.Name, $"%{search}%")
                )
            );
        }

        return await query.ToArrayAsync();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return dbContext
            .Set<Product>()
            .FirstOrDefaultAsync(product => product.Id == id);
    }
}