using LocalizationDemo.Database.Storage;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Repositories;

public sealed class ProductsRepository : IProductsRepository
{
    private readonly LocalizationDemoContext _dbContext;

    public ProductsRepository(
        LocalizationDemoContext dbContext    
    )
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<LocalizedProduct>> GetAllAsync()
        => await _dbContext.Set<LocalizedProduct>().ToArrayAsync();

    public Task<LocalizedProduct?> GetByIdAsync(int id) =>
        _dbContext.Set<LocalizedProduct>().FirstOrDefaultAsync(product => product.Id == id);
}