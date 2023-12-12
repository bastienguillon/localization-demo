using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LocalizationDemo.Database.Storage;

public sealed class LocalizationDemoContext(DbContextOptions<LocalizationDemoContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}