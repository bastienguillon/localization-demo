using LocalizationDemo.Domain.Models.Shopping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Shopping;

public sealed class LocalizedShoppingCartConfiguration : IEntityTypeConfiguration<LocalizedShoppingCart>
{
    public void Configure(EntityTypeBuilder<LocalizedShoppingCart> builder)
    {
        // NB: this view does not exist, it's actually a table
        // but we trick EF into thinking it is to join on LocalizedProducts
        builder
            .ToView("ShoppingCarts");

        builder
            .HasKey(sc => sc.Id);

        builder.OwnsMany(
            sc => sc.Products,
            shoppingCartProductBuilder =>
            {
                // NB: same here, not a view
                shoppingCartProductBuilder.ToView("ShoppingCartProducts");

                shoppingCartProductBuilder.HasKey(scp => new { scp.ShoppingCartId, scp.ProductId });
                    
                shoppingCartProductBuilder
                    .HasOne(scp => scp.Product)
                    .WithMany()
                    .HasForeignKey(cp => cp.ProductId);
            }
        );
    }
}