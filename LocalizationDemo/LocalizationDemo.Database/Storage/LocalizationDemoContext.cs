using System.Reflection;
using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Storage;

public sealed class LocalizationDemoContext(
    DbContextOptions<LocalizationDemoContext> options,
    ContentCultureAccessor contentCultureAccessor
) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Localized entities query filters
        modelBuilder
            .Entity<LocalizedProduct>()
            .HasQueryFilter(product => product.CultureCode.ToLower() == contentCultureAccessor.ContentCulture.ToLower());
    }
}