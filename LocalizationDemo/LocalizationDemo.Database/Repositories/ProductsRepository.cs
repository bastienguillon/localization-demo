using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Repositories;

public sealed class ProductsRepository(LocalizationDemoContext dbContext) : IProductsRepository
{
    public async Task<IReadOnlyCollection<LocalizedProduct>> GetAllAsync(string? search)
    {
        IQueryable<LocalizedProduct> query = dbContext.Set<LocalizedProduct>();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(product => EF.Functions.Like(product.Name, $"%{search}%"));
        }
        return await query.ToArrayAsync();
    }

    public Task<LocalizedProduct?> GetByIdAsync(int id) =>
        dbContext.Set<LocalizedProduct>().FirstOrDefaultAsync(product => product.Id == id);
}