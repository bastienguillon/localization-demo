using LocalizationDemo.Domain.Models.Products;
using LocalizationDemo.Domain.Models.Shopping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Shopping;

public sealed class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder
            .ToTable("ShoppingCarts");

        builder
            .HasKey(sc => sc.Id);

        builder.OwnsMany(
            sc => sc.Products,
            shoppingCartProductBuilder =>
            {
                shoppingCartProductBuilder.ToTable("ShoppingCartProducts");

                shoppingCartProductBuilder.HasKey(scp => new { scp.ShoppingCartId, scp.ProductId });

                shoppingCartProductBuilder
                    .HasOne(scp => scp.Product)
                    .WithMany()
                    .HasForeignKey(scp => scp.ProductId);
            }
        );
    }
}