using LocalizationDemo.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocalizationDemo.Database.Storage.Configurations.Products;

public class LocalizedProductConfiguration : IEntityTypeConfiguration<LocalizedProduct>
{
    public void Configure(EntityTypeBuilder<LocalizedProduct> builder)
    {
        builder
            .ToView("LocalizedProducts");
        
        builder
            .HasKey(product => product.Id);

        builder
            .Property(product => product.Category)
            .HasConversion(new EnumToStringConverter<ProductCategory>())
            .HasColumnName("Category");

        builder
            .Property(product => product.UsdPrice)
            .HasColumnName("UsdPrice");

        builder
            .Property(product => product.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder
            .Property(product => product.Description)
            .HasColumnName("Description");
    }
}