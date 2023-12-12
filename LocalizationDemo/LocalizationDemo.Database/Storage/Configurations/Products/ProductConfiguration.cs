using LocalizationDemo.Database.Abstractions;
using LocalizationDemo.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocalizationDemo.Database.Storage.Configurations.Products;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("Products");
        
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
            .OwnsMany(
                product => product.Translations,
                productTranslationBuilder =>
                {
                    productTranslationBuilder
                        .ToTable("ProductTranslations");
                    
                    productTranslationBuilder
                        .HasKey(translation => new { translation.ProductId, translation.CultureCode });
                    
                    productTranslationBuilder
                        .HasIndex(translation => new { translation.ProductId, translation.IsDefault })
                        .IsUnique()
                        .HasFilter("[IsDefault] = 1");

                    productTranslationBuilder
                        .Property(translation => translation.Name)
                        .IsRequired()
                        .HasColumnName("Name");

                    productTranslationBuilder
                        .Property(translation => translation.Description)
                        .HasColumnName("Description");
                    
                    productTranslationBuilder
                        .DeclareTranslatable();
                }
            );
    }
}